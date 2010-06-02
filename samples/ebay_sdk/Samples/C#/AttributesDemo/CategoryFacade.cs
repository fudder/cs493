using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using Samples.Helper.Cache;
using eBay.Service.SDK.Attribute;
using eBay.Service.Call;


namespace AttributesDemo
{
    //facade for category level API, cache category level meta-data
    public class CategoryFacade
    {

        private ApiContext apiContext = null;
        private String catId = null;
        private AttributesMaster attrMaster = null;
        private SiteFacade siteFacade = null;
        private ItemSpecificsEnabledCodeType itemSpecificEnabled;
        private bool returnPolicyEnabled = false;
        private Hashtable listingType2DurationMap = null;
        private BuyerPaymentMethodCodeTypeCollection paymentMethod = null;
        private IAttributeSetCollection joinedAttrSets = null;
        private NameRecommendationTypeCollection nameRecommendationTypes = null;

        private IAttributeSetCollection itemAttributes = null;
        private NameValueListTypeCollection itemSpecifics = null;
        private ReturnPolicyType returnPolicy = null;

        //constructor
        public CategoryFacade(string catId, ApiContext apiContext, AttributesMaster attrMaster, SiteFacade siteFacade)
        {
            this.catId = catId;
            this.apiContext = apiContext;
            this.attrMaster = attrMaster;
            this.siteFacade = siteFacade;

            this.SyncCategoryMetaData();
        }

        private void SyncCategoryMetaData()
        {
            SyncJoinedAttrSets();
            SyncCategoryFeatures();
            SyncNameRecommendationTypes();
        }

        private void SyncJoinedAttrSets()
        {
            Int32Collection ids = new Int32Collection();
            int catId = Int32.Parse(this.CategoryID);
            ids.Add(catId);

            IAttributeSetCollection itemSpecAttrSets = this.attrMaster.GetItemSpecificAttributeSetsForCategories(ids);
            IAttributeSetCollection siteWideAttrSets = this.attrMaster.GetSiteWideAttributeSetsForCategories(ids);
            IAttributeSetCollection joinedAttrSets = this.attrMaster.JoinItemSpecificAndSiteWideAttributeSets(itemSpecAttrSets, siteWideAttrSets);

            this.joinedAttrSets = joinedAttrSets;
        }

        //
        //sync category features
        //
        private void SyncCategoryFeatures()
        {

            Hashtable catsTable = this.siteFacade.GetAllCategoriesTable();

            Hashtable cfsTable = this.siteFacade.SiteCategoriesFeaturesTable[this.apiContext.Site] as Hashtable;
            SiteDefaultsType siteDefaults = this.siteFacade.SiteFeatureDefaultTable[this.apiContext.Site] as SiteDefaultsType;
            FeatureDefinitionsType featureDefinition = this.siteFacade.SiteFeatureDefinitionsTable[this.apiContext.Site] as FeatureDefinitionsType;


            CategoryFeatureType cf = cfsTable[this.CategoryID] as CategoryFeatureType;
            //get item SpecificsEnabled feature
            //workaround, if no CategoryFeature found, just use site defaults
            this.ItemSpecificEnabled = (cf == null) ? siteDefaults.ItemSpecificsEnabled : cf.ItemSpecificsEnabled;

            //get returnPolicyEnabled feature
            //workaround, just use siteDefaults now
            //bool retPolicyEnabled = (cf == null)?siteDefaults.ReturnPolicyEnabled:cf.ReturnPolicyEnabled;
            this.ReturnPolicyEnabled = siteDefaults.ReturnPolicyEnabled;

            //listing types, recursively search
            ListingDurationReferenceTypeCollection listingTypes = getListingTypes(this.CategoryID, catsTable, cfsTable);
            if (listingTypes == null || listingTypes.Count == 0)//get site defaults
            {
                listingTypes = siteDefaults.ListingDuration;
            }
            //listing duration definitions
            ListingDurationDefinitionsType listingDurations = featureDefinition.ListingDurations;
            //get a mapping from listing type to duration
            this.ListingType2DurationMap = constructListingTypeDurationMapping(listingTypes, listingDurations);

            //payment methods
            BuyerPaymentMethodCodeTypeCollection paymentMethods = getPaymentMethods(this.CategoryID, catsTable, cfsTable);
            if (paymentMethods == null || paymentMethods.Count == 0)//get site defautls
            {
                paymentMethods = siteDefaults.PaymentMethod;
            }
            this.PaymentMethod = paymentMethods;
        }

        //recursively search for the payment metheds for a given category
        private BuyerPaymentMethodCodeTypeCollection getPaymentMethods(string catId, Hashtable catsTable, Hashtable cfsTable)
        {
            if (cfsTable.ContainsKey(catId))
            {
                CategoryFeatureType cf = (CategoryFeatureType)cfsTable[catId];
                if (cf.PaymentMethod != null)
                {
                    return cf.PaymentMethod;
                }
            }

            CategoryType cat = (CategoryType)catsTable[catId];
            //if we reach top level, return null
            if (cat.CategoryLevel == 1)
            {
                return null;
            }

            //check parent category
            return getPaymentMethods(cat.CategoryParentID[0], catsTable, cfsTable);

        }

        //recursively search for the listing duration reference type for a given category
        private ListingDurationReferenceTypeCollection getListingTypes(string catId, Hashtable catsTable, Hashtable cfsTable)
        {
            if (cfsTable.ContainsKey(catId))
            {
                CategoryFeatureType cf = cfsTable[catId] as CategoryFeatureType;
                if (cf.ListingDuration != null)
                {
                    return cf.ListingDuration;
                }
            }

            CategoryType cat = catsTable[catId] as CategoryType;
            //if we reach top level, return null
            if (cat.CategoryLevel == 1)
            {
                return null;
            }

            //check parent category
            return getListingTypes(cat.CategoryParentID[0], catsTable, cfsTable);
        }


        /// <summary>
        /// construct a mapping from listing type to listing duration
        /// </summary>
        /// <param name="listingTypes"></param>
        /// <param name="listingDurations"></param>
        /// <returns>Hashtable</returns>
        private Hashtable constructListingTypeDurationMapping(ListingDurationReferenceTypeCollection listingTypes, ListingDurationDefinitionsType listingDurations)
        {
            Hashtable listingTypeDurationMap = new Hashtable();
            eBay.Service.Core.Soap.StringCollection listingDuration = null;

            foreach (ListingDurationReferenceType listingType in listingTypes)
            {
                string key = listingType.type.ToString();
                //iterate listingDuration collection to find specific listingDuration whose durationSetID equals listingType id
                foreach (ListingDurationDefinitionType definition in listingDurations.ListingDuration)
                {
                    if (definition.durationSetID.Equals(listingType.Value))
                    {
                        listingDuration = definition.Duration;
                    }
                }

                listingTypeDurationMap.Add(key, listingDuration);
            }

            return listingTypeDurationMap;
        }

        private void SyncNameRecommendationTypes()
        {
            GetCategorySpecificsCall api = new GetCategorySpecificsCall(this.apiContext);
            DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] { DetailLevelCodeType.ReturnAll };
            api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
            eBay.Service.Core.Soap.StringCollection strCol = new eBay.Service.Core.Soap.StringCollection();
            strCol.Add(this.CategoryID);
            api.CategoryIDList = strCol;
            api.Execute();

            NameRecommendationTypeCollection nameRecommendationTypes = null;
            if ((api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning)
                    && api.ApiResponse.Recommendations != null
                    && api.ApiResponse.Recommendations.Count > 0)
            {
                nameRecommendationTypes = api.ApiResponse.Recommendations[0].NameRecommendation;
            }

            this.nameRecommendationTypes = nameRecommendationTypes;
        }

        public String CategoryID
        {
            get { return catId; }
            set { catId = value; }
        }

        /*
        public AttributesMaster AttributesMaster
        {
            get { return attrMaster; }
            set { attrMaster = value; }
        }*/

        public ItemSpecificsEnabledCodeType ItemSpecificEnabled
        {
            get { return this.itemSpecificEnabled; }
            set { itemSpecificEnabled = value; }
        }

        public bool ReturnPolicyEnabled
        {
            get { return this.returnPolicyEnabled; }
            set { this.returnPolicyEnabled = value; }
        }

        public Hashtable ListingType2DurationMap
        {
            get { return this.listingType2DurationMap; }
            set { this.listingType2DurationMap = value; }
        }

        public BuyerPaymentMethodCodeTypeCollection PaymentMethod
        {
            get { return this.paymentMethod; }
            set { this.paymentMethod = value; }
        }

        public bool HasAttributes
        {
            get
            {
                return (this.joinedAttrSets != null && this.joinedAttrSets.Count > 0);
            }
        }

        public IAttributeSetCollection JoinedAttrSets
        {
            get { return joinedAttrSets; }
        }

        public NameRecommendationTypeCollection NameRecommendationsTypes
        {
            get { return nameRecommendationTypes; }
        }

        public IAttributeSetCollection ItemAttributesCache
        {
            get { return itemAttributes; }
            set { itemAttributes = value; }
        }

        public NameValueListTypeCollection ItemSpecificsCache
        {
            get { return itemSpecifics; }
            set { itemSpecifics = value; }
        }

        public ReturnPolicyType ReturnPolicyCache
        {
            get { return returnPolicy; }
            set { returnPolicy = value; }
        }
    }
}

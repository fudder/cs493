using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eBay.Service.Core.Soap;
using eBay.Service.SDK.Attribute;

using System.Threading;

namespace AttributesDemo
{
    public partial class CategoryListForm : Form
    {
        private AttributesController controller = null;
        private SortedList sortedLeafCategories = null;

        public CategoryListForm(AttributesController controller)
        {
            this.controller = controller;

            InitializeComponent();
        }

        public void InitCategoryList()
        {
            //show a please wait dialog for this lengthy process
            controller.ShowPleaseWaitDialog();

            sortedLeafCategories = GetSortedLeafCategories();

            pupulateCategoryList();

            controller.HidePleaseWaitDialog();

        }

        private SortedList GetSortedLeafCategories()
        {
            SortedList catSL = new SortedList();

            CategoryTypeCollection catCol = controller.SiteFacade.GetAllMergedCategories();

            foreach (CategoryType cat in catCol)
            {
                //remove non-leaf category
                if (!cat.LeafCategory) continue;
                catSL.Add(int.Parse(cat.CategoryID), cat);
            }

            return catSL;
        }

        private void pupulateCategoryList()
        {
            this.categoryListBox.Items.Clear();
            
            Hashtable cfsTable = this.controller.SiteFacade.SiteCategoriesFeaturesTable[this.controller.ApiContext.Site] as Hashtable;

            for (int i = 0; i < sortedLeafCategories.Count; i++)
            {
                CategoryType cat = (CategoryType)sortedLeafCategories.GetByIndex(i);
                String catName = cat.CategoryName;
                int csId = int.MinValue;
                bool hasCharacterstic = false;
                bool hasItemSpecifics = false;

                if (cat.CharacteristicsSets != null && cat.CharacteristicsSets.Count > 0)
                {
                    csId = cat.CharacteristicsSets[0].AttributeSetID;
                    hasCharacterstic = true;
                }

                CategoryFeatureType cft = cfsTable[cat.CategoryID] as CategoryFeatureType;
                if (cft != null && cft.ItemSpecificsEnabled == ItemSpecificsEnabledCodeType.Enabled)
                {
                    hasItemSpecifics = true;
                }

                //ignore category which has no attributes or item specifics
                if (!hasCharacterstic && !hasItemSpecifics)
                {
                    continue;
                }

                if (this.AttributesOnlyRadioButton.Checked && (!hasCharacterstic || hasItemSpecifics))
                {
                    continue;
                }

                if (this.ItemSpecificsOnlyRadioButton.Checked && (!hasItemSpecifics || hasCharacterstic))
                {
                    continue;
                }

                if (this.BothRadioButton.Checked && (!hasItemSpecifics || !hasCharacterstic))
                {
                    continue;
                }

                string prefix = this.getPrefix(hasCharacterstic, hasItemSpecifics);

                string csID = hasCharacterstic ? ("-" + csId) : string.Empty;

                string name;
                string value;

                if (catName != null && catName.Length > 1)
                {
                    name = prefix + cat.CategoryName + "(" + cat.CategoryID + csID + ")";
                    value = cat.CategoryID;

                }
                else
                {
                    name = prefix + cat.CharacteristicsSets[0].Name + "[" + cat.CategoryID + csID + "]";
                    value = cat.CategoryID;
                }

                categoryListBox.Items.Add(new ListItem(name, value));
            }
        }

        private string getPrefix(bool hasCharacterstic, bool hasItemSpecifics)
        {
            string prefix;
            if (hasItemSpecifics && hasCharacterstic)
            {
                prefix = "AS ";
            }
            else if (hasCharacterstic)
            {
                prefix = "A_ ";
            }
            else
            {
                prefix = "_S ";
            }

            return prefix;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SiteListForm selectSiteForm = (SiteListForm)controller.FormTable[AttributesController.SELECT_SITE_FORM];

            this.Hide();
            selectSiteForm.Show();
            selectSiteForm.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ListItem selectedItem = this.categoryListBox.SelectedItem as ListItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Please select a category first!");
                    return;
                }

                this.Hide();

                this.controller.ShowPleaseWaitDialog();

                this.controller.InitCategoryFacade(selectedItem.Value);


                //for category with both attributes and item specifics enabled,
                //we only use item specifics
                if (this.controller.CategoryFacade.ItemSpecificEnabled == ItemSpecificsEnabledCodeType.Enabled)
                {
                    NameRecommendationTypeCollection itemSpecifics = this.controller.CategoryFacade.NameRecommendationsTypes;

                    ItemSpecificsForm itemSpecificsForm = controller.FormTable[AttributesController.ITEM_SPECIFICS_FORM] as ItemSpecificsForm;

                    itemSpecificsForm.DisplayItemSpecifics(itemSpecifics);

                    itemSpecificsForm.Show();
                    itemSpecificsForm.BringToFront();

                    this.controller.HidePleaseWaitDialog();

                    return;
                }

                if (this.controller.CategoryFacade.HasAttributes)
                {

                    AttributeInfoForm attributeInfoForm = controller.FormTable[AttributesController.ATTRIBUTES_INFO_FORM] as AttributeInfoForm;

                    attributeInfoForm.DisplayAttributes(this.controller.CategoryFacade.JoinedAttrSets);

                    attributeInfoForm.Show();
                    attributeInfoForm.BringToFront();

                    this.controller.HidePleaseWaitDialog();

                    return;
                }


                ReturnPolicyForm returnPolicyForm = controller.FormTable[AttributesController.RETURN_POLICY_FORM] as ReturnPolicyForm;

                returnPolicyForm.InitializeReturnPolicy();

                returnPolicyForm.Show();
                returnPolicyForm.BringToFront();

                this.controller.HidePleaseWaitDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void AttributesOnlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pupulateCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemSpecificsOnlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pupulateCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BothRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pupulateCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pupulateCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
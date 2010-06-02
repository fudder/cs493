using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eBay.Service.SDK.Attribute;
using eBay.Service.Core.Soap;
using SHDocVw;

namespace AttributesDemo
{
    public partial class AttributeInfoForm : Form
    {

        private AttributesController controller = null;

        public AttributeInfoForm(AttributesController controller)
        {
            this.controller = controller;

            InitializeComponent();

            this.registerWebBrowserEventHandler();

        }

        private void registerWebBrowserEventHandler()
        {
            webBrowser.Navigate("about:blank");
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)webBrowser.ActiveXInstance;
            wb.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(WebBrowser_BeforeNavigate2);
        }

        //cancel the navigation, intercept the posted data 
        private void WebBrowser_BeforeNavigate2(object pDisp, ref object URL, ref object Flags,
                                                ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            if (PostData != null)
            {
                Cancel = true;
                string postDataText = System.Text.Encoding.ASCII.GetString(PostData as byte[]);
                postDataText = postDataText.Replace("\0", "");
                NameValueCollection request = ParsePostString(postDataText);
                string action = request["action"];
                if (action == "post")
                {
                    Post(request);
                }
                else if (action == "back")
                {
                    CategoryListForm categorySiteForm = (CategoryListForm)controller.FormTable[AttributesController.CATEGORY_LIST_FORM];

                    this.Hide();
                    categorySiteForm.Show();
                    categorySiteForm.BringToFront();
                }
            }
        }

        private NameValueCollection ParsePostString(string s)
        {
            NameValueCollection nvc = new NameValueCollection();

            foreach (string vp in Regex.Split(s, "&"))
            {
                string[] singlePair = Regex.Split(vp, "=");
                nvc.Add(singlePair[0], singlePair[1]);
            }

            return nvc;
        }

        private void Post(NameValueCollection request)
        {
            try
            {
                AttributesMaster attrMaster = this.controller.SiteFacade.AttributesMaster;

                IAttributeSetCollection sets = attrMaster.NameValuesToAttributeSets(AttributesHelper.ConvertFromNameValues(request));
                IErrorSetCollection errList = attrMaster.Validate(sets);

                if (errList.Count > 0)
                {

                    this.controller.ShowPleaseWaitDialog();
                    DisplayAttributesWithValidationError(request, errList);
                    this.controller.HidePleaseWaitDialog();
                }
                else
                {
                    //cache submitted item attributes
                    this.controller.CategoryFacade.ItemAttributesCache = sets;

                    this.Hide();

                    ReturnPolicyForm returnPolicyForm = controller.FormTable[AttributesController.RETURN_POLICY_FORM] as ReturnPolicyForm;

                    returnPolicyForm.InitializeReturnPolicy();

                    returnPolicyForm.Show();
                    returnPolicyForm.BringToFront();

                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayAttributesWithValidationError(NameValueCollection request, IErrorSetCollection errList)
        {

            webBrowser.Document.OpenNew(true);

            AddHtmlHeaders();

            AttributesMaster attrMaster = this.controller.SiteFacade.AttributesMaster;

            string tableText = attrMaster.RenderHtmlForPostback(AttributesHelper.ConvertFromNameValues(request), errList);

            webBrowser.Document.Write(tableText);

            AddHtmlTails();

        }

        public void DisplayAttributes(IAttributeSetCollection joinedAttrSets)
        {
            webBrowser.Document.OpenNew(true);

            AddHtmlHeaders();

            string tableText = this.controller.SiteFacade.AttributesMaster.RenderHtml(joinedAttrSets, null);
            webBrowser.Document.Write(tableText);

            AddHtmlTails();
        }

        private void AddHtmlHeaders()
        {
            webBrowser.Document.Write("<html>");
            webBrowser.Document.Write("<head>");
            webBrowser.Document.Write("<title>Attribute Info</title>");
            webBrowser.Document.Write("</head>");
            webBrowser.Document.Write("<body>");
            webBrowser.Document.Write("<script language=\"javascript\">");
            webBrowser.Document.Write("function onClick(id)");
            webBrowser.Document.Write("{");
            webBrowser.Document.Write("document.all('action').value = id;");
            webBrowser.Document.Write("document.forms['APIForm'].submit();");
            webBrowser.Document.Write("}\n");
            webBrowser.Document.Write("</script>");

            webBrowser.Document.Write("<form name=\"APIForm\" id=\"APIForm\" method=\"post\" action=\"\">");
            webBrowser.Document.Write("<table align=\"center\" border=\"0\"><tr><td><img src=\"http://pics.ebaystatic.com/aw/pics/logos/logoEbay_x45.gif\"></td></tr><tr><td>");

            
        }

        private void AddHtmlTails()
        {
            webBrowser.Document.Write("</td></tr><tr><td align=\"center\">");
            string s = "<input type=\"button\" name=\"btSubmit0\" value=\"&nbsp;Back&nbsp;\" id=\"btSubmit0\"";
            s += "onclick=\"javascript:onClick('back')\"" + "/>";
            webBrowser.Document.Write(s);
            webBrowser.Document.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            s = "<input type=\"button\" name=\"btSubmit1\" value=\"Continue\" id=\"btSubmit1\"";
            s += "onclick=\"javascript:onClick('post')\"" + "/>";
            webBrowser.Document.Write(s);
            webBrowser.Document.Write("</td></tr></table>");
            webBrowser.Document.Write("<input type=\"hidden\" name=\"action\" value=\"display\"/>");
            webBrowser.Document.Write("</form></body></html>");
        }
    }
}
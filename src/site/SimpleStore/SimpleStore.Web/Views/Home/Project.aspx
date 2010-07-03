<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Project Deliverables
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Project Deliverables</h2>

    <p>
        Here are the formal project deliverables for download. I recommend, however, taking the guided tour through the <a href="/Home/Product">Product section</a>, as this
        really shows what the product is all about.
    </p>

    <ul>
        <li><b>Research Paper:</b><br />
        <a href="../../Content/Docs/Brossard_CapstoneResearchPaper.docx">Brossard_CapstoneResearchPaper.docx</a>
        </li>
        <li><b>Presentation:</b><br />
        <a href="../../Content/Docs/Brossard_CapstonePresentation.pptx">Brossard_CapstonePresentation.pptx</a><br />
        </li>
        <li><b>Reflection Paper:</b><br />
        <a href="../../Content/Docs/Brossard_CapstoneReflectionPaper.doc">Brossard_CapstoneReflectionPaper.doc</a><br />
        </li>
        <li><b>Complete Capstone Product:</b><br />
            Website: <%: Html.ActionLink("Product Documentation", "Product") %><br />
            Download: <a href="../../Content/Docs/Brossard_CapstoneDeliverables.zip">Brossard_CapstoneDeliverables.zip</a><br />
        </li>
    </ul>
    

</asp:Content>

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
        <li><b>Research Paper: <a href="/Content/Brossard_CapstoneResearchPaper.docx">Brossard_CapstoneResearchPaper.docx</a></b><br />
        </li>
        <li><b>Presentation: <a href="/Content/Brossard_CapstonePresentation.ppt">Brossard_CapstonePresentation.ppt</a></b><br />
        </li>
        <li><b>Reflection Paper: <a href="/Content/Brossard_CapstoneReflectionPaper.docx">Brossard_CapstoneReflectionPaper.docx</a></b><br />
        </li>
        <li><b>Capstone Product: <a href="/Content/Brossard_CapstoneProductDocuments.zip">Brossard_CapstoneProductDocuments.zip</a></b><br />
        </li>
    </ul>
    

</asp:Content>

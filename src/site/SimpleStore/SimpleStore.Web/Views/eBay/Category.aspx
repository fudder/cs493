<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleStore.Web.Models.eBayCategoryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Category
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>eBay Category Hierachy Navigation Prototype</h2>

    &gt; <a href="0">Root</a>
    <% foreach (eBay.Service.Core.Soap.CategoryType cat in Model.BreadCrumb)
       {  %>
            &gt; <a href="<%=cat.CategoryID %>"><%=cat.CategoryName%></a>
    <% } %>

    <br /><br />

    <% foreach (eBay.Service.Core.Soap.CategoryType cat in Model.Categories)
       {  %>
            <% if (cat.LeafCategory)
               { %>
               <%=cat.CategoryName%>
            <% }
               else
               { %>
                <a href="<%=cat.CategoryID %>"><%=cat.CategoryName%></a>
           <%  } %>
           <br />
    <% } %>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<SimpleStore.Core.Site>>" %>
<%@ Import Namespace="SimpleStore.Core" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sites Matching Filter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Matching Sites:</h2>

    <ul>
        <%
        foreach (Site s in ViewData.Model) { %>
         <li><%= s.Name %></li><%
        }
        %>
    </ul>

</asp:Content>

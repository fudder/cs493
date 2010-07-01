<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<SimpleStore.Core.Site>>" %>
<%@ Import Namespace="SimpleStore.Core" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sites Matching Filter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Matching Sites:</h2>

    <% using (Html.BeginForm())
       { %>

       Filter: <%: Html.TextBox("Filter") %> <input type="submit" value="Go" />

    <% } %>

    <br />
    <table>
        <thead>
            <tr>
                <td>Site Id</td>
			    <td>Name</td>
			    <td>Tagline</td>
			    <td>Created</td>
             </tr>
        </thead>
        <tbody>
            <% foreach (Site s in ViewData.Model)
       {  %>
        <tr>
            <td><%: s.SiteId %></td>
			<td><%: s.Name%></td>
			<td><%: s.Tagline%></td>
			<td><%: s.Created %></td>
        </tr>
    <% } %>
        </tbody>
    </table>

</asp:Content>

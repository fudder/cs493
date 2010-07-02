<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<SimpleStore.Core.Seller>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% if (ViewData["Exception"] != null)
           Html.RenderPartial("ErrorBlock", ViewData["Exception"]); %>

    <h2>All Sellers</h2>

    <p><%: Html.ActionLink("Add new", "Create") %></p>

    <table>
        <thead>
            <tr>
                <td>Seller Id</td>
			    <td>Email</td>
			    <td>eBay User</td>
			    <td>Created</td>
                <td>Edit</td>
                <td>delete</td>
             </tr>
        </thead>
        <tbody>
            <% foreach (SimpleStore.Core.Seller s in ViewData.Model)
       {  %>
        <tr>
            <td><%: s.SellerId %></td>
			<td><%: s.Email %></td>
			<td><%: s.EbayUser %></td>
			<td><%: s.Created %></td>
            <td><%: Html.ActionLink("edit", "Edit", new { Id = s.SellerId })%></td>
            <td><%: Html.ActionLink("delete", "Delete", new { Id = s.SellerId }, new { Style = "color:red;" })%></td>
        </tr>
    <% } %>
        </tbody>
    </table>

</asp:Content>

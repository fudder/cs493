<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<eBay.Service.Core.Soap.ItemType>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Selling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My eBay Active Sales</h2>

    <p>You can log into eBay's developer sandbox here: <a href="http://my.sandbox.ebay.com">http://my.sandbox.ebay.com</a><br />
    Use the followng credentials:<br />
    <b>Username:</b> TESTUSER_cs493<br />
    <b>Password:</b> Test123</p>

    <table>
        <thead>
            <tr>
                <td>ItemID</td>
			    <td>Title</td>
			    <td>Current Price</td>
			    <td>Bid Count</td>
                <td>Time Left</td>
             </tr>
        </thead>
        <tbody>
            <% foreach (eBay.Service.Core.Soap.ItemType item in Model)
       {  %>
        <tr>
            <td><a href="<%: item.ListingDetails.ViewItemURL %>" target="_blank"><%: item.ItemID%></a></td>
			<td><%: item.Title%></td>
			<td><%: item.SellingStatus.CurrentPrice.Value.ToString("c")%></td>
			<td><%: item.SellingStatus.BidCount.ToString()%></td>
            <td><%: item.TimeLeft.ToString()%></td>
        </tr>
    <% } %>
        </tbody>
    </table>

</asp:Content>

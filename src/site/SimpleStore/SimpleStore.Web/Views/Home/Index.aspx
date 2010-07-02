<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>SimpleStore Project</h2>
    <p>
        Welcome to the Simple Store project site. This website has been developed to accompany the standard project deliverables required by the CS493 course. 
        While the documents are required, a website offers a more graphical, interactive experience for viewing content -- especially when the project under
        consideration is a website itself!
    </p>
    <h3>Next Steps...</h3>
    <p>
        <ul>
            <li>Check out the project <%: Html.ActionLink("documentation", "Product") %></li>
            <li>Browse through the complete project <%: Html.ActionLink("source code repository", "Source") %></li>
            <li>Run through our live <%: Html.ActionLink("prototypes", "Prototype") %></li>
            <li>View the <%: Html.ActionLink("deliverables", "Project") %></li>
        </ul>
    </p>
    <h3>What is SimpleStore?</h3>
    <p style="font-size: 90%">
        &nbsp;&nbsp;&nbsp;&nbsp;An online sales presence increases a retailer’s market exponentially. Many small-business products are so niche as to make any other sales approach economically 
        unfeasible. Selling things online, however, is a technically challenging proposition – there is hardware to procure and maintain, software to write, credit card 
        transactions to process, and customers to service. Thus, many small retailers have made eBay their online selling venue.  eBay gives users a trusted platform to 
        sell products – it takes care of the complicated search and payment aspects of the process. However, using the eBay platform requires sellers to forego having 
        their own product catalog website, with the associated benefits of increased marketing, better product presentation, up-sell and cross-sell opportunities, and 
        customer support.
    </p>

    <p style="font-size: 90%">
        &nbsp;&nbsp;&nbsp;&nbsp;The SimpleStore project is designed to address this shortcoming. Sellers will create and maintain a catalog of products, along with any other marketing material 
        they need to publish on their site. However, the product catalog will integrate with eBay, allowing users to automatically insert their products as eBay listings 
        through eBay’s API. The seller’s site will also allow customers to search for their products, once again leveraging eBay’s API. This allows the site to “own” the 
        retail experience, while still using the eBay platform for its payment processing and fulfillment tools. Any listed products will also appear on eBay itself, 
        increasing visibility. The site will create professional-looking template html for the eBay listing, and allow for linking between eBay and the actual SimpleStore site.
    </p>
</asp:Content>

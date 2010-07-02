<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SimpleStore Code Prototypes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SimpleStore Code Prototypes</h2>

    <p>
        The following prototypes were coded up as proofs of concept. All source code is browseable at my GitHub repository: <a href="http://github.com/fudder/cs493" target="_blank">http://github.com/fudder/cs493</a>
    </p>

    <ul>
        <li><b>Site Architecture: <a href="/Seller">CRUD Functions on Seller entities</a></b><br />
            This prototype test standard Entity create/read/update/delete functionality.<br />
        </li>
        <li><b>Site Architecture: <a href="/Site/MatchingFilter?filter=senior">Database call to return matching products</a></b><br />
            This prototype tests a non-standard Entity Repository selection from the database.
        </li>
        <li><b>eBay Integration: <a href="/eBay/Category">Browse eBay's category hiearchy</a></b><br />
            This prototype retrieves eBay's categorization structure.
        </li>
        <li><b>eBay Integration: <a href="/eBay/Selling">My active sales</a></b><br />
            This prototype lists the products a user is currently selling on eBay.
        </li>
    </ul>
    

</asp:Content>

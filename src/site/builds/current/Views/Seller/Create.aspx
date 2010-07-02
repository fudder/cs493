<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleStore.Core.Seller>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if (ViewData["Exception"] != null)
           Html.RenderPartial("ErrorBlock", ViewData["Exception"]); %>

    <h2>Create</h2>

    <p>
        <%: Html.ActionLink("Back to list", "Index") %>
    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EbayUser) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EbayUser) %>
                <%: Html.ValidationMessageFor(model => model.EbayUser) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>

        </fieldset>

    <% } %>

</asp:Content>


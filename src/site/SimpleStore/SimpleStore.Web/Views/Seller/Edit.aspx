<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleStore.Core.Seller>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if (ViewData["Exception"] != null)
           Html.RenderPartial("ErrorBlock", ViewData["Exception"]); %>

    <h2>Edit</h2>

    <p>
        <%: Html.ActionLink("Back to list", "Index") %>
    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <%: Html.HiddenFor(model => model.SellerId) %>
            <%: Html.HiddenFor(model => model.Id) %>
            <%: Html.HiddenFor(model => model.Created) %>
            
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
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Created) %>
            </div>
            <div class="editor-field">
                <%: Model.Created.ToString() %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>


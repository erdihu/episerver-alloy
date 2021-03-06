<%@ import namespace="System.Web.Mvc" %>
<%@ import namespace="EPiServer.Core" %>
<%@ import namespace="EPiServer.Web.Mvc.Html" %>
<%@ import namespace="EPiServer.Forms.Core" %>
<%@ import namespace="EPiServer.Forms.Core.Models" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Samples.Implementation.Elements" %>
<%@ import namespace="EPiServer.Forms.Samples.EditView" %>

<%@ control language="C#" inherits="ViewUserControl<DateTimeElementBlock>" %>

<%  
    var formElement = Model.FormElement;
    var labelText = Model.Label; 
    var errorMessage = Model.GetErrorMessage();
%>

<div class="Form__Element Form__CustomElement FormDateTime <%: Model.GetValidationCssClasses() %>" data-epiforms-element-name="<%: formElement.ElementName %>">
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" class="Form__CustomInput FormDateTime__Input"
        placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%= Model.AttributesString %> />

    <span data-epiforms-linked-name="<%: formElement.ElementName %>" class="Form__Element__ValidationError" style="<%: string.IsNullOrEmpty(errorMessage) ? "display:none" : "" %>;"><%: errorMessage %></span>

    <% if (!EPiServer.Editor.PageEditing.PageIsInEditMode) 
       {
        // push this Element information to a global blob. Then Samples.js will init them all at once. 
        var pickerType = ((DateTimePickerType)Model.PickerType).ToString().ToLower(); %>
    <script type="text/javascript">
        var __SamplesDateTimeElements = __SamplesDateTimeElements || [];
        __SamplesDateTimeElements.push({
            guid: "<%: formElement.Guid %>",
                pickerType: "<%: pickerType %>"
            });
    </script>
    <% } %>
</div>

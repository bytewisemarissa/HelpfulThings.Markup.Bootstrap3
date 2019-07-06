using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HelpfulThings.QuickBootstrapForms;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
// ReSharper disable MustUseReturnValue
// ReSharper disable UnknownCssClass

// ReSharper disable once CheckNamespace
namespace System.Web.Mvc.Html
{
    public static class QuickBootstrapForms
    {
        public static IHtmlContent BootstrapTextBoxFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isReadOnly = false)
        {
            var label = helper.LabelFor(expression, new { @for = helper.IdFor(expression) });

            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.TextBoxFor(expression, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.TextBoxFor(expression, new { @class = "form-control" });
            }

            var description = expression.GetDescription();
            var descriptionHtml = description == null ? string.Empty : $"<small class=\"text-muted\">{description}</small>";

            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-group\">");

            returnWriter.AppendHtml(label);
            returnWriter.AppendHtml(input);

            if (description != string.Empty)
            {
                returnWriter.AppendHtml(descriptionHtml);
            }

            returnWriter.AppendHtml("</div>");

            return returnWriter;
        }

        public static IHtmlContent BootstrapPasswordFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isReadOnly = false)
        {
            var label = helper.LabelFor(expression, new { @for = helper.IdFor(expression) });
            
            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.PasswordFor(expression, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.PasswordFor(expression, new { @class = "form-control" });
            }

            var description = expression.GetDescription();
            var descriptionHtml = description == null ? string.Empty : $"<small class=\"text-muted\">{description}</small>";

            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-group\">");

            returnWriter.AppendHtml(label);
            returnWriter.AppendHtml(input);

            if (description != string.Empty)
            {
                returnWriter.AppendHtml(descriptionHtml);
            }

            returnWriter.AppendHtml("</div>");

            return returnWriter;
        }

        public static IHtmlContent BootstrapTextAreaFor<TModel, TProperty>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isReadOnly = false)
        {
            var label = helper.LabelFor(expression, new { @for = helper.IdFor(expression) });

            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.TextAreaFor(expression, new { @readonly = "readonly", @class = "form-control" });
            }
            else
            {
                input = helper.TextAreaFor(expression, new { @class = "form-control" });
            }

            var description = expression.GetDescription();
            var descriptionHtml = description == null ? string.Empty : $"<small class=\"text-muted\">{description}</small>";

            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-group\">");

            returnWriter.AppendHtml(label);
            returnWriter.AppendHtml(input);

            if (description != string.Empty)
            {
                returnWriter.AppendHtml(descriptionHtml);
            }

            returnWriter.AppendHtml("</div>");

            return returnWriter;
        }

        public static IHtmlContent BootstrapCheckboxFor<TModel>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, bool>> expression,
            bool isReadOnly = false)
        {
            var data = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData,
                helper.MetadataProvider);

            var labelText = data.Metadata.DisplayName ?? data.Metadata.PropertyName;

            IHtmlContent input;
            if (isReadOnly)
            {
                input = helper.CheckBoxFor(expression, new { @readonly = "readonly", @class = "form-check-input" });
            }
            else
            {
                input = helper.CheckBoxFor(expression, new { @class = "form-check-input" });
            }

            var description = expression.GetDescription();
            var descriptionHtml = description == null ? string.Empty : $"<small class=\"text-muted\">{description}</small>";



            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-check\">");

            returnWriter.AppendHtml("<label class=\"form-check-label\">");

            returnWriter.AppendHtml(input);

            returnWriter.AppendHtml($" {labelText}</label>");

            if (description != string.Empty)
            {
                returnWriter.AppendHtml(descriptionHtml);
            }

            returnWriter.AppendHtml("</div>");

            return returnWriter;
        }

        public static IHtmlContent BootstrapRadioButtonGroupFor<TModel, TProperty, TDisplay>(
            this IHtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<TProperty, TDisplay> options,
            bool isReadOnly = false,
            string buttonClass = "btn btn-default")
        {
            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml($"<div class=\"form-group\">");
            returnWriter.AppendHtml(helper.LabelFor(expression, new { @for = helper.IdFor(expression) }));
            returnWriter.AppendHtml($"<p><div class=\"btn-group\" data-toggle=\"buttons\" id=\"{helper.IdFor(expression)}InputGroup\">");

            var classes = isReadOnly ? $"{buttonClass} disabled" : buttonClass;
            foreach (var option in options)
            {
                if (Equals(helper.ValueFor(expression), option.Key.ToString()))
                {
                    returnWriter.AppendHtml($"<label name=\"{helper.IdFor(expression)}Label\" class=\"{classes} active\" onclick=\"{helper.IdFor(expression)}_HandleUpdateFor();\">");
                }
                else
                {
                    returnWriter.AppendHtml($"<label name=\"{helper.IdFor(expression)}Label\" class=\"{classes}\" onclick=\"{helper.IdFor(expression)}_HandleUpdateFor();\">");
                }
                returnWriter.AppendHtml(helper.RadioButtonFor(expression, option.Key));
                returnWriter.AppendHtml(option.Value.ToString());
                returnWriter.AppendHtml($"</label>");
            }
            returnWriter.AppendHtml($"</div></p>");
            var description = expression.GetDescription();
            returnWriter.AppendHtml(description == null ? string.Empty : $"<small class=\"text-muted\">{description}</small>");
            returnWriter.AppendHtml($"</div>");
            returnWriter.AppendHtml($"<script type=\"text/javascript\">function {helper.IdFor(expression)}_HandleUpdateFor(){{$('input[name={helper.IdFor(expression)}]:checked').removeAttr('checked');$('label[name={helper.IdFor(expression)}Label)].active').find('input').attr('checked', 'checked');}}</script>");

            return returnWriter;
        }

        public static IHtmlContent BootstrapButtonActionLink<TModel>(
            this IHtmlHelper<TModel> helper,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues = null,
            bool isEnabled = true,
            string classes = "btn btn-primary",
            IDictionary<string, object> htmlAttributes = null)
        {
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }

            if (!htmlAttributes.ContainsKey("class"))
            {
                if (isEnabled)
                {
                    htmlAttributes["class"] = classes;
                }
                else
                {
                    htmlAttributes["class"] = classes + " disabled";
                }

            }

            return helper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes); ;
        }

    }
}

using System.Linq.Expressions;
using HelpfulThings.Markup.Bootstrap3.Forms.DatePicker;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

// ReSharper disable once CheckNamespace
namespace System.Web.Mvc.Html
{
    public static class QuickBootstrapFormsDatePicker
    {
        public static IHtmlContent BootstrapDatetimePickerFor<TModel, TProperty>(
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
            var descriptionHtml = description == null ? string.Empty : $"<small class=\"form-text text-muted\">{description}</small>";

            var returnWriter = new HtmlContentBuilder();

            returnWriter.AppendHtml("<div class=\"form-group\">");
            returnWriter.AppendHtml(label);
            returnWriter.AppendHtml($"<div class=\"input-group date\" id=\"{helper.IdFor(expression)}DatetimePicker\">");
            returnWriter.AppendHtml(input);
            returnWriter.AppendHtml("<span class=\"input-group-addon\"><span class=\"glyphicon glyphicon-calendar\"></span></span>");
            returnWriter.AppendHtml("</div>");
            returnWriter.AppendHtml(descriptionHtml);
            returnWriter.AppendHtml("</div>");
            returnWriter.AppendHtml($"<script type=\"text/javascript\">$(function(){{$(\"#{helper.IdFor(expression)}DatetimePicker\").datetimepicker();}});</script>");

            return returnWriter;
        }
    }
}
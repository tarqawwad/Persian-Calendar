using System;
using System.Text;
using System.Web.Mvc;
using System.Globalization;

namespace PersianCalendarComponents.Components
{
    public static class TADatePickerComponents
    {
        public static MvcHtmlString TADatePicker(this HtmlHelper htmlHelper, string componentName, DateTime? value, object htmlattribute, string onChange, bool IsRequired = false, DateTime? minValue = null, DateTime? maxValue = null)
        {
            return GenerateDatePickerPersian(componentName, IsRequired, htmlattribute, value, minValue, maxValue, onChange);
        }
    
        private static MvcHtmlString GenerateDatePickerPersian(string componentName, bool IsRequired = false, object htmlattribute = null, DateTime? value = null, DateTime? minValue = null, DateTime? maxValue = null, string onChange = "")
        {
            // Generate Random ID
            Random rnd = new Random();
            var _id = "TA_" + rnd.Next().ToString();

            // Generate Parent Div for Inputs
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("TA-datepicker");

            // Generate Persian Date and Label As title
            #region Label and Persian Date
            TagBuilder LabelPersian = new TagBuilder("label");
            LabelPersian.InnerHtml += "Persian Date";
            LabelPersian.AddCssClass("text-center");


            TagBuilder inputPersian = new TagBuilder("input");
            inputPersian.GenerateId("PersianCalendar_" + _id);
            inputPersian.AddCssClass("form-control");
            inputPersian.MergeAttribute("readonly", "readonly");
            inputPersian.MergeAttribute("type", "text");
            if (value != null)
            {
                var calendar = new PersianCalendar();
                var persianDate = new DateTime(calendar.GetYear(value.Value), calendar.GetMonth(value.Value), calendar.GetDayOfMonth(value.Value));
                inputPersian.MergeAttribute("value", persianDate.ToString("yyyy/MM/dd"));
            }

            #region Attributes 
            if (IsRequired)
            {
                inputPersian.MergeAttribute("data-val", "true");
                inputPersian.MergeAttribute("data-val-required", "This field is required.");
            }
            var rvd = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlattribute);
            foreach (var item in rvd)
            {
                inputPersian.MergeAttribute(item.Key, item.Value.ToString());
            }
            inputPersian.MergeAttribute("autocomplete", "off");
            #endregion

            #endregion

            // Generate Gregorien Date and Label As title
            #region Label and Gregoren Input
            TagBuilder LabelGregoren = new TagBuilder("label");
            LabelGregoren.InnerHtml += "Gregoren Date";
            LabelGregoren.AddCssClass("text-center");

            TagBuilder inputGregoren = new TagBuilder("input");
            inputGregoren.GenerateId("PersianCalenderHidden_" + _id);
            inputGregoren.AddCssClass("form-control");
            inputGregoren.MergeAttribute("type", "text");
            inputGregoren.MergeAttribute("readonly", "readonly");
            inputGregoren.MergeAttribute("name", componentName);
            if (value != null)
            {
                var persianDate = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day);
                inputGregoren.MergeAttribute("value", persianDate.ToString("yyyy/MM/dd"));
            }
            #endregion

            // Prepare Script from Persian Date Jquery
            #region Prepare Script 
            StringBuilder sb = new StringBuilder();

            sb.Append("<script>");
            sb.Append("$('#PersianCalendar_" + _id + "')");
            sb.Append(".persianDatepicker({");

            #region Options
            string id = "#" + _id;
            sb.Append("CalendarID:'" + id + "'");
            sb.Append(",alwaysShow:0");

            // Convert From Persian Date to Gregorien Date
            string onSelect = "function () { var pd = new persianDate();var value = pd.parse($('#PersianCalendar_" + _id + "').val());var converterDate = new jDateFunctions();$('#" + "PersianCalenderHidden_" + _id + "').val(converterDate.getGDate(value)._toString('YYYY/MM/DD'));" + onChange + "}";
            sb.Append(",onSelect:" + onSelect + "");

            if (minValue != null) { sb.Append(",startDate:'" + minValue + "'"); } else { sb.Append(",startDate:null"); }
            if (maxValue != null) { sb.Append(",endDate:'" + maxValue + "'"); } else { sb.Append(",endDate:null"); }
            if (value != null)
            {
                var calendar = new PersianCalendar();
                var persianDate = new DateTime(calendar.GetYear(value.Value), calendar.GetMonth(value.Value), calendar.GetDayOfMonth(value.Value));

                sb.Append(",selectedDate:'" + persianDate.ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                sb.Append(",selectedDate:null");
            }
            sb.Append(",formatDate:'YYYY/MM/DD'");
            #endregion

            sb.Append("});");
            sb.Append("</script>");
            string Script = sb.ToString();
            #endregion


            // Render all controls in parent div
            container.InnerHtml += LabelPersian;
            container.InnerHtml += inputPersian;
            container.InnerHtml += LabelGregoren;
            container.InnerHtml += inputGregoren;
            container.InnerHtml += Script;

            return MvcHtmlString.Create(container.ToString());
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MCS.Web.Framework
{
    [HtmlTargetElement("enums")]
    //[HtmlTargetElement("enums", TagStructure = TagStructure.WithoutEndTag)]
    public class EnumsTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-enum")]
        public Enum Value { get; set; }


        [HtmlAttributeName("asp-value")]
        public string SelectedValue { get; set; }


        [HtmlAttributeName("asp-id")]
        public string Id { get; set; }

        [HtmlAttributeName("asp-href")]
        public string DataHref { get; set; }


        [HtmlAttributeName("asp-valuetype")]
        public int ValueIsIndex { get; set; } = 2;

        /// <summary>
        /// 将Enum转换为List<SelectListItem>
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetEnumSelectListItem()
        {
            var list = new List<SelectListItem>();
            var typeInfo = Value.GetType().GetTypeInfo();
            var enumValues = typeInfo.GetEnumValues();

            foreach (var value in enumValues)
            {

                MemberInfo memberInfo =
                    typeInfo.GetMember(value.ToString()).First();


                var descriptionAttribute =
                    memberInfo.GetCustomAttribute<DescriptionAttribute>();

                list.Add(new SelectListItem()
                {
                    Text = descriptionAttribute.Description,
                    Value = (ValueIsIndex == 1) ? ((int)value).ToString() : value.ToString()
                });

            }
            return list;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var list = GetEnumSelectListItem();
            output.TagName = "select";
            output.Attributes.SetAttribute("id", Id);
            output.Attributes.SetAttribute("data-href", DataHref);
            var content = output.GetChildContentAsync();
            output.Content.AppendHtml(content.Result);
            foreach (var item in list)
            {
                if (item.Value != null)
                {
                    if (item.Value == SelectedValue)
                    {
                        output.Content.AppendHtml($"<option value='{item.Value}' selected='selected'>{item.Text}</option>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<option value='{item.Value}'>{item.Text}</option>");
                    }
                }
                else
                {
                    if (item.Text == SelectedValue)
                    {
                        output.Content.AppendHtml($"<option selected='selected'>{item.Text}</option>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<option>{item.Text}</option>");
                    }
                }
            }
            //output.Content.AppendHtml("<select/>");
        }
    }
}

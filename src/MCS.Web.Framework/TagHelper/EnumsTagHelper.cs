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
    /// <summary>
    /// 枚举下拉列表
    /// </summary>
    [HtmlTargetElement("select", Attributes = "enums")]
    public class EnumsTagHelper : TagHelper
    {

        public int Enums { get; set; }

        [HtmlAttributeName("asp-for")]
        public Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression For { get; set; }

        /// <summary>
        /// 将Enum转换为List<SelectListItem>
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetEnumSelectListItem()
        {
            var list = new List<SelectListItem>();
            var typeInfo = For.Model.GetType().GetTypeInfo();
            var enumValues = typeInfo.GetEnumValues();

            foreach (var value in enumValues)
            {

                MemberInfo memberInfo = typeInfo.GetMember(value.ToString()).First();

                var descriptionAttribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();

                list.Add(new SelectListItem()
                {
                    Text = descriptionAttribute.Description,
                    Value = (Enums == 1) ? ((int)value).ToString() : value.ToString()
                });

            }
            return list;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var list = GetEnumSelectListItem();

            output.TagName = "select";

            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);

            var content = output.GetChildContentAsync();
            output.Content.AppendHtml(content.Result);
            foreach (var item in list)
            {
                if (item.Value != null)
                {
                    if (item.Value == For.Model.GetHashCode().ToString())
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
                    if (item.Text == For.Model.GetHashCode().ToString())
                    {
                        output.Content.AppendHtml($"<option selected='selected'>{item.Text}</option>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<option>{item.Text}</option>");
                    }
                }
            }
        }
    }
}

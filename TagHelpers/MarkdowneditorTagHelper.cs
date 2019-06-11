using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Blog.TagHelpers
{
    public class MarkdowneditorTagHelper : TagHelper
    {

        public ModelExpression For { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) 
        {
            output.TagName = "textarea";

            var content = await output.GetChildContentAsync();
            var markdown = content.GetContent();

            Guid formId = Guid.NewGuid();

            output.Attributes.SetAttribute("id", formId);
            output.Attributes.SetAttribute("name", For.Name);

            output.Content.SetContent(markdown);

            string js = $"<script> var easyMDE = new SimpleMDE({{element: document.getElementById('{ formId }')}}) </script>";
            //string js = String.Format("The current price is {0} per ounce.", formId);


            output.PostElement.AppendHtml(js);


        }
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;
using Markdig;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.TagHelpers
{
    public class MarkdownTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";

            var content = await output.GetChildContentAsync();
            var markdown = content.GetContent();

            output.Content.SetHtmlContent(Markdown.ToHtml(markdown));
        }
    }
}
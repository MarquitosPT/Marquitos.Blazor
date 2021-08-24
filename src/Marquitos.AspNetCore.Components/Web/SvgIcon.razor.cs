using Marquitos.AspNetCore.Components.JSInterop;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace Marquitos.AspNetCore.Components.Web
{
    /// <summary>
    /// Icon component
    /// </summary>
    public partial class SvgIcon : ComponentBase
    {
        /// <summary>
        /// SVG source file
        /// </summary>
        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        private IJSFile JSFile { get; set; }

        private MarkupString Content { get; set; }

        private string ViewBox { get; set; } = "0 0 16 16";

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrWhiteSpace(Source))
            {
                Content = default;
            }
            else
            {
                if (Content.Value == null)
                {
                    if (!Source.ToLower().EndsWith(".svg"))
                    {
                        throw new Exception("The icon source must be a valid SVG file.");
                    }

                    await LoadContentAsync(Source);
                }
            }

            await base.OnInitializedAsync();
        }

        private async Task LoadContentAsync(string uri)
        {
            try
            {
                var xml = await JSFile.LoadAsync(uri);

                if (!string.IsNullOrWhiteSpace(xml))
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(xml);

                    var elem = doc.DocumentElement;

                    if (elem != null && !string.IsNullOrWhiteSpace(elem.InnerXml))
                    {
                        var viewBoxAttribute = elem.GetAttribute("viewBox");

                        if (!string.IsNullOrWhiteSpace(viewBoxAttribute))
                        {
                            ViewBox = viewBoxAttribute;
                        }
                        else
                        {
                            ViewBox = "0 0 24 24";
                        }

                        Content = new MarkupString(elem.InnerXml);
                    }
                    else
                    {
                        Content = default;
                    }
                }
                else
                {
                    Content = default;
                }
            }
            catch (Exception)
            {
                Content = default;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface INavigationViewItem
    {
        string Uri { get; }
        public bool Enabled { get; set; }
        RenderFragment ChildContent { get; }
        RenderFragment Content { get; }
    }
}

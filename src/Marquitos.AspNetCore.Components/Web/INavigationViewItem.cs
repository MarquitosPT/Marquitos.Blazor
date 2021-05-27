using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquitos.AspNetCore.Components.Web
{
    public interface INavigationViewItem
    {
        string Uri { get; }
        public bool Enabled { get; set; }
    }
}

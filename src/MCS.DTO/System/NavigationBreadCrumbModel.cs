using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO
{
    public class NavigationBreadCrumbModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public NavigationBreadCrumbModel Children { get; set; }
        public NavigationBreadCrumbModel Parent { get; set; }
    }
}

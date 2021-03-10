using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO
{
    public class ManagerNavigationBreadCrumbModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ManagerNavigationBreadCrumbModel Children { get; set; }
        public ManagerNavigationBreadCrumbModel Parent { get; set; }
    }
}

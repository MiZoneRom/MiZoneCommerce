using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO
{
    public class NavigationModel
    {

        public long Id { get; set; }

        public long ParentId { get; set; }

        public int? Type { get; set; }

        public string Name { get; set; }

        public string SubTitle { get; set; }

        public string Icon { get; set; }

        public string Path { get; set; }

        public int PathType { get; set; }

        public string Component { get; set; }

        public int SortId { get; set; }

        public int Status { get; set; }

        public string Remark { get; set; }

		public List<NavigationModel> Children { get; set; }

    }
}

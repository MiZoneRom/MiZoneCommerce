using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO
{
    public class Navigation
    {
        public long Id { get; set; }

        public long ParentId { get; set; }

        public int? Type { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        public int SortId { get; set; }

        public bool IsLock { get; set; }

        public string Remark { get; set; }

        public int ActionType { get; set; }

        public bool IsSys { get; set; }

        public bool IsHidden { get; set; }

        public List<Navigation> Children { get; set; }

    }
}

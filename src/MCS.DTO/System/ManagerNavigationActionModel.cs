using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.DTO
{
    public class ManagerNavigationActionModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// NavigationId
        /// </summary>
        public long NavigationId { get; set; }

        /// <summary>
        /// ActionId
        /// </summary>
        public long ActionId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool Selected { get; set; }
    }
}

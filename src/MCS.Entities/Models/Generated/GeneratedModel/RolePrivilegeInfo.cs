
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.RolePrivilege")]
     public partial class RolePrivilegeInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// Privilege
        /// </summary>
		[Column(name: "Privilege", isColumn: true)]
		public int Privilege { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		[Column(name: "RoleId", isColumn: true)]
		public long RoleId { get; set; }
        
     }

}



using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Role")]
     public partial class RoleInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleName
        /// </summary>
		[Column(name: "RoleName", isColumn: true)]
		public string RoleName { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		[Column(name: "Description", isColumn: true)]
		public string Description { get; set; }
        
     }

}


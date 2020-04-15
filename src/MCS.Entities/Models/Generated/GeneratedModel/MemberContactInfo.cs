
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberContact")]
     public partial class MemberContactInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		[Column(name: "UserId", isColumn: true)]
		public long UserId { get; set; }
        
		/// <summary>
        /// UserType
        /// </summary>
		[Column(name: "UserType", isColumn: true)]
		public int UserType { get; set; }
        
		/// <summary>
        /// ServiceProvider
        /// </summary>
		[Column(name: "ServiceProvider", isColumn: true)]
		public string ServiceProvider { get; set; }
        
		/// <summary>
        /// Contact
        /// </summary>
		[Column(name: "Contact", isColumn: true)]
		public string Contact { get; set; }
        
     }

}


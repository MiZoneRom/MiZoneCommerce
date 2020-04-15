
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberOpenId")]
     public partial class MemberOpenIdInfo
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
        /// OpenId
        /// </summary>
		[Column(name: "OpenId", isColumn: true)]
		public string OpenId { get; set; }
        
		/// <summary>
        /// UnionOpenId
        /// </summary>
		[Column(name: "UnionOpenId", isColumn: true)]
		public string UnionOpenId { get; set; }
        
		/// <summary>
        /// UnionId
        /// </summary>
		[Column(name: "UnionId", isColumn: true)]
		public string UnionId { get; set; }
        
		/// <summary>
        /// ServiceProvider
        /// </summary>
		[Column(name: "ServiceProvider", isColumn: true)]
		public string ServiceProvider { get; set; }
        
		/// <summary>
        /// AppIdType
        /// </summary>
		[Column(name: "AppIdType", isColumn: true)]
		public int AppIdType { get; set; }
        
     }

}


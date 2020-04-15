
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.OpenId")]
     public partial class OpenIdInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// OpenId
        /// </summary>
		[Column(name: "OpenId",  isColumn: true)]
		public string OpenId { get; set; }

        
		/// <summary>
        /// SubscribeTime
        /// </summary>
		[Column(name: "SubscribeTime",  isColumn: true)]
		public DateTime SubscribeTime { get; set; }

        
		/// <summary>
        /// IsSubscribe
        /// </summary>
		[Column(name: "IsSubscribe",  isColumn: true)]
		public bool IsSubscribe { get; set; }

        
     }

}


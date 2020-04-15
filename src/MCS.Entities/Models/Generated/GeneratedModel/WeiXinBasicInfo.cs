
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinBasic")]
     public partial class WeiXinBasicInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// Ticket
        /// </summary>
		[Column(name: "Ticket",  isColumn: true)]
		public string Ticket { get; set; }

        
		/// <summary>
        /// TicketOutTime
        /// </summary>
		[Column(name: "TicketOutTime",  isColumn: true)]
		public DateTime TicketOutTime { get; set; }

        
		/// <summary>
        /// AppId
        /// </summary>
		[Column(name: "AppId",  isColumn: true)]
		public string AppId { get; set; }

        
		/// <summary>
        /// AccessToken
        /// </summary>
		[Column(name: "AccessToken",  isColumn: true)]
		public string AccessToken { get; set; }

        
     }

}


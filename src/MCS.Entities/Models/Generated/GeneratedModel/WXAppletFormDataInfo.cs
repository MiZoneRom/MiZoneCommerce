
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WXAppletFormData")]
     public partial class WXAppletFormDataInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// EventId
        /// </summary>
		[Column(name: "EventId", isColumn: true)]
		public long EventId { get; set; }
        
		/// <summary>
        /// EventValue
        /// </summary>
		[Column(name: "EventValue", isColumn: true)]
		public string EventValue { get; set; }
        
		/// <summary>
        /// FormId
        /// </summary>
		[Column(name: "FormId", isColumn: true)]
		public string FormId { get; set; }
        
		/// <summary>
        /// EventTime
        /// </summary>
		[Column(name: "EventTime", isColumn: true)]
		public DateTime EventTime { get; set; }
        
		/// <summary>
        /// ExpireTime
        /// </summary>
		[Column(name: "ExpireTime", isColumn: true)]
		public DateTime ExpireTime { get; set; }
        
     }

}


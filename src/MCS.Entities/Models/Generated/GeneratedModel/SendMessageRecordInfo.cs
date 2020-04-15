
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.SendMessageRecord")]
     public partial class SendMessageRecordInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// MessageType
        /// </summary>
		[Column(name: "MessageType", isColumn: true)]
		public int MessageType { get; set; }
        
		/// <summary>
        /// ContentType
        /// </summary>
		[Column(name: "ContentType", isColumn: true)]
		public int ContentType { get; set; }
        
		/// <summary>
        /// SendContent
        /// </summary>
		[Column(name: "SendContent", isColumn: true)]
		public string SendContent { get; set; }
        
		/// <summary>
        /// ToUserLabel
        /// </summary>
		[Column(name: "ToUserLabel", isColumn: true)]
		public string ToUserLabel { get; set; }
        
		/// <summary>
        /// SendState
        /// </summary>
		[Column(name: "SendState", isColumn: true)]
		public int SendState { get; set; }
        
		/// <summary>
        /// SendTime
        /// </summary>
		[Column(name: "SendTime", isColumn: true)]
		public DateTime SendTime { get; set; }
        
     }

}


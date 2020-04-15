
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MessageLog")]
     public partial class MessageLogInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// UserId
        /// </summary>
		[Column(name: "UserId",  isColumn: true)]
		public long UserId { get; set; }

        
		/// <summary>
        /// TypeId
        /// </summary>
		[Column(name: "TypeId",  isColumn: true)]
		public string TypeId { get; set; }

        
		/// <summary>
        /// MessageContent
        /// </summary>
		[Column(name: "MessageContent",  isColumn: true)]
		public string MessageContent { get; set; }

        
		/// <summary>
        /// CreateDate
        /// </summary>
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate { get; set; }

        
     }

}


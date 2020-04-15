
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinMsgTemplate")]
     public partial class WeiXinMsgTemplateInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// MessageType
        /// </summary>
		[Column(name: "MessageType",  isColumn: true)]
		public int MessageType { get; set; }

        
		/// <summary>
        /// TemplateNum
        /// </summary>
		[Column(name: "TemplateNum",  isColumn: true)]
		public string TemplateNum { get; set; }

        
		/// <summary>
        /// TemplateId
        /// </summary>
		[Column(name: "TemplateId",  isColumn: true)]
		public string TemplateId { get; set; }

        
		/// <summary>
        /// UpdateDate
        /// </summary>
		[Column(name: "UpdateDate",  isColumn: true)]
		public DateTime UpdateDate { get; set; }

        
		/// <summary>
        /// IsOpen
        /// </summary>
		[Column(name: "IsOpen",  isColumn: true)]
		public bool IsOpen { get; set; }

        
		/// <summary>
        /// UserInWxApplet
        /// </summary>
		[Column(name: "UserInWxApplet",  isColumn: true)]
		public bool UserInWxApplet { get; set; }

        
     }

}


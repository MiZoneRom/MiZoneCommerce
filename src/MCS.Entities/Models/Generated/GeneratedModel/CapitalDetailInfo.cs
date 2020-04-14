
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.CapitalDetail")]
     public partial class CapitalDetailInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "CapitalId",  isColumn: true)]
		public long CapitalId {get;set;}

        
		[Column(name: "SourceType",  isColumn: true)]
		public int SourceType {get;set;}

        
		[Column(name: "Amount",  isColumn: true)]
		public decimal Amount {get;set;}

        
		[Column(name: "SourceData",  isColumn: true)]
		public string SourceData {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate {get;set;}

        
		[Column(name: "Remark",  isColumn: true)]
		public string Remark {get;set;}

        
		[Column(name: "PresentAmount",  isColumn: true)]
		public decimal PresentAmount {get;set;}

        
     }

}



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
        
        		public long Id {get;set;}
        		public long CapitalId {get;set;}
        		public int SourceType {get;set;}
        		public decimal Amount {get;set;}
        		public string SourceData {get;set;}
        		public DateTime CreateDate {get;set;}
        		public string Remark {get;set;}
        		public decimal PresentAmount {get;set;}
        
     }

}


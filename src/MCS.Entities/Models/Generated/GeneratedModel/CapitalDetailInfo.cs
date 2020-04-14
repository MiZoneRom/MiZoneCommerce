
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.CapitalDetail")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class CapitalDetailInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long CapitalId {get;set;}
        [Column] public int SourceType {get;set;}
        [Column] public decimal Amount {get;set;}
        [Column] public string SourceData {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        [Column] public decimal PresentAmount {get;set;}
        
     }

}


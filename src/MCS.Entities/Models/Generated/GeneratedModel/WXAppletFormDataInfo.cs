
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WXAppletFormData")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WXAppletFormDataInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long EventId {get;set;}
        [Column] public string EventValue {get;set;}
        [Column] public string FormId {get;set;}
        [Column] public DateTime EventTime {get;set;}
        [Column] public DateTime ExpireTime {get;set;}
        
     }

}


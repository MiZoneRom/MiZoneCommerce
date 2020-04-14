
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Capital")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class CapitalInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public decimal Balance {get;set;}
        [Column] public decimal FreezeAmount {get;set;}
        [Column] public decimal ChargeAmount {get;set;}
        [Column] public decimal PresentAmount {get;set;}
        
     }

}


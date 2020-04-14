
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouse")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Name {get;set;}
        [Column] public DateTime? CreateDate {get;set;}
        
     }

}


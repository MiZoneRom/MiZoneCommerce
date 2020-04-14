
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseAddress")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseAddressInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long WareHouseId {get;set;}
        [Column] public string AddressName {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }

}


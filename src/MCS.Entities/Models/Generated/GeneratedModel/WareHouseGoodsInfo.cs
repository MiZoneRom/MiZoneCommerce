
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseGoods")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseGoodsInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long WareHouseId {get;set;}
        [Column] public string Name {get;set;}
        [Column] public long CategoryId {get;set;}
        [Column] public int Quantity {get;set;}
        [Column] public string MeasureUnit {get;set;}
        [Column] public long AddressId {get;set;}
        [Column] public long SourceId {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }

}


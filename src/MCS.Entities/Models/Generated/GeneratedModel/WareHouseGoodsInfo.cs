
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseGoods")]
     public partial class WareHouseGoodsInfo
     {
        
        		public long Id {get;set;}
        		public long WareHouseId {get;set;}
        		public string Name {get;set;}
        		public long CategoryId {get;set;}
        		public int Quantity {get;set;}
        		public string MeasureUnit {get;set;}
        		public long AddressId {get;set;}
        		public long SourceId {get;set;}
        		public DateTime CreateDate {get;set;}
        
     }

}


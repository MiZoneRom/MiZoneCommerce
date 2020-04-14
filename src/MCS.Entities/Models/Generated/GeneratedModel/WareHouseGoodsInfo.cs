
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "WareHouseId",  isColumn: true)]
		public long WareHouseId {get;set;}

        
		[Column(name: "Name",  isColumn: true)]
		public string Name {get;set;}

        
		[Column(name: "CategoryId",  isColumn: true)]
		public long CategoryId {get;set;}

        
		[Column(name: "Quantity",  isColumn: true)]
		public int Quantity {get;set;}

        
		[Column(name: "MeasureUnit",  isColumn: true)]
		public string MeasureUnit {get;set;}

        
		[Column(name: "AddressId",  isColumn: true)]
		public long AddressId {get;set;}

        
		[Column(name: "SourceId",  isColumn: true)]
		public long SourceId {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate {get;set;}

        
     }

}


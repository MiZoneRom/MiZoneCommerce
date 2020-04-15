
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
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// 仓库ID
        /// </summary>
		[Column(name: "WareHouseId",  isColumn: true)]
		public long WareHouseId { get; set; }

        
		/// <summary>
        /// 物品名称
        /// </summary>
		[Column(name: "Name",  isColumn: true)]
		public string Name { get; set; }

        
		/// <summary>
        /// 分类ID
        /// </summary>
		[Column(name: "CategoryId",  isColumn: true)]
		public long CategoryId { get; set; }

        
		/// <summary>
        /// 数量
        /// </summary>
		[Column(name: "Quantity",  isColumn: true)]
		public int Quantity { get; set; }

        
		/// <summary>
        /// 计量单位
        /// </summary>
		[Column(name: "MeasureUnit",  isColumn: true)]
		public string MeasureUnit { get; set; }

        
		/// <summary>
        /// 地址ID
        /// </summary>
		[Column(name: "AddressId",  isColumn: true)]
		public long AddressId { get; set; }

        
		/// <summary>
        /// 来源ID
        /// </summary>
		[Column(name: "SourceId",  isColumn: true)]
		public long SourceId { get; set; }

        
		/// <summary>
        /// 创建日期
        /// </summary>
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate { get; set; }

        
     }

}


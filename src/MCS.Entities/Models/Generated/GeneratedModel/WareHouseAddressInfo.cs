
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseAddress")]
     public partial class WareHouseAddressInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// WareHouseId
        /// </summary>
		[Column(name: "WareHouseId",  isColumn: true)]
		public long WareHouseId { get; set; }

        
		/// <summary>
        /// AddressName
        /// </summary>
		[Column(name: "AddressName",  isColumn: true)]
		public string AddressName { get; set; }

        
		/// <summary>
        /// CreateDate
        /// </summary>
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate { get; set; }

        
     }

}


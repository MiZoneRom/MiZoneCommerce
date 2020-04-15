
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouse")]
     public partial class WareHouseInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// Name
        /// </summary>
		[Column(name: "Name",  isColumn: true)]
		public string Name { get; set; }

        
		/// <summary>
        /// CreateDate
        /// </summary>
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime? CreateDate { get; set; }

        
     }

}


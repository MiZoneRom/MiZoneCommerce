
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "Name",  isColumn: true)]
		public string Name {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime? CreateDate {get;set;}

        
     }

}


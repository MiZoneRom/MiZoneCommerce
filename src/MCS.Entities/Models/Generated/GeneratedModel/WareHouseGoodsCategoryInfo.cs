
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseGoodsCategory")]
     public partial class WareHouseGoodsCategoryInfo
     {
        
        		public long Id {get;set;}
        		public string Name {get;set;}
        		public DateTime CreateDate {get;set;}
        
     }

}


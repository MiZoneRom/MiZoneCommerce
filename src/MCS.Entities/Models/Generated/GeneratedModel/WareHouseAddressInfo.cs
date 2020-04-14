
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
        
        		public long Id {get;set;}
        		public long WareHouseId {get;set;}
        		public string AddressName {get;set;}
        		public DateTime CreateDate {get;set;}
        
     }

}


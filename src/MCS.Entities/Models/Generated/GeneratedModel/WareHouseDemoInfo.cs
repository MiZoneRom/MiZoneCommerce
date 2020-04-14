
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseDemo")]
     public partial class WareHouseDemoInfo
     {
        
        		public string No {get;set;}
        		public string ImgUrl {get;set;}
        		public string Name {get;set;}
        		public string CateName {get;set;}
        		public string Spec {get;set;}
        		public string Num {get;set;}
        		public string Address {get;set;}
        		public string Source {get;set;}
        
     }

}


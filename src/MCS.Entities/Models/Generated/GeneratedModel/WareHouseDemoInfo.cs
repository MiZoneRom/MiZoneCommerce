
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WareHouseDemo")]
     [ExplicitColumns]
     public partial class WareHouseDemoInfo
     {
        
        [Column] public string No {get;set;}
        [Column] public string ImgUrl {get;set;}
        [Column] public string Name {get;set;}
        [Column] public string CateName {get;set;}
        [Column] public string Spec {get;set;}
        [Column] public string Num {get;set;}
        [Column] public string Address {get;set;}
        [Column] public string Source {get;set;}
        
     }

}


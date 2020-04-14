
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
        
        
		[Column(name: "No",  isColumn: true)]
		public string No {get;set;}

        
		[Column(name: "ImgUrl",  isColumn: true)]
		public string ImgUrl {get;set;}

        
		[Column(name: "Name",  isColumn: true)]
		public string Name {get;set;}

        
		[Column(name: "CateName",  isColumn: true)]
		public string CateName {get;set;}

        
		[Column(name: "Spec",  isColumn: true)]
		public string Spec {get;set;}

        
		[Column(name: "Num",  isColumn: true)]
		public string Num {get;set;}

        
		[Column(name: "Address",  isColumn: true)]
		public string Address {get;set;}

        
		[Column(name: "Source",  isColumn: true)]
		public string Source {get;set;}

        
     }

}


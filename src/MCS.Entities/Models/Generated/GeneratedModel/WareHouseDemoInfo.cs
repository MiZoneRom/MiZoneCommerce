
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
        
		/// <summary>
        /// No
        /// </summary>
		[Column(name: "No", isColumn: true)]
		public string No { get; set; }
        
		/// <summary>
        /// ImgUrl
        /// </summary>
		[Column(name: "ImgUrl", isColumn: true)]
		public string ImgUrl { get; set; }
        
		/// <summary>
        /// Name
        /// </summary>
		[Column(name: "Name", isColumn: true)]
		public string Name { get; set; }
        
		/// <summary>
        /// CateName
        /// </summary>
		[Column(name: "CateName", isColumn: true)]
		public string CateName { get; set; }
        
		/// <summary>
        /// Spec
        /// </summary>
		[Column(name: "Spec", isColumn: true)]
		public string Spec { get; set; }
        
		/// <summary>
        /// Num
        /// </summary>
		[Column(name: "Num", isColumn: true)]
		public string Num { get; set; }
        
		/// <summary>
        /// Address
        /// </summary>
		[Column(name: "Address", isColumn: true)]
		public string Address { get; set; }
        
		/// <summary>
        /// Source
        /// </summary>
		[Column(name: "Source", isColumn: true)]
		public string Source { get; set; }
        
     }

}


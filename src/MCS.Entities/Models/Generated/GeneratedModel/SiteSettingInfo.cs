
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "SiteSetting")]
     public partial class SiteSettingInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Key
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Key")]
		public string Key { get; set; }
        
		/// <summary>
        /// Value
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Value")]
		public string Value { get; set; }
        
     }

}


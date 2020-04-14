
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberContact")]
     public partial class MemberContactInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public int UserType {get;set;}
        		public string ServiceProvider {get;set;}
        		public string Contact {get;set;}
        
     }

}


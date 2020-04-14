
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberOpenId")]
     public partial class MemberOpenIdInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public string OpenId {get;set;}
        		public string UnionOpenId {get;set;}
        		public string UnionId {get;set;}
        		public string ServiceProvider {get;set;}
        		public int AppIdType {get;set;}
        
     }

}


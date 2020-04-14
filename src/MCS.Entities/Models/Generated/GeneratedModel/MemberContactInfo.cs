
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberContact")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberContactInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public int UserType {get;set;}
        [Column] public string ServiceProvider {get;set;}
        [Column] public string Contact {get;set;}
        
     }

}


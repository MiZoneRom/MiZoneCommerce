
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberGroup")]
     public partial class MemberGroupInfo
     {
        
        		public long Id {get;set;}
        		public int StatisticsType {get;set;}
        		public int Total {get;set;}
        
     }

}


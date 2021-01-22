using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.AdminAPI.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class LoginController : BaseAdminAPIController
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}

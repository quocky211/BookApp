using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookAPI.Controllers
{
    public class XulyController : ApiController
    {
        [Route("api/book/LayDsBook")]
        [HttpGet]
        public IHttpActionResult LayDSBook()
        {
            try
            {
                DataTable tb = Database.LayDsBook();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

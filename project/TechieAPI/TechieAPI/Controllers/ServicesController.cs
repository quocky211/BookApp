using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechieAPI.Models;

namespace TechieAPI.Controllers
{
    public class ServicesController : ApiController
    {
        [Route("api/product/ListProduct")]
        [HttpGet]
        public IHttpActionResult ListProduct()
        {
            try
            {
                DataTable tb = Database.ListProduct();

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/ListProductByType")]
        [HttpGet]
        public IHttpActionResult ListProductByType(int loai)
        {
            try
            {
                DataTable tb = Database.LstProductByType(loai);

                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/ThemUser")]
        [HttpPost]
        public IHttpActionResult ThemUser(User user)
        {
            try
            {
                User kq = Database.ThemUser(user);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/UserLogin")]
        [HttpGet]
        public IHttpActionResult UserLogin(string TENDN, string MATKHAU)
        {
            try
            {
                User user = Database.UserLogin(TENDN, MATKHAU);

                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/AddOrder")]
        [HttpPost]
        public IHttpActionResult AddOrder(Order order)
        {
            try
            {
                int kq = Database.AddOrder(order);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

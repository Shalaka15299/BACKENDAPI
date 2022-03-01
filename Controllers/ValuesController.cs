using BACKENDAPI.Data;
using BACKENDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserDbContext _context;
        public ValuesController(UserDbContext userdbcontext)
        {
            _context=userdbcontext;
        }

        [HttpPost("addorder")]
        public IActionResult AddOrder([FromBody] Ordermodel orderObj)
        {
            if (orderObj == null)
            {
                return BadRequest();
            }
            else
            {                
                orderObj.createdAt = DateTime.Now;
                orderObj.updatedAt = DateTime.Now;


                _context.orderModels.Add(orderObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Order Added Successfully"
                });
            }
        }

        [HttpGet("getallorders")]
        public IActionResult GetAllorders()
        {
            var orderdetails = _context.orderModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                OrderDetails = orderdetails
            });
        }

        [HttpGet("getalldata")]
        public IActionResult GetOrders()
        {
            var order = _context.orderModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                orderData = order
            });
        }

        //[HttpGet("getalldata")]
        //public IActionResult GetOrders()
        //{
        //    var order = _context.orderModels.AsQueryable();
        //    return Ok(new
        //    {
        //        StatusCode = 200,
        //        orderData = order
        //    });
        //}
    }
}

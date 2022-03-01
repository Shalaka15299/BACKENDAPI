using BACKENDAPI.Data;
using BACKENDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;
        public LoginController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.User.AsQueryable();           
            return Ok(userdetails);
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User userObj)
        {
            if(userObj==null)
            {
                return BadRequest();
            }
            else
            {
                _context.User.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    message = "User Added Successfully"
                });
            }
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.User.Where(a =>
                  a.userEmail == userObj.userEmail
                  && a.password == userObj.password).FirstOrDefault();
                if(user!=null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Successfully"
                        //,UserData=userObj.userName
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }

    }
}

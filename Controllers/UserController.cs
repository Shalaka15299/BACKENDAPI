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
    public class UserController : ControllerBase
    {
        private readonly UserDbContext context;
        public UserController(UserDbContext userDbContext)
        {
            context = userDbContext;
        }
        [HttpPost("users")]
        public IActionResult GetUsers([FromBody] User userObj)
        {

            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = context.User.AsNoTracking().FirstOrDefault(x => x.id == userObj.id);
                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = user

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 404,
                        Message = "User not found"

                    });
                }
            }


        }
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User userObj)
        {
            userObj.password = BCrypt.Net.BCrypt.HashPassword(userObj.password);

            if (userObj == null)
            {
                return BadRequest();

            }
            else
            {
                userObj.createdAt = DateTime.Now;
                userObj.updatedAt = DateTime.Now;
                context.User.Add(userObj);
                context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"

                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = context.User.Where(a =>
                a.userEmail == userObj.userEmail).FirstOrDefault();
                if (user != null)
                {
                    bool invalidPassword = BCrypt.Net.BCrypt.Verify(userObj.password, user.password);
                    if (invalidPassword)
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Login Success",
                            UserData = user.id
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            StatusCode = 404,
                            Message = "Invalid Username or Password"

                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Invalid Username or Password"

                    });
                }
            }

        }
        [HttpPut("editprofile")]

        public IActionResult editprofile([FromBody] User userObj)
        {


            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = context.User.AsNoTracking().FirstOrDefault(x => x.id == userObj.id);
                if (user != null)
                {
                    var newUserObj = new User
                    {
                        id = user.id,
                        userName = userObj.userName != null ? userObj.userName : user.userName,
                        userEmail = userObj.userEmail != null ? userObj.userEmail : user.userEmail,
                        password = userObj.password != null ? BCrypt.Net.BCrypt.HashPassword(userObj.password) : user.password,
                        Phone = userObj.Phone != null ? userObj.Phone : user.Phone,
                        createdAt = DateTime.Now,
                        updatedAt = DateTime.Now

                    };
                    context.Entry(newUserObj).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "User Added Successfully"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 404,
                        Message = "User not found"

                    });
                }
            }

        }
    }
}

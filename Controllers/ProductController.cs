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
    public class ProductController : ControllerBase
    {
        private readonly UserDbContext _context;
        public ProductController(UserDbContext userdbcontext)
        {
            _context = userdbcontext;
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] ProductModel productObj)
        {
            if(productObj==null)
            {
                return BadRequest();
            }
            else
            {
                /*var product = new ProductModel();
                product.productName = productObj.productName;
                product.productSize = productObj.productSize;
                product.productPrice = productObj.productPrice;
                product.productImage = productObj.productImage;*/
                productObj.createdAt = DateTime.Now;
                productObj.updatedAt = DateTime.Now;


                _context.productModels.Add(productObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Product Added Successfully"
                });
            }
        }

        [HttpPut("updateproduct")]
        public IActionResult UpdateProduct([FromBody] ProductModel productObj)
        {
            if(productObj==null)
            {
                return BadRequest();
            }
            var product = _context.productModels.AsNoTracking().FirstOrDefault(x => x.id == productObj.id);
            if (product == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Product Not Found"
                });
            }
            else
            {
                productObj.createdAt = DateTime.Now;
                productObj.updatedAt = DateTime.Now;
                _context.Entry(productObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Product Updated Successfully"
                });
            }
        }

        [HttpDelete("deleteproduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.productModels.Find(id);
            if(product == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Product Not Found"
                });
            }
            else
            {
                _context.Remove(product);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Product deleted"
                });
            }
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAllProducts()
        {
            var productdetails = _context.productModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                ProductDetails = productdetails
            });
        }

        [HttpGet("getproduct/id")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.productModels.Find(id);
            if(product == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Product Not Found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    ProductDetails = product
                });
            }
        }

    }
}

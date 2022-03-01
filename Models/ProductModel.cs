using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string productName { get; set; }

        [Required]
        public string productSize { get; set; }

        [Required]
        public int? productPrice { get; set; }

        [Required]
        public string productImage { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }


    }
}

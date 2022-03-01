using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Models
{
    public class Ordermodel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int userid { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string userAddress { get; set; }

        [Required]
        public string paymentMode { get; set; }

        [Required]
        public int grandTotal { get; set; }

        [Required]
        public string orderStatus { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }


    }
}

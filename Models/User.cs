using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string userName { get; set; }

        public string userEmail { get; set; }

        public double Phone { get; set; }

        public string password { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

    }
}

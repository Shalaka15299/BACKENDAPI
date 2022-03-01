using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }

        public string userName { get; set; }

        public string userEmail { get; set; }

        public int Phone { get; set; }

        public string password { get; set; }
    }
}

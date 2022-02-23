using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Models
{
    public class EmployeeModel
    {
        [Key]
        public int id { get; set; }

        public string productName { get; set; }

    }
}

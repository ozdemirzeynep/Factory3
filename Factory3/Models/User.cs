using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Factory3.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}

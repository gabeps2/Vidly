using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class NewRentalsDto
    {
        [Required]
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}
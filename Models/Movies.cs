using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movies
    {
        public int id { get; set; }
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}
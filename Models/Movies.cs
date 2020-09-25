using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Generator;

namespace Vidly2.Models
{
    public class Movies
    {
        public int id { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "The Date Added field is required")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Required(ErrorMessage = "The Number in Stock field is required")]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}



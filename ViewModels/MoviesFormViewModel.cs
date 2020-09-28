using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MoviesFormViewModel
    {

        public IEnumerable<Genre> Genres { get; set; }

        public int? id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "The Genre field is required")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "The Number in Stock field is required")]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MoviesFormViewModel()
        {
            id = 0;
        }
        public MoviesFormViewModel(Movies movie)
        {
            id = movie.id;
            name = movie.name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
        }
    }
}
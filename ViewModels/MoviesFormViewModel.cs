using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Movies> Movies { get; set; }
        public Movies Movie { get; set; }
    }
}
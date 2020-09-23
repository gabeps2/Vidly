using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MoviesViewModel
    {
        private List<Movies> listMovies;

        public MoviesViewModel(List<Movies> listMovies)
        {
            this.listMovies = listMovies;
        }

        public List<Movies> getList()
        {
            return this.listMovies;
        }
    }
}
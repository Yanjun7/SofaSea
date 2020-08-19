using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SofaSea.Models;

namespace SofaSea.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}
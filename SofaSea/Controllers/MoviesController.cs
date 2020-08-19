using SofaSea.Models;
using SofaSea.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SofaSea.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer> { 
                new Customer { Name = "Jack"},
                new Customer { Name = "Jerry" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                customers = customers
            };

            return View(viewModel);
           
        }


        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

    }
}
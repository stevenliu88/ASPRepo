using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication2.ViewModels;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index( )
        {
            if (User.IsInRole(RoleName.CanManageMovies)) 
                return View("List");
            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.AddedToDB = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            
                _context.SaveChanges();
            
            return RedirectToAction("Index","Movies"); 

        }
        


        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "lei" };
            var customers = new List<Customer>()
            {
                new Customer(){ Name= "Customer1"},
                new Customer(){ Name = "Emily Liu"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movie = movie
            };
            return View(viewModel);
        }
       
        // movies
       

        [Route("Movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult releasedByDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
}
}
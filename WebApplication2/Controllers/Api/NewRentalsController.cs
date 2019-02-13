using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult CreateNewRental(RentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie has been given");
            var customer = _context.Customers.SingleOrDefault(
                            c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer doesn't exist.");
            var movies = _context.Movies.Where(
                            m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are Invalid");
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
               _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}

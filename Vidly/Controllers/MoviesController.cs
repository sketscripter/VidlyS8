using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include("Genre").ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include("Genre").Where(c => c.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        public  ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var newMovieViewModel = new movieViewModel()
            {
                Genres = genres,
                Movie = new Movie()
            };
            return View(newMovieViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.Find(id);

            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            var genres = _context.Genres.ToList();

            var newMovieViewModel = new movieViewModel()
            {
                Genres = genres,
                Movie = movieInDb
            };

            return View(newMovieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        { 
            if (movie.Id == 0)
            {
                if (ModelState.IsValid == false)
                {
                    var genres = _context.Genres.ToList();

                    var newMovieViewModel = new movieViewModel()
                    {
                        Movie = movie,
                        Genres = genres
                    };

                    return View("New", newMovieViewModel);
                }
                _context.Movies.Add(movie);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    var genres = _context.Genres.ToList();

                    var newMovieViewModel = new movieViewModel()
                    {
                        Movie = movie,
                        Genres = genres
                    };

                    return View("Edit", newMovieViewModel);
                }
                var MovieInDb = _context.Movies.Find(movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.Description = movie.Description;
                MovieInDb.Banner = movie.Banner;
                MovieInDb.Poster = movie.Poster;
                MovieInDb.Director = movie.Director;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.Studio = movie.Studio;
                MovieInDb.GenreId = movie.GenreId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
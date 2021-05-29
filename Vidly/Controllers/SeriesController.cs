using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class SeriesController : Controller
    {
        private ApplicationDbContext _context;

        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var series = _context.Series.Include("Genre").ToList();
            return View(series);
        }

        public ActionResult Detail(int id)
        {
            var Serie = _context.Series.Include("Genre").Where(c => c.Id == id).FirstOrDefault();
            if (Serie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Serie);
            }
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var newSerieViewModel = new serieViewModel()
            {
                Genres = genres,
                Serie = new Serie()
            };
            return View(newSerieViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var SerieInDb = _context.Series.Find(id);

            if (SerieInDb == null)
            {
                return HttpNotFound();
            }

            var genres = _context.Genres.ToList();

            var newSerieViewModel = new serieViewModel()
            {
                Genres = genres,
                Serie = SerieInDb
            };

            return View(newSerieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Serie Serie)
        {
            if (Serie.Id == 0)
            {
                if (ModelState.IsValid == false)
                {
                    var genres = _context.Genres.ToList();

                    var newSerieViewModel = new serieViewModel()
                    {
                        Serie = Serie,
                        Genres = genres
                    };

                    return View("New", newSerieViewModel);
                }
                _context.Series.Add(Serie);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    var genres = _context.Genres.ToList();

                    var newSerieViewModel = new serieViewModel()
                    {
                        Serie = Serie,
                        Genres = genres
                    };

                    return View("Edit", newSerieViewModel);
                }
                var SerieInDb = _context.Series.Find(Serie.Id);

                SerieInDb.Name = Serie.Name;
                SerieInDb.Description = Serie.Description;
                SerieInDb.Banner = Serie.Banner;
                SerieInDb.Poster = Serie.Poster;
                SerieInDb.Director = Serie.Director;
                SerieInDb.ReleaseDate = Serie.ReleaseDate;
                SerieInDb.Studio = Serie.Studio;
                SerieInDb.GenreId = Serie.GenreId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
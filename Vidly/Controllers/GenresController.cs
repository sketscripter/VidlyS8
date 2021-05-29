using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }
    }
}
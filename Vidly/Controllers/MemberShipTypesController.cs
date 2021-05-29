using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MemberShipTypesController : Controller
    {
        private ApplicationDbContext _context;

        public MemberShipTypesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Membershiptype = _context.MemberShipTypes.ToList();
            return View(Membershiptype);
        }
    }
}
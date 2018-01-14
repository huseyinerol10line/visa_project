using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCaliforniaa.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCaliforniaa.Controllers
{


    [Route("blog")]
    public class Blog : Controller
    {
        private readonly BlogDataContext _db;

        public Blog(BlogDataContext db)
        {
            _db = db;
        }



        [HttpGet, Route("visa")]
        public IActionResult Visa()
        {
            return View();
        }


        [HttpPost, Route ("visa")]
        public IActionResult Visa(Visa visa)
        {


            if (!ModelState.IsValid)
                return View();

            _db.VisaTypes.Add(visa);
            _db.SaveChanges();

            return View();
        }
    }
}

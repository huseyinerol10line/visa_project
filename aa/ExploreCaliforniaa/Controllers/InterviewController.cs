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
    public class BlogController : Controller
    {
        private readonly BlogDataContext _db;

        public BlogController(BlogDataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Interview.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.previousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _db.Interview
                .OrderByDescending(x => x.Story)
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToArray();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Interview
            {
                Story = "Helallll",
                Gotten = true,
            };
            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            List<Visa> countrylist = new List<Visa>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            countrylist = (from product in _db.VisaTypes
                           select product).ToList();

            // ------- Inserting Select Item in List -------
            countrylist.Insert(0, new Visa { id = 0, name = "Slect" });

            // ------- Assigning countrylist to ViewBag.ListofCountry -------
            ViewBag.Listofcountry = countrylist;
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Interview interview)
        {
            if (interview.visa_ID == 0)
            {
                ModelState.AddModelError("", "Select Country");
            }

            // ------- Getting selected Value ------- //
            int SelectValue = interview.visa_ID;

            ViewBag.SlectedValue = interview.visa_ID;



            // ------- Setting Data back to ViewBag after Posting Form ------- //

            List<Visa> countrylist = new List<Models.Visa>();

            countrylist = (from product in _db.VisaTypes
                           select product).ToList();

            countrylist.Insert(0, new Visa { id = 0, name = "slect" });
            ViewBag.ListofCountry = countrylist;

            if (!ModelState.IsValid)
                return View();

            _db.Interview.Add(interview);
            _db.SaveChanges();

            return View();
        }

    }


}

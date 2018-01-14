using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCaliforniaa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCaliforniaa.Controllers
{
    [Route("blog")]
    public class blog : Controller
    {
        private readonly BlogDataContext _db;

        public blog(BlogDataContext db)
        {
            _db = db;
        }


        [HttpGet, Route("QuestionCreate")]
        public IActionResult QuestionCreate()
        {
            return View();
        }

        [HttpPost, Route("QuestionCreate")]
        public IActionResult QuestionCreate(InterviewQuestion postt)
        {
            if (!ModelState.IsValid)
                return View();

            _db.QuestionAnswerr.Add(postt);
            _db.SaveChanges();

            return View();
        }
    }
}

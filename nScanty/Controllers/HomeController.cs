using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nScanty.Models;

namespace nScanty.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tags = new List<string> { "Test", "Test2" };
            var body = GetBody();
            var post = new Post()
                           {
                               Day = 11,
                               Month = "July",
                               Title = "My First Post!",
                               Url = @"/past/2011/7/11/my_first_post/",
                               Tags = tags,
                               Body = body
                           };
            var post2 = new Post()
                           {
                               Day = 11,
                               Month = "July",
                               Title = "My Second Post!",
                               Url = @"/past/2011/7/11/my_second_post/",
                               Tags = tags,
                               Body = body
                           };
            var posts = new List<Post> { post, post2 };
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            return View(posts);
            // for testing fresh install
            //return View(new List<Post>());
        }

        public ActionResult About()
        {
            return View();
        }

        private string GetBody()
        {
            return
                @"This is probably the first problem with which I felt like I was writing closer to the functional paradigm. It still takes a good amount of discipline to avoid writing purely imperative code. I have also been paging through several F# books in an effort to beef up my skills a little. So far, the cream of the crop has been “Expert F#” by Don Syme, Adam Granicz and Antonio Cisternino. I highly recommend it to anyone looking to learn the language. Don’t let the “expert” scare you away. It has been extremely useful to me. Even as a beginner. Without further ado - #4:";
        }

    }
}

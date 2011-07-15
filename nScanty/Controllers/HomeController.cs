using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nScanty.Data;
using nScanty.Models;

namespace nScanty.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataLayer _dataLayer = new DataLayer();

        public ActionResult Index()
        {
            var posts = _dataLayer.GetAll();
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            return View(posts);
        }

        //private bool IsAdmin()
        //{
        //    if (Request.Cookies != null && Request.Cookies["nscanty_admin"] != null)
        //    {
        //        return ConfigurationManager.AppSettings["nscanty_admin"] == Request.Cookies["nscanty_admin"].Value;
        //    }
        //    return false;
        //}

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(Post post)
        {
            // create post
            post.CreatedAt = DateTime.Now;
            var segments = new List<string>
                               {
                                   post.CreatedAt.Year.ToString(),
                                   post.Day.ToString(),
                                   post.Month,
                                   post.Slug
                               };
            post.Url = @"/" + String.Join(@"/", segments) + @"/";
            post.Tags = post.TagsRaw.Split(',');
            _dataLayer.Store(post);
            return RedirectToAction("Post", new {slug = post.Slug});
        }

        // forcing a delta

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Post(string slug)
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            //var posts = GetPosts();
            //var post = posts.Where(o => o.Slug == slug).FirstOrDefault();
            // check is not null, handle appropriately
            var post = _dataLayer.GetById(slug);
            return View(post);
        }

        private string GetBody()
        {
            return
                @"This is probably the first problem with which I felt like I was writing closer to the functional paradigm. It still takes a good amount of discipline to avoid writing purely imperative code. I have also been paging through several F# books in an effort to beef up my skills a little. So far, the cream of the crop has been “Expert F#” by Don Syme, Adam Granicz and Antonio Cisternino. I highly recommend it to anyone looking to learn the language. Don’t let the “expert” scare you away. It has been extremely useful to me. Even as a beginner. Without further ado - #4:";
        }

        private List<Post> GetPosts()
        {
            var tags = new List<string> { "Test", "Test2" };
            var body = GetBody();
            var post = new Post()
                           {
                                CreatedAt = DateTime.Now,
                               Title = "My First Post!",
                               Url = @"/past/2011/7/11/my_first_post/",
                               Tags = tags,
                               Body = body
                           };
            var post2 = new Post()
                            {
                                CreatedAt = DateTime.Today,
                                Title = "My Second Post!",
                                Url = @"/past/2011/7/11/my_second_post/",
                                Tags = tags,
                                Body = body
                            };
            return new List<Post> { post, post2 };
        }

    }
}

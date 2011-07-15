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
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var posts = _dataLayer.FindAll();
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
            var split = post.TagsRaw.Split(',');
            post.Tags = split.Select(o => o.Trim()).ToList();
            _dataLayer.Store(post);
            return RedirectToAction("Post", new {slug = post.Slug});
        }

        public ActionResult Post(string slug)
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var post = _dataLayer.FindOneByKey("Slug", slug);
            return View(post);
        }

        public ActionResult Tag(string tag)
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var tagged = new Tagged {Posts = _dataLayer.FindAllByKey("Tags", tag), Tag = tag};
            return View(tagged);
        }

    }
}

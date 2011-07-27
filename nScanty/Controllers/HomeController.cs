﻿using System;
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

        [Authorize]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
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

        public ActionResult Edit(string slug)
        {
            var post = _dataLayer.FindOneByKey("slug", slug);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            // update db
            return RedirectToAction("Index");
        }
    }
}

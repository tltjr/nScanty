using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using nScanty.Data;
using nScanty.Models;

namespace nScanty.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostRepository _postRepository = new PostRepository();

        public ActionResult Index()
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var posts = _postRepository.FindAll();
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
            _postRepository.Store(post);
            return RedirectToAction("Post", new {slug = post.Slug});
        }

        public ActionResult Post(string slug)
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var post = _postRepository.FindOneByKey("Slug", slug);
            return View(post);
        }

        public ActionResult Tag(string tag)
        {
            ViewBag.Title = ConfigurationManager.AppSettings["title"];
            var tagged = new Tagged {Posts = _postRepository.FindAllByKey("Tags", tag), Tag = tag};
            return View(tagged);
        }

        public ActionResult Edit(string objectId)
        {
            var post = _postRepository.FindOneById(objectId);
            EditId.Id = new ObjectId(objectId);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
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
            _postRepository.Update(post);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            _postRepository.DeleteById(new ObjectId(id));
            return RedirectToAction("Index");
        }
    }
}

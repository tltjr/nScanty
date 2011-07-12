using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace nScanty.Models
{
    public class Post
    {
        public string Month { get; set; }
        public int Day { get; set; }
        public string Url { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; } 
            set
            {
                _title = value;
                var lower = Title.ToLower();
                var spacesParsed = Regex.Replace(lower, @" ", "_");
                Slug = Regex.Replace(spacesParsed, @"[^a-z0-9_]", String.Empty);
            }
        }
        public IEnumerable<string> Tags { get; set; }
        public string Body { get; set; }

        public string Slug { get; set; }
                
    }
}
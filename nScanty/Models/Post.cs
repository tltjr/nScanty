using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nScanty.Models
{
    public class Post
    {
        public string Month { get; set; }
        public int Day { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Body { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nScanty.Models
{
    public class Index
    {
        public IEnumerable<Post> Posts { get; set; }
        public bool IsAdmin { get; set; }
    }
}
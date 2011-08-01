using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using nScanty.Models;

namespace nScanty.Feed
{
    public class RssHelper
    {
        public IEnumerable<SyndicationItem> CreateSyndicationItems(IEnumerable<Post> twenty, Uri uri)
        {
            return
                twenty.Select(
                    post =>
                    new SyndicationItem(post.Title, post.Body, uri));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using nScanty.Models;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace nScanty.Data
{
    public class DataLayer : IBasicPersistenceProvider<Post>
    {
        private bool _disposing;

        public void Dispose()
        {
        }

        public Post GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetByIds(ICollection<string> ids)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Store(Post entity)
        {
            var redisUrl = ConfigurationManager.AppSettings.Get("REDISTOGO_URL");
			using (var redisClient = new RedisClient(redisUrl))
			{
			    var redis = redisClient.GetTypedClient<Post>();
                var posts = redis.Lists["urn:posts"];
                posts.Add(entity);
			}
        }

        public void StoreAll(IEnumerable<Post> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIds(ICollection<string> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
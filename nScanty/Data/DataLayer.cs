using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using nScanty.Models;

namespace nScanty.Data
{
    public class DataLayer : IBasicPersistenceProvider<Post>
    {
        private const string PostDir = "posts";

        public Post GetById(string id)
        {
            string stringPost;
            using (var reader = new StreamReader(Path.Combine(PostDir, id)))
            {
                stringPost = reader.ReadToEnd();
            }
            return String.IsNullOrEmpty(stringPost) ? null : JsonConvert.DeserializeObject<Post>(stringPost);
        }

        public IEnumerable<Post> GetAll()
        {
            IList<Post> all = new List<Post>();
            var di = new DirectoryInfo(PostDir);
            if (!di.Exists) return all;
            var posts = Directory.GetFiles(PostDir);
            foreach (var post in posts)
            {
                using (var reader = new StreamReader(post))
                {
                    var stringPost = reader.ReadToEnd();
                    if(!String.IsNullOrEmpty(stringPost))
                    {
                        all.Add(JsonConvert.DeserializeObject<Post>(stringPost));
                    }
                }
            }
            return all;
        }

        public void Store(Post entity)
        {
            var stringPost = JsonConvert.SerializeObject(entity);
            var di = new DirectoryInfo(PostDir);
            if (!di.Exists)
            {
                Directory.CreateDirectory(PostDir);
            }
            using(var writer = new StreamWriter(Path.Combine(PostDir, entity.Slug))){
                writer.WriteLine(stringPost);
            }
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }


    }
}
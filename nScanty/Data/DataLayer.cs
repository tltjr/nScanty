using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using MongoDB.Driver;
using Newtonsoft.Json;
using nScanty.Models;

namespace nScanty.Data
{
    public class DataLayer : IBasicPersistenceProvider<Post>
    {
        private readonly MongoCollection<Post> _collection;

        public DataLayer()
        {
            var connection = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            var database = MongoDatabase.Create(connection);
            _collection = database.GetCollection<Post>("Posts");
        }

        public Post GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _collection.FindAll();
        }

        public void Store(Post entity)
        {
            _collection.Insert(entity);
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }


    }
}
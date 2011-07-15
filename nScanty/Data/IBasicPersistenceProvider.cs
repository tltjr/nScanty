using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nScanty.Data
{
    public interface IBasicPersistenceProvider<T>
    {
        T FindOneByKey(string key, string value);

        IEnumerable<T> FindAllByKey(string key, string value);

        IEnumerable<T> FindAll();

        void Store(T entity);

        void DeleteById(string id);
    }
}

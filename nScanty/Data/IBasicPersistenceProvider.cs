using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nScanty.Data
{
    public interface IBasicPersistenceProvider<T>
    {
        T GetById(string id);

        IEnumerable<T> GetAll();

        void Store(T entity);

        void DeleteById(string id);
    }
}

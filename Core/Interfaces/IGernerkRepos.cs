using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
   public interface IGernerkRepos<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }
    public interface IUnitOfWork<T> where T : class
    {
        IGernerkRepos<T> Entity { get; }
        void Save();
    }
}

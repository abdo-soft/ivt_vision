using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class GenericRepos<T> : IGernerkRepos<T> where T : class
    {
        public GenericRepos(DataC context)
        {
            _Context = context;
            table = _Context.Set<T>();
        }

        public DataC _Context { get; }
        private DbSet<T> table = null;
        public void Delete(object id)
        {
            T existing = GetById(id);
            table.Remove(existing);
               
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}

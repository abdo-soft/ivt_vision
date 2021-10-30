using Core.Interfaces;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
       // public DataC _Context { get; }
        private readonly DataC _context;
        private IGernerkRepos<T> _entity;
        public UnitOfWork(DataC context)
        {
            _context = context;
        }
        public IGernerkRepos<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepos<T>(_context));
            }
        }


       
        public void Save()
        {
            _context.SaveChanges();
        }
    }

   
}

using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity) => _context.Add(entity);

        public bool Exists(Expression<Func<T, bool>> experssion) => _context.Set<T>().Any(experssion);

        public T Get(TKey id) => _context.Set<T>().Find(id);

        public List<T> GetAll() => _context.Set<T>().ToList();

        public void SaveChanges() => _context.SaveChanges();
    }
}

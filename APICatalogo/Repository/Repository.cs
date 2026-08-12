using System.Linq.Expressions;
using APICatalogo.Data;
using APICatalogo.Interface;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDataContext _context;

    public Repository(AppDataContext context)
    {
        _context = context;
    }


    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        //_context.SaveChanges();
        return entity;
    }

    public T Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Set<T>().Remove(entity);
        //_context.SaveChanges();

        return entity;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        //_context.SaveChanges();
        return entity;
    }
}

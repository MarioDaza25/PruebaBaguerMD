using Microsoft.EntityFrameworkCore;
using PruebaBaguerMD.Data;
using PruebaBaguerMD.Models;
using PruebaBaguerMD.Models.Interfaces;

namespace PruebaBaguerMD.Services;

public class GenericService<T> : IGeneric<T>  where T : BaseEntity
{
    private readonly AppDBContext _context;

    public GenericService(AppDBContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    } 
    
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

     public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    

}

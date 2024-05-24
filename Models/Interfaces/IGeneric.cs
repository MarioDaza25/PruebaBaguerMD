using System.Linq.Expressions;

namespace PruebaBaguerMD.Models.Interfaces;

public interface IGeneric<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
    Task SaveAsync();
}

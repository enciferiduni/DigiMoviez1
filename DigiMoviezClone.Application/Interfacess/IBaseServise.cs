namespace DigiMoviezClone.Domain.Interfaces;

public interface IBaseService<T>
    where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(long id);
    Task<T> Create(T entity);
    Task<T> Update(long id, T entity);
    Task<T> Delete(long id);
}
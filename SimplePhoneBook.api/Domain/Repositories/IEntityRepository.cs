using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Domain.Repositories;

public interface IEntityRepository<T> where T : BaseEntity
{
    public T? GetById(Guid id);

    public IReadOnlyList<T> GetAll();

    public void Create(T entity);

    public void Update(T entity);

    public bool Delete(Guid id);
}
using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Infrastructure;

namespace SimplePhoneBook.api.Domain.Repositories;

public interface IEntityRepository<T> where T : BaseEntity
{
    public T? GetById(Guid id);

    public PaginatedResult<T> GetAll(int page = 1, int pageSize = 10);

    public void Create(T entity);

    public void Update(T entity);

    public bool Delete(Guid id);
}
using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Data.Repositories.Contracts;

public interface IEntityRepository<T> where T : BaseEntity
{
    public T GetById(Guid id);

    public List<PaginatedResult<T>> GetAll(int page = 1, int pageSize = 10);

    public void Create(T entity);

    public void Update(T entity);

    public void Delete(Guid id);
}
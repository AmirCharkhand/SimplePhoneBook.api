using SimplePhoneBook.api.Data.Repositories.Contracts;
using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Data.Repositories;

public abstract class InMemoryRepository<T> : IEntityRepository<T> where T : BaseEntity
{
    protected List<T> Items = new List<T>();

    public void Create(T entity)
    {
        Items.Add(entity);
    }

    public void Delete(Guid id)
    {
        var toBeDeleted = GetById(id);
        if (toBeDeleted != null)
            Items.Remove(toBeDeleted);
    }

    public PaginatedResult<T> GetAll(int page = 1, int pageSize = 10)
    {
        var skip = page - 1 * pageSize;
        var items = Items
            .OrderBy(x => x.CreatedDate)
            .Skip(skip)
            .Take(pageSize)
            .ToList();

        var totalCount = Items.Count();
        var result = new PaginatedResult<T>
        {
            Items = items,
            currentPage = page,
            Total = totalCount
        };

        return result;
    }

    public T? GetById(Guid id)
    {
        var result = Items
            .FirstOrDefault(x => x.Id == id);

        return result;
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
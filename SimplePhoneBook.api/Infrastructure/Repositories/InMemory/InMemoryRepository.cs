using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

public abstract class InMemoryRepository<T> : IEntityRepository<T> where T : BaseEntity
{
    protected List<T> Items = new List<T>();

    public void Create(T entity)
    {
        Items.Add(entity);
    }

    public bool Delete(Guid id)
    {
        var toBeDeleted = GetById(id);
        if (toBeDeleted != null)
        {
            Items.Remove(toBeDeleted);
            return true;
        }

        return false;
    }

    public PaginatedResult<T> GetAll(int page = 1, int pageSize = 10)
    {
        var skip = (page - 1) * pageSize;
        var items = Items
            .OrderBy(x => x.CreatedDate)
            .Skip(skip)
            .Take(pageSize)
            .ToList();

        var totalCount = Items.Count();
        var result = new PaginatedResult<T>
        {
            Items = items,
            CurrentPage = page,
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
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

    public IReadOnlyList<T> GetAll()
    {
        return Items;
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
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

    public void Delete(Guid id)
    {
        var toBeDeleted = GetById(id);
        if (toBeDeleted == null)
            throw new KeyNotFoundException($"Entity with id '{id}' was not found.");

        Items.Remove(toBeDeleted);
    }

    public IReadOnlyList<T> GetAll()
    {
        return Items.AsReadOnly();
    }

    public T? GetById(Guid id)
    {
        var result = Items
            .FirstOrDefault(x => x.Id == id);

        return result;
    }

    public void Update(T entity)
    {
        var index = Items.FindIndex(x => x.Id == entity.Id);
        if (index == -1)
            throw new KeyNotFoundException($"Entity with id '{entity.Id}' was not found.");

        Items[index] = entity;
    }
}
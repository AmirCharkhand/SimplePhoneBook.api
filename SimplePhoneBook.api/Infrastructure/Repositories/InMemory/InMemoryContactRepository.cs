using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

public class InMemoryContactRepository : InMemoryRepository<Contact>, IContactRepository
{
    public InMemoryContactRepository()
    {
        Items = SeedData.Contacts.ToList();
    }

    public IReadOnlyList<Contact> GetContactsByTagId(Guid tagId)
    {
        var result = Items
            .Where(c => c.TagId == tagId)
            .ToList();

        return result.AsReadOnly();
    }
}
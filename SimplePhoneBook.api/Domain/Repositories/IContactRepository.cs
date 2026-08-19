using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Domain.Repositories;

public interface IContactRepository : IEntityRepository<Contact>
{
    public IReadOnlyList<Contact> GetContactsByTagId(Guid tagId);
}
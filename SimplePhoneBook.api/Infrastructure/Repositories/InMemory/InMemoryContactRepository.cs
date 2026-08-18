using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

public class InMemoryContactRepository : InMemoryRepository<Contact>, IContactRepository
{
}
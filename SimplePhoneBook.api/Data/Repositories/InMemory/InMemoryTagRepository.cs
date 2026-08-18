using SimplePhoneBook.api.Data.Repositories.Contracts;
using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Data.Repositories.InMemory;

public class InMemoryTagRepository : InMemoryRepository<Tag>, ITagRepository
{
}
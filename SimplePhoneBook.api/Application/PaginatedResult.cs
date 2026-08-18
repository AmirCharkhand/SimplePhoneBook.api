using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Application;

public class PaginatedResult<T> where T : BaseEntity
{
    public List<T>? Items { get; init; }
    public int CurrentPage { get; init; }
    public int Total { get; init; }
}
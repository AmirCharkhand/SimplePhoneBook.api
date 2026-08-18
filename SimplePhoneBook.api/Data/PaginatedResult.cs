using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Data;

public class PaginatedResult<T> where T : BaseEntity
{
    public List<T>? items { get; init; }
    public int currentPage { get; init; }
    public int Total { get; init; }
}
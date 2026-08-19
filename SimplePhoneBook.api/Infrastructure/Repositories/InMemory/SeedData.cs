using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

public static class SeedData
{
    public static readonly Tag Tarabarnet = new() { Description = "شماره همکارم در ترابرنت" };

    public static IReadOnlyList<Tag> Tags { get; } = new[] { Tarabarnet };

    public static IReadOnlyList<Contact> Contacts { get; } = new[]
    {
        new Contact { FirstName = "Ali", LastName = "Rezaei", PhoneNumber = "09120000001", TagId = null },
        new Contact { FirstName = "Sara", LastName = "Ahmadi", PhoneNumber = "09120000002", TagId = Tarabarnet.Id },
        new Contact { FirstName = "Reza", LastName = "Karimi", PhoneNumber = "09120000003", TagId = null },
    };
}
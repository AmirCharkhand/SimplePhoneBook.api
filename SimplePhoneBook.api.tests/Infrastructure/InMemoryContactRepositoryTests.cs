using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;
using Xunit;

namespace SimplePhoneBook.api.tests.Infrastructure;

public class InMemoryContactRepositoryTests
{
    [Fact]
    public void GetContactsByTagId_ReturnsOnlyMatchingContacts()
    {
        var repository = new InMemoryContactRepository();
        var tagId = Guid.NewGuid();

        var matching = new Contact { FirstName = "A", LastName = "B", PhoneNumber = "111", TagId = tagId };
        var nonMatching = new Contact { FirstName = "C", LastName = "D", PhoneNumber = "222", TagId = Guid.NewGuid() };
        var untagged = new Contact { FirstName = "E", LastName = "F", PhoneNumber = "333", TagId = null };

        repository.Create(matching);
        repository.Create(nonMatching);
        repository.Create(untagged);

        var result = repository.GetContactsByTagId(tagId);

        Assert.Contains(result, c => c.Id == matching.Id);
        Assert.DoesNotContain(result, c => c.Id == nonMatching.Id);
        Assert.DoesNotContain(result, c => c.Id == untagged.Id);
    }

    [Fact]
    public void GetContactsByTagId_ReturnsEmpty_WhenNoContactsHaveThatTag()
    {
        var repository = new InMemoryContactRepository();

        var result = repository.GetContactsByTagId(Guid.NewGuid());

        Assert.Empty(result);
    }
}
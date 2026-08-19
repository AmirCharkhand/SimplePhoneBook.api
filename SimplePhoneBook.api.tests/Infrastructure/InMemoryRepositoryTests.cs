using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;
using Xunit;

namespace SimplePhoneBook.api.tests.Infrastructure;

public class InMemoryRepositoryTests
{
    // No seed data - isolates repository-level behavior from SeedData entirely.
    private class TestTagRepository : InMemoryRepository<Tag> { }

    [Fact]
    public void Create_AddsItem_SoItCanBeRetrievedById()
    {
        var repository = new TestTagRepository();
        var tag = new Tag { Description = "Work" };

        repository.Create(tag);

        Assert.Equal(tag, repository.GetById(tag.Id));
    }

    [Fact]
    public void Delete_RemovesItem_WhenIdExists()
    {
        var repository = new TestTagRepository();
        var tag = new Tag { Description = "Work" };
        repository.Create(tag);

        repository.Delete(tag.Id);

        Assert.Null(repository.GetById(tag.Id));
    }

    [Fact]
    public void Delete_ThrowsKeyNotFoundException_WhenIdDoesNotExist()
    {
        var repository = new TestTagRepository();

        Assert.Throws<KeyNotFoundException>(() => repository.Delete(Guid.NewGuid()));
    }

    [Fact]
    public void Update_ThrowsKeyNotFoundException_WhenIdDoesNotExist()
    {
        var repository = new TestTagRepository();
        var nonExistentTag = new Tag { Description = "Ghost" };

        Assert.Throws<KeyNotFoundException>(() => repository.Update(nonExistentTag));
    }

    [Fact]
    public void GetById_ReturnsNull_WhenNotFound()
    {
        var repository = new TestTagRepository();

        Assert.Null(repository.GetById(Guid.NewGuid()));
    }

    [Fact]
    public void GetAll_ReturnsAllCreatedItems()
    {
        var repository = new TestTagRepository();
        repository.Create(new Tag { Description = "A" });
        repository.Create(new Tag { Description = "B" });

        Assert.Equal(2, repository.GetAll().Count);
    }
}
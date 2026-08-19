using SimplePhoneBook.api.Application.DTOs.TagDTOs;
using SimplePhoneBook.api.Application.Services;
using SimplePhoneBook.api.Application.Services.Interfaces;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;
using Xunit;

namespace SimplePhoneBook.api.tests.Application;

public class TagServiceTests
{
    private readonly ITagService _sut; // "system under test"

    public TagServiceTests()
    {
        _sut = new TagService(new InMemoryTagRepository());
    }

    [Fact]
    public void Create_AddsTag_AndReturnsMatchingDto()
    {
        var result = _sut.Create(new TagRequestDto { Description = "Gym" });

        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Gym", result.Description);
        Assert.Contains(_sut.GetAll(), t => t.Id == result.Id);
    }

    [Fact]
    public void Update_ChangesDescription_ForAFreshlyCreatedTag()
    {
        var created = _sut.Create(new TagRequestDto { Description = "Old" });

        var updated = _sut.Update(created.Id, new TagRequestDto { Description = "New" });

        Assert.Equal("New", updated.Description);
    }

    [Fact]
    public void Update_ThrowsKeyNotFoundException_WhenTagDoesNotExist()
    {
        Assert.Throws<KeyNotFoundException>(
            () => _sut.Update(Guid.NewGuid(), new TagRequestDto { Description = "Ghost" }));
    }

    [Fact]
    public void GetById_ReturnsNull_WhenTagDoesNotExist()
    {
        Assert.Null(_sut.GetById(Guid.NewGuid()));
    }

    [Fact]
    public void Delete_RemovesTag_WhenItExists()
    {
        var created = _sut.Create(new TagRequestDto { Description = "Temporary" });

        _sut.Delete(created.Id);

        Assert.DoesNotContain(_sut.GetAll(), t => t.Id == created.Id);
    }

    [Fact]
    public void Delete_ThrowsKeyNotFoundException_WhenTagDoesNotExist()
    {
        Assert.Throws<KeyNotFoundException>(() => _sut.Delete(Guid.NewGuid()));
    }
}
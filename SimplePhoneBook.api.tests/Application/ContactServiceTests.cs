using SimplePhoneBook.api.Application.DTOs.ContactDTOs;
using SimplePhoneBook.api.Application.DTOs.TagDTOs;
using SimplePhoneBook.api.Application.Exceptions;
using SimplePhoneBook.api.Application.Services;
using SimplePhoneBook.api.Application.Services.Interfaces;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;
using Xunit;

namespace SimplePhoneBook.api.tests.Application;

public class ContactServiceTests
{
    private readonly IContactService _sut; // "system under test"
    private readonly ITagService _tagService;

    public ContactServiceTests()
    {
        var tagRepository = new InMemoryTagRepository();
        var contactRepository = new InMemoryContactRepository();

        _tagService = new TagService(tagRepository);
        _sut = new ContactService(contactRepository, tagRepository);
    }

    [Fact]
    public void Create_Throws_WhenTagIdDoesNotExist()
    {
        var dto = new ContactRequestDto
        {
            FirstName = "Ali",
            LastName = "Rezaei",
            PhoneNumber = "09120000000",
            TagId = Guid.NewGuid()
        };

        Assert.Throws<InvalidTagReferenceException>(() => _sut.Create(dto));
    }

    [Fact]
    public void Create_Succeeds_WhenTagIdIsNull()
    {
        var dto = new ContactRequestDto
        {
            FirstName = "Ali",
            LastName = "Rezaei",
            PhoneNumber = "09120000000",
            TagId = null
        };

        var result = _sut.Create(dto);

        Assert.Null(result.TagId);
    }

    [Fact]
    public void Create_Succeeds_WhenTagIdReferencesAnExistingTag()
    {
        var tag = _tagService.Create(new TagRequestDto { Description = "Work" });
        var dto = new ContactRequestDto
        {
            FirstName = "Sara",
            LastName = "Ahmadi",
            PhoneNumber = "09120000001",
            TagId = tag.Id
        };

        var result = _sut.Create(dto);

        Assert.Equal(tag.Id, result.TagId);
    }

    [Fact]
    public void GetAll_FiltersByTagId_WhenProvided()
    {
        var tag = _tagService.Create(new TagRequestDto { Description = "Family" });
        var matching = _sut.Create(new ContactRequestDto
        {
            FirstName = "A",
            LastName = "B",
            PhoneNumber = "111",
            TagId = tag.Id
        });
        _sut.Create(new ContactRequestDto
        {
            FirstName = "C",
            LastName = "D",
            PhoneNumber = "222",
            TagId = null
        });

        var result = _sut.GetAll(tag.Id);

        Assert.All(result, c => Assert.Equal(tag.Id, c.TagId));
        Assert.Contains(result, c => c.Id == matching.Id);
    }

    [Fact]
    public void Update_ThrowsKeyNotFoundException_WhenContactDoesNotExist()
    {
        var dto = new ContactRequestDto
        {
            FirstName = "X",
            LastName = "Y",
            PhoneNumber = "000",
            TagId = null
        };

        Assert.Throws<KeyNotFoundException>(() => _sut.Update(Guid.NewGuid(), dto));
    }

    [Fact]
    public void Delete_RemovesContact_WhenItExists()
    {
        var created = _sut.Create(new ContactRequestDto
        {
            FirstName = "Temp",
            LastName = "Contact",
            PhoneNumber = "000",
            TagId = null
        });

        _sut.Delete(created.Id);

        Assert.Null(_sut.GetById(created.Id));
    }

    [Fact]
    public void Delete_ThrowsKeyNotFoundException_WhenContactDoesNotExist()
    {
        Assert.Throws<KeyNotFoundException>(() => _sut.Delete(Guid.NewGuid()));
    }
}
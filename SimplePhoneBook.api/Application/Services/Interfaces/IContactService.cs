using SimplePhoneBook.api.Application.DTOs.ContactDTOs;

namespace SimplePhoneBook.api.Application.Services.Interfaces;

public interface IContactService
{
    IReadOnlyList<ContactResponseDto> GetAll(Guid? tagId);
    ContactResponseDto? GetById(Guid id);
    ContactResponseDto Create(ContactRequestDto dto);
    ContactResponseDto Update(Guid id, ContactRequestDto dto);
    void Delete(Guid id);
}
using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Application.DTOs.ContactDTOs;

public static class ContactMappingExtensions
{
    public static ContactResponseDto ToResponseDto(this Contact contact) => new()
    {
        Id = contact.Id,
        FirstName = contact.FirstName,
        LastName = contact.LastName,
        PhoneNumber = contact.PhoneNumber,
        TagId = contact.TagId
    };

    public static Contact ToContact(this ContactRequestDto dto) => new()
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        PhoneNumber = dto.PhoneNumber,
        TagId = dto.TagId
    };

    public static void ApplyTo(this ContactRequestDto dto, Contact contact)
    {
        contact.FirstName = dto.FirstName;
        contact.LastName = dto.LastName;
        contact.PhoneNumber = dto.PhoneNumber;
        contact.TagId = dto.TagId;
    }
}
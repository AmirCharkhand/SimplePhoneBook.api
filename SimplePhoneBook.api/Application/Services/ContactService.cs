using SimplePhoneBook.api.Application.DTOs.ContactDTOs;
using SimplePhoneBook.api.Application.Exceptions;
using SimplePhoneBook.api.Application.Services.Interfaces;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Application.Services;

public class ContactService(
    IContactRepository contactRepository,
    ITagRepository tagRepository) : IContactService
{
    public IReadOnlyList<ContactResponseDto> GetAll(Guid? tagId)
    {
        var contacts = tagId.HasValue
            ? contactRepository.GetContactsByTagId(tagId.Value)
            : contactRepository.GetAll();

        return contacts.Select(c => c.ToResponseDto()).ToList();
    }

    public ContactResponseDto? GetById(Guid id)
    {
        return contactRepository.GetById(id)?.ToResponseDto();
    }

    public ContactResponseDto Create(ContactRequestDto dto)
    {
        EnsureTagExists(dto.TagId);

        var contact = dto.ToContact();
        contactRepository.Create(contact);
        return contact.ToResponseDto();
    }

    public ContactResponseDto Update(Guid id, ContactRequestDto dto)
    {
        var existingContact = contactRepository.GetById(id);
        if (existingContact == null)
            throw new KeyNotFoundException($"Contact with id '{id}' was not found.");

        EnsureTagExists(dto.TagId);

        dto.ApplyTo(existingContact);
        contactRepository.Update(existingContact);
        return existingContact.ToResponseDto();
    }

    public void Delete(Guid id)
    {
        contactRepository.Delete(id);
    }

    private void EnsureTagExists(Guid? tagId)
    {
        if (tagId.HasValue && tagRepository.GetById(tagId.Value) == null)
            throw new InvalidTagReferenceException(tagId.Value);
    }
}
using Microsoft.AspNetCore.Mvc;
using SimplePhoneBook.api.Application.DTOs.ContactDTOs;
using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(
        IContactRepository contactRepository,
        ITagRepository tagRepository) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContacts([FromQuery] Guid? tagId)
        {
            IReadOnlyList<Contact> contacts;
            if (tagId.HasValue)
                contacts = contactRepository.GetContactsByTagId(tagId.Value);
            else
                contacts = contactRepository.GetAll();

            var dtos = contacts.Select(c => c.ToResponseDto()).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetContact(Guid id)
        {
            var contact = contactRepository.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact.ToResponseDto());
        }

        [HttpPost]
        public IActionResult CreateContact(ContactRequestDto contactDto)
        {
            if (contactDto.TagId.HasValue && tagRepository.GetById(contactDto.TagId.Value) == null)
                return BadRequest($"Tag with id '{contactDto.TagId}' does not exist.");

            var contact = contactDto.ToContact();
            contactRepository.Create(contact);

            return Ok(contact.ToResponseDto());
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContact(Guid id, ContactRequestDto contactDto)
        {
            var existingContact = contactRepository.GetById(id);
            if (existingContact == null)
                return NotFound();

            if (contactDto.TagId.HasValue && tagRepository.GetById(contactDto.TagId.Value) == null)
                return BadRequest($"Tag with id '{contactDto.TagId}' does not exist.");

            contactDto.ApplyTo(existingContact);
            contactRepository.Update(existingContact);

            return Ok(existingContact.ToResponseDto());
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            contactRepository.Delete(id);
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SimplePhoneBook.api.Application.DTOs.ContactDTOs;
using SimplePhoneBook.api.Application.Services.Interfaces;

namespace SimplePhoneBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContacts([FromQuery] Guid? tagId)
        {
            var dtos = contactService.GetAll(tagId);
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetContact(Guid id)
        {
            var dto = contactService.GetById(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateContact(ContactRequestDto contactDto)
        {
            var dto = contactService.Create(contactDto);
            return CreatedAtAction(nameof(GetContact), new { id = dto.Id }, dto);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContact(Guid id, ContactRequestDto contactDto)
        {
            var dto = contactService.Update(id, contactDto);
            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            contactService.Delete(id);
            return NoContent();
        }
    }
}
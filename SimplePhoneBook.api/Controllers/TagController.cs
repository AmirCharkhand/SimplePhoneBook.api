using Microsoft.AspNetCore.Mvc;
using SimplePhoneBook.api.Application.DTOs.TagDTOs;
using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController (ITagRepository tagRepository): ControllerBase
    {
        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = tagRepository.GetAll();
            var dtos = tags.Select(t => t.ToResponseDto()).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTag(Guid id)
        {
            var tag = tagRepository.GetById(id);
            
            if (tag == null)
                return NotFound();

            return Ok(tag.ToResponseDto());
        }

        [HttpPost]
        public IActionResult CreateTag(TagRequestDto tagDto)
        {
            var tag = tagDto.ToTag();
            tagRepository.Create(tag);
            return Ok(tag.ToResponseDto());
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateTag(Guid id, TagRequestDto tagDto)
        {
            var existingTag = tagRepository.GetById(id);
            if (existingTag == null)
                return NotFound();

            tagDto.ApplyTo(existingTag);
            tagRepository.Update(existingTag);
            return Ok(existingTag.ToResponseDto());
        }

        [HttpDelete]
        public IActionResult DeleteTag(Guid id)
        {
            tagRepository.Delete(id);
            return Ok();
        }
    }
}
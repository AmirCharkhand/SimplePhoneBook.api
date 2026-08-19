using Microsoft.AspNetCore.Mvc;
using SimplePhoneBook.api.Application.DTOs.TagDTOs;
using SimplePhoneBook.api.Application.Services.Interfaces;

namespace SimplePhoneBook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController(ITagService tagService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTags()
        {
            var dtos = tagService.GetAll();
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTag(Guid id)
        {
            var dto = tagService.GetById(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateTag(TagRequestDto tagDto)
        {
            var dto = tagService.Create(tagDto);
            return CreatedAtAction(nameof(GetTag), new { id = dto.Id }, dto);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateTag(Guid id, TagRequestDto tagDto)
        {
            var dto = tagService.Update(id, tagDto);
            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteTag(Guid id)
        {
            tagService.Delete(id);
            return NoContent();
        }
    }
}
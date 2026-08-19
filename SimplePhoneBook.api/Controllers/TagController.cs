using Microsoft.AspNetCore.Mvc;
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
            return Ok(tags);
        }
    }
}
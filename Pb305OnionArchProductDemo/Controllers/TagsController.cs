using Microsoft.AspNetCore.Mvc;
using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchTagDemo.Application.Interfaces;

namespace Pb305OnionArchTagDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody] CreateTagDto createTagDto)
        {
            var createdTag = await _tagService.AddTagAsync(createTagDto);

            return CreatedAtAction(nameof(GetTagById), new { id = createdTag.Id }, createTagDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagDto updateTagDto)
        {
            await _tagService.UpdateTagAsync(updateTagDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTagAsync(id);
            return NoContent();
        }
    }
}

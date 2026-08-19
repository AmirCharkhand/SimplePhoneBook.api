using SimplePhoneBook.api.Application.DTOs.TagDTOs;
using SimplePhoneBook.api.Application.Services.Interfaces;
using SimplePhoneBook.api.Domain.Repositories;

namespace SimplePhoneBook.api.Application.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public IReadOnlyList<TagResponseDto> GetAll()
    {
        return tagRepository
            .GetAll()
            .Select(t => t.ToResponseDto())
            .ToList();
    }

    public TagResponseDto? GetById(Guid id)
    {
        return tagRepository
            .GetById(id)?
            .ToResponseDto();
    }

    public TagResponseDto Create(TagRequestDto dto)
    {
        var tag = dto.ToTag();
        tagRepository.Create(tag);
        return tag.ToResponseDto();
    }

    public TagResponseDto Update(Guid id, TagRequestDto dto)
    {
        var existingTag = tagRepository.GetById(id);
        if (existingTag == null)
            throw new KeyNotFoundException($"Tag with id '{id}' was not found.");

        dto.ApplyTo(existingTag);
        tagRepository.Update(existingTag);
        return existingTag.ToResponseDto();
    }

    public void Delete(Guid id)
    {
        tagRepository.Delete(id);
    }
}
using SimplePhoneBook.api.Application.DTOs.TagDTOs;

namespace SimplePhoneBook.api.Application.Services.Interfaces;

public interface ITagService
{
    IReadOnlyList<TagResponseDto> GetAll();
    TagResponseDto? GetById(Guid id);
    TagResponseDto Create(TagRequestDto dto);
    TagResponseDto Update(Guid id, TagRequestDto dto);
    void Delete(Guid id);
}
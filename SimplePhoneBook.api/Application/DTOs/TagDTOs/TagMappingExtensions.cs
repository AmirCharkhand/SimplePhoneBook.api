using SimplePhoneBook.api.Domain.Models;

namespace SimplePhoneBook.api.Application.DTOs.TagDTOs;

public static class TagMappingExtensions
{
    public static TagResponseDto ToResponseDto(this Tag tag) => new()
    {
        Id = tag.Id,
        Description = tag.Description
    };

    public static Tag ToTag(this TagRequestDto dto) => new()
    {
        Description = dto.Description
    };
}
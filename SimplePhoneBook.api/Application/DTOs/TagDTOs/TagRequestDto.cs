using System.ComponentModel.DataAnnotations;

namespace SimplePhoneBook.api.Application.DTOs.TagDTOs;

public class TagRequestDto
{
    [Length(minimumLength:3, maximumLength:30)]
    public string Description { get; init; } = string.Empty;
}
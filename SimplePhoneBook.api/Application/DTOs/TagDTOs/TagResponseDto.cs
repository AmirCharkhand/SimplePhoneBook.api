namespace SimplePhoneBook.api.Application.DTOs.TagDTOs;

public class TagResponseDto
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
}
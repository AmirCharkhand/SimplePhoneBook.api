namespace SimplePhoneBook.api.Application.DTOs.ContactDTOs;

public class ContactResponseDto
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public Guid? TagId { get; init; }
}
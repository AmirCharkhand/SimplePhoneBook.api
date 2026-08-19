using System.ComponentModel.DataAnnotations;

namespace SimplePhoneBook.api.Application.DTOs.ContactDTOs;

public class ContactRequestDto
{
    [MaxLength(100)]
    public string? FirstName { get; init; }

    [MaxLength(100)]
    public string? LastName { get; init; }

    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; init; } = string.Empty;


    public Guid? TagId { get; init; }
}
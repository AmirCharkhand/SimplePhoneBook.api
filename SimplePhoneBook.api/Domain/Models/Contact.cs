namespace SimplePhoneBook.api.Domain.Models;

public class Contact : BaseEntity
{
    public Guid? TagId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}
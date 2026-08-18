namespace SimplePhoneBook.api.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
    }

    protected BaseEntity(Guid id, DateTime createdDate)
    {
        Id = id;
        CreatedDate = createdDate;
    }
}
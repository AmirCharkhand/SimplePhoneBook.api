namespace SimplePhoneBook.api.Application.Exceptions;

public class InvalidTagReferenceException : Exception
{
    public InvalidTagReferenceException(Guid tagId)
        : base($"Tag with id '{tagId}' does not exist.")
    {
    }
}
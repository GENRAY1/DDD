namespace UserService.Domain.OrganizationAggregate.Exceptions;

public class IncorrectOrgNameException(int minlength, int maxlength)
    :Exception($"Invalid property Name, the minimum number of characters should be {minlength}" +
               $" and the maximum number of characters should be {maxlength} characters")
{
    
}
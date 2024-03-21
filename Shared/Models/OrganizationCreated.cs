namespace Shared.Models;

public class OrganizationCreated(string name)
{
    public string Name { get; } = name;
}
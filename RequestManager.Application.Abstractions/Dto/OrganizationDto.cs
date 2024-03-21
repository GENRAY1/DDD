namespace RequestManager.Application.Abstractions.Dto;

public class OrganizationDto(string name)
{
    public string Name { get; } = name;
}
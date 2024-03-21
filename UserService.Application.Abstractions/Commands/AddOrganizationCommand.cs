using MediatR;

namespace UserService.Application.Abstractions.Commands;

public class AddOrganizationCommand(string name):IRequest
{
    public string Name { get; } = name;
}
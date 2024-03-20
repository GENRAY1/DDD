using FluentValidation;

namespace UserService.API.Contracts.Organization.Validators;

public class OrganizationUpdateRequestValidator: AbstractValidator<OrganizationUpdateRequest>
{
    public OrganizationUpdateRequestValidator() 
    {
        RuleFor(x => x.Userid)
            .NotNull().WithMessage("UserId не может быть пустым.")
            .NotEmpty().WithMessage("UserId не может быть пустым.");
            

        RuleFor(x => x.OrganizationId)
            .NotNull().WithMessage("OrganizationId не может быть пустым.")
            .NotEmpty().WithMessage("OrganizationId не может быть пустым.");

    }
}
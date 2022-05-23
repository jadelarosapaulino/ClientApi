using Application.Features.Clients.Commands.CreateClientCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contacts.Commands.CreateContactCommand;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .Matches(@"^\d{3}-\d{3}-\d{4}$").WithMessage("{PropertyName} format of the telephone number is invalid, valid example (xxx-xxx-xxxx)!")
            .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {12} characters");
    }
}

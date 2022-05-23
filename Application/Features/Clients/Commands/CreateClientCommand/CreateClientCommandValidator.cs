using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {MaxLength} characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {MaxLength} characters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .EmailAddress().WithMessage("{PropertyName} enter a valid email address")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {MaxLength} characters");

            RuleFor(p => p.BirtDate)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}

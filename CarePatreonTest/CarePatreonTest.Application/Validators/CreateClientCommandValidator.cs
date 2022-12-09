using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Extensions;
using CarePatreonTest.Core.Constants;
using FluentValidation;

namespace CarePatreonTest.Application.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(command => command.Email)
                .ValidEmail();

            RuleFor(command => command.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(command => command.FirstName).NotNull().NotEmpty()
               .WithMessage(string.Format(ValidationConstants.Field_Is_Required, nameof(CreateClientCommand.FirstName)));

            RuleFor(command => command.LastName).NotNull().NotEmpty()
               .WithMessage(string.Format(ValidationConstants.Field_Is_Required, nameof(CreateClientCommand.LastName)));
        }
    }
}

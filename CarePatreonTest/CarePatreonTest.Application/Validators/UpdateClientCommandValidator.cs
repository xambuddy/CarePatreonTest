using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Extensions;
using CarePatreonTest.Core.Constants;
using FluentValidation;

namespace CarePatreonTest.Application.Validators
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(command => command.Id).NotNull().NotEmpty()
               .WithMessage(string.Format(ValidationConstants.Field_Is_Required, nameof(UpdateClientCommand.Id)));

            RuleFor(command => command.Email)
                .ValidEmail();

            RuleFor(command => command.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(command => command.FirstName).NotNull().NotEmpty()
               .WithMessage(string.Format(ValidationConstants.Field_Is_Required, nameof(UpdateClientCommand.FirstName)));

            RuleFor(command => command.LastName).NotNull().NotEmpty()
               .WithMessage(string.Format(ValidationConstants.Field_Is_Required, nameof(UpdateClientCommand.LastName)));
        }
    }
}

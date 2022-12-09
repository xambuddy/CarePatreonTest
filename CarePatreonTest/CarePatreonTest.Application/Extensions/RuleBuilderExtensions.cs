using CarePatreonTest.Core.Constants;
using FluentValidation;

namespace CarePatreonTest.Application.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder, Func<string, bool> checkUniqueEmail = null)
        {
            var options = ruleBuilder
                .NotEmpty()
                .WithMessage(string.Format(ValidationConstants.Error_Validation_Value_Not_Empty, "email"))
                .EmailAddress()
                .WithMessage(ValidationConstants.Error_Validation_Email_Invalid_Format);

            if (checkUniqueEmail != null)
            {
                options = options.Must(checkUniqueEmail).WithMessage(ValidationConstants.Error_Validation_Emain_In_Use);
            }

            return options;
        }

        public static IRuleBuilderOptions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .WithMessage(string.Format(ValidationConstants.Error_Validation_Value_Not_Empty, "phone number"))
                .Matches("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")
                .WithMessage(ValidationConstants.Error_Validation_Phone_Number_Invalid_Format);

            return options;
        }
    }
}

using CarePatreonTest.Application.Queries;
using CarePatreonTest.Core.Constants;
using FluentValidation;

namespace CarePatreonTest.Application.Validators
{
    public class ReadClientsByKeywordQueryValidator : AbstractValidator<ReadClientsByKeywordQuery>
    {
        public ReadClientsByKeywordQueryValidator()
        {
            RuleFor(query => query.Keyword)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Length >= 3)
                .WithMessage(ValidationConstants.Error_Validation_Keyword_Invalid);
        }
    }
}

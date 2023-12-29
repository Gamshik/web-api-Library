using Entites.Entities;
using FluentValidation;
using Web_Api.BLL.Extensions;

namespace Web_Api.BLL.Validation
{
    public class IssueValidator : AbstractValidator<Issue>
    {
        public IssueValidator()
        {
            RuleFor(i => i.DateOfIssue)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Data of issue is required!")
                .CorrectDate().WithMessage($"Data of issue is not correct!");

            RuleFor(i => i.DateOfReturn)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Data of return is required!")
                .CorrectDate().WithMessage($"Data of return is not correct!");
        }
    }
}

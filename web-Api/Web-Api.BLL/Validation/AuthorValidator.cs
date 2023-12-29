using Entites.Entities;
using FluentValidation;
using Web_Api.BLL.Extensions;

namespace Web_Api.BLL.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required!")
                .JustLetter().WithMessage("First name is not correct!");

            RuleFor(a => a.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required!")
                .JustLetter().WithMessage("Last name is not correct!");

            RuleFor(a => a.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Country is required!")
                .IsValidCountry().WithMessage("Country is not correct!");
        }
    }
}

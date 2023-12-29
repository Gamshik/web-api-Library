using Entites.Entities;
using FluentValidation;
using Web_Api.BLL.Extensions;

namespace Web_Api.BLL.Validation
{
    public class ReaderValidator : AbstractValidator<Reader>
    {
        public ReaderValidator()
        {
            RuleFor(r => r.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required!")
                .JustLetter().WithMessage("First name is not correct!");

            RuleFor(r => r.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required!")
                .JustLetter().WithMessage("Last name is not correct!");

            RuleFor(r => r.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Phone number is required!")
                .IsValidPhoneNumber().WithMessage("Phone number is not correct!");
        }
    }
}

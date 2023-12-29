using Entites.Entities;
using FluentValidation;
using Web_Api.BLL.Extensions;

namespace Web_Api.BLL.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title is required!");

            RuleFor(b => b.CreateDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Data is required!")
                .CorrectDate().WithMessage($"Create data is not correct!");

            RuleFor(b => b.Genre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Genre is required!")
                .JustLetter().WithMessage("Genre is not correct");
        }
    }
}

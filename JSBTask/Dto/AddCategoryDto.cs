using FluentValidation;
using System.ComponentModel;

namespace JSBTask.Dto
{
    public class AddCategoryDto
    {
        [DisplayName("اسم القسم")] public string categoryName { get; set; }

        [DisplayName("وصف القسم")] public string categoryDescription { get; set; }
    }

    public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryDtoValidator()
        {
            RuleFor(book => book.categoryName)
                .NotEmpty()
                .WithMessage("برجاء ادخال اسم القسم");

            RuleFor(book => book.categoryDescription)
                .NotEmpty()
                .WithMessage("برجاء ادخال وصف القسم");

        }
    }
}

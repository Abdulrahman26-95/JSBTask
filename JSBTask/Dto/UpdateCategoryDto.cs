using FluentValidation;
using System.ComponentModel;

namespace JSBTask.Dto
{
    public class UpdateCategoryDto
    {
        [DisplayName("رقم القسم")] public int categoryId { get; set; }

        [DisplayName("اسم القسم")] public string categoryName { get; set; }

        [DisplayName("وصف القسم")] public string categoryDescription { get; set; }
    }

    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(book => book.categoryId)
                .NotEmpty()
                .WithMessage("برجاء ادخال رقم القسم");

            RuleFor(book => book.categoryName)
                .NotEmpty()
                .WithMessage("برجاء ادخال اسم القسم");

            RuleFor(book => book.categoryDescription)
                .NotEmpty()
                .WithMessage("برجاء ادخال وصف القسم");

        }
    }
}

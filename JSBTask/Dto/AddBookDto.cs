using FluentValidation;
using System.ComponentModel;

namespace JSBTask.Dto
{
    public class AddBookDto
    {
        [DisplayName("اسم الكتاب")] public string bookName { get; set; }

        [DisplayName("وصف الكتاب")] public string bookDescription { get; set; }

        [DisplayName("سعر الكتاب")] public double bookPrice { get; set; }

        [DisplayName("مؤلف الكتاب")] public string bookAuther { get; set; }

        [DisplayName("مخزون الكتاب")] public int stock { get; set; }

        [DisplayName("القسم")] public int categoryId { get; set; }
    }

    public class AddBookDtoValidator : AbstractValidator<AddBookDto>
    {
        public AddBookDtoValidator()
        {
            RuleFor(book => book.bookPrice)
                .GreaterThan(0)
                .WithMessage("برجاء ادخال قيمة غير سالبة لسعر الكتاب");

            RuleFor(book => book.stock)
                .GreaterThan(0)
                .WithMessage("برجاء ادخال قيمة غير سالبة لمخزون الكتاب");

            RuleFor(book => book.categoryId)
                .GreaterThan(0)
                .WithMessage("برجاء اختيار قسم للكتاب");
        }
    }
}

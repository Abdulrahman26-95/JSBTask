using FluentValidation;
using System.ComponentModel;

namespace JSBTask.Dto
{
    public class UpdateBookDto
    {
        [DisplayName("رقم الكتاب")] public string bookId { get; set; }

        [DisplayName("اسم الكتاب")] public string bookName { get; set; }

        [DisplayName("وصف الكتاب")] public string bookDescription { get; set; }

        [DisplayName("سعر الكتاب")] public double bookPrice { get; set; }

        [DisplayName("مؤلف الكتاب")] public string bookAuther { get; set; }

        [DisplayName("مخزون الكتاب")] public int stock { get; set; }

        [DisplayName("القسم")] public int categoryId { get; set; }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(book => book.bookId)
               .NotEmpty()
               .WithMessage("برجاء تحديد رقم الكتاب");

            RuleFor(book => book.bookPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("برجاء ادخال قيمة غير سالبة لسعر الكتاب");

            RuleFor(book => book.stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("برجاء ادخال قيمة غير سالبة لمخزون الكتاب");

            RuleFor(book => book.categoryId)
                .NotEmpty()
                .WithMessage("برجاء اختيار قسم للكتاب");


        }
    }
}

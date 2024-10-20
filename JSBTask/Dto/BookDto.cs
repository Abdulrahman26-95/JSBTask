using System.ComponentModel;

namespace JSBTask.Dto
{
    public class BookDto
    {

        [DisplayName("رقم الكتاب")] public int id { get; set; }

        [DisplayName("اسم الكتاب")] public string name { get; set; }

        [DisplayName("وصف الكتاب")] public string description { get; set; }

        [DisplayName("سعر الكتاب")] public double price { get; set; }

        [DisplayName("مؤلف الكتاب")] public string auther { get; set; }

        [DisplayName("مخزون الكتاب")] public int stock { get; set; }

        [DisplayName("مخزون الكتاب")] public string category { get; set; }
    }
}

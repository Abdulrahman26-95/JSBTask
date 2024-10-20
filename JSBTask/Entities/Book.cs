using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JSBTask.Entities
{
    public class Book
    {
        [Key]

        [DisplayName("رقم الكتاب")]  public int BookId { get; set; }

        [DisplayName("اسم الكتاب")]  public string Name { get; set; }

        [DisplayName("وصف الكتاب")]  public string Description { get; set; }

        [DisplayName("سعر الكتاب")]  public double Price { get; set; }

        [DisplayName("مؤلف الكتاب")]  public string Auther { get; set; }

        [DisplayName("مخزون الكتاب")]  public int Stock { get; set; }


        // Relations 

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

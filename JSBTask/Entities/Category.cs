using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JSBTask.Entities
{
    public class Category
    {

        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]

        [DisplayName("رقم القسم")] public int CategoryId { get; set; }

        [DisplayName("اسم القسم")] public string Name { get; set; }

        [DisplayName("وصف القسم")] public string Description { get; set; }

        // Navigation 
        public virtual ICollection<Book> Books { get; set; }

    }
}

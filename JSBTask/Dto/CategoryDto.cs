namespace JSBTask.Dto
{
    public class CategoryDto
    {
        public int categoryId { get; set; }

        public string categoryName { get; set; }

        public string categoryDescription { get; set; }

        public List<BookCategoryDto> books { get; set; }

    }

    public class BookCategoryDto
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
    }
}

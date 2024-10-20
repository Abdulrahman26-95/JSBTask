namespace JSBTask.Constants
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;


        public static class Book
        {
            public const string GetAllBooks = Base + "/GetAllBooks";
            public const string GetBookById = Base + "/GetBookById";
            public const string AddNewBook = Base + "/AddNewBook";
            public const string UpdateBook = Base + "/UpdateBook";
            public const string DeleteBook = Base + "/DeleteBook";

        }

        public static class Category
        {
            public const string GetAllCategories = Base + "/GetAllCategories";
            public const string GetCategoryById = Base + "/GetCategoryById";
            public const string AddNewCategory = Base + "/AddNewCategory";
            public const string UpdateCategory = Base + "/UpdateCategory";
            public const string DeleteCategory = Base + "/DeleteCategory";

        }
    }


}

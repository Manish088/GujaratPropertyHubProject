using PropertyEntity;

namespace PropertyMVC.HTTPAPI.CategoryHTTPAPI
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategoryServiceApi();
        Task InsertCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<Category> GetCategoryById(int categoryId);
        Task UpdateCategory(Category category);
    }
}

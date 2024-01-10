using PropertyEntity;

namespace PropertyAPI.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task InsertCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<Category> GetCategoryById(int categoryId);
        Task UpdateCategory(Category category);
    }
}

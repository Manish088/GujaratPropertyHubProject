using PropertyEntity;

namespace PropertyAPI.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task InsertCategory(Category category);
        Task DeleteCategory(int CategoryId);
        Task<Category> GetCategoryById(int CategoryId);
        Task UpdateCategory(Category category);
    }
}

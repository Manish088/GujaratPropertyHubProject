using PropertyAPI.IRepository;
using PropertyAPI.IService;
using PropertyEntity;

namespace PropertyAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        public async Task DeleteCategory(int CategoryId)
        {
             await _categoryRepository.DeleteCategory(CategoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            return await _categoryRepository.GetCategoryById(CategoryId);
        }

        public async Task InsertCategory(Category category)
        {
             await _categoryRepository.InsertCategory(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateCategory(category);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PropertyAPI.IRepository;
using PropertyEntity;
using PropertyEntity.Data;

namespace PropertyAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }
        public async Task DeleteCategory(int categoryId)
        {
            var categoryToDelete=await _applicationDbContext.category.FindAsync(categoryId);
            if(categoryToDelete != null)
            {
                _applicationDbContext.category.Remove(categoryToDelete);
                await _applicationDbContext.SaveChangesAsync(); 
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var CategoryList =await  _applicationDbContext.category.ToListAsync();
            return CategoryList;
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            var GetCategoryById=await _applicationDbContext.category.FindAsync(categoryId);
            _applicationDbContext.SaveChanges();
            return GetCategoryById;
        }

        public async Task InsertCategory(Category category)
        {
            _applicationDbContext.category.Add(category);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _applicationDbContext.category.Entry(category).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}

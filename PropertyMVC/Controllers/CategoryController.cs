using Microsoft.AspNetCore.Mvc;
using PropertyEntity;
using PropertyMVC.HTTPAPI.CategoryHTTPAPI;

namespace PropertyMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryDetails()
        {
            try
            {
                var categoryList = await _categoryService.GetAllCategoryServiceApi();
                return View(categoryList);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error retrieving category details.";
                return View("Error");
            }
        }

        [HttpGet]
        public async  Task<IActionResult> CreateCategory(int? categoryId)
        {
            try
            {
                if (categoryId.HasValue)
                {
                    var category = await _categoryService.GetCategoryById(categoryId.Value);
                    if (category == null)
                    {
                        return NotFound();
                    }
                    return View("CreateCategory", category);
                }
                else
                {
                    return View("CreateCategory");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error retrieving category for editing.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(category.CategoryId!=null)
                    {
                        await _categoryService.UpdateCategory(category);
                        return RedirectToAction("GetAllCategoryDetails");
                    }
                    else
                    {

                    await _categoryService.InsertCategory(category);
                    return RedirectToAction("GetAllCategoryDetails");
                    }
                }

                return RedirectToAction("GetAllCategoryDetails");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error creating category.";
                return View("Error");
            }
        }

        /*[HttpGet]
        public async Task<IActionResult> EditCategory(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error retrieving category for editing.";
                return View("Error");
            }
        }*/

        /*[HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.UpdateCategory(category);
                    return RedirectToAction("GetAllCategoryDetails");
                }

                return View(category);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error updating category.";
                return View("Error");
            }
        }
*/
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {

                if (categoryId != null)
                {
                await _categoryService.DeleteCategory(categoryId);
                return RedirectToAction("GetAllCategoryDetails");
                }
                    return NotFound();

                // Assuming you have a different action for displaying all categories
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                ViewBag.ErrorMessage = "Error retrieving category for deletion.";
                return View("Error");
            }
        }


    }
}

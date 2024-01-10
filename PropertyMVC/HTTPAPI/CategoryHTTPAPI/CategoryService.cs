using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PropertyEntity;
using System.Text;

namespace PropertyMVC.HTTPAPI.CategoryHTTPAPI
{
    public class CategoryService : ICategoryService
    {
        const string BaseUrl = "https://localhost:7066/api/Category/";

        public async Task DeleteCategory(int categoryId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = BaseUrl + $"deleteCategory/{categoryId}";

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Category deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine($"Error deleting category. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }


        public async Task<IEnumerable<Category>> GetAllCategoryServiceApi()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = BaseUrl + "getAllCategoryDetails";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        IEnumerable<Category>? result = JsonConvert.DeserializeObject<IEnumerable<Category>>(responseBody);
                        return result ?? Enumerable.Empty<Category>();

                    }
                    else
                    {
                        return null;

                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = BaseUrl + $"getCategoryById/{categoryId}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Category result = JsonConvert.DeserializeObject<Category>(responseBody);
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Error getting category by ID. Status code: {response.StatusCode}");
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }
       
        public async Task InsertCategory(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = BaseUrl + "insertCategory";
                

                try
                {
                    string categoryJson = JsonConvert.SerializeObject(category);

                    StringContent content = new StringContent(categoryJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Category inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine($"Error inserting category. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

        public async Task UpdateCategory(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = BaseUrl + "updateCategory/{category}";

                try
                {
                    string categoryJson = JsonConvert.SerializeObject(category);

                    StringContent content = new StringContent(categoryJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Category updated successfully");
                    }
                    else
                    {
                        Console.WriteLine($"Error updating category. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
        }

    }
}

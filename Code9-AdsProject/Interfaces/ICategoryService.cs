using Code9_AdsProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code9_AdsProject.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int Id);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CreateCategoryAsync(Category category);
    }
}

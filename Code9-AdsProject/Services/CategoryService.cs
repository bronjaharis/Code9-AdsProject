using Code9_AdsProject.Data;
using Code9_AdsProject.Interfaces;
using Code9_AdsProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code9_AdsProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryAsync(int Id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<bool> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {

            _context.Categories.Update(category);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);

            if(category == null)
                return false;

            _context.Categories.Remove(category);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
    }
}

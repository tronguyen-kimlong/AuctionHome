using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class CategoryService : ICategory
    {
        private readonly AuctionContext _context;
        public CategoryService(AuctionContext context) { _context = context; }
        public async Task<bool> create(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> delete(Category category)
        {
            try { 
                _context.Categories.Remove(category); 
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }

        public async Task<bool> deleteAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Category>> getAll()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            } catch { return null; }
        }

        public async Task<Category> getByID(int id)
        {
            try
            {
                Category category = await _context.Categories.FindAsync(id);
                return category;
            } catch { return null; }
        }

        public async Task<bool> update(Category category)
        {
           try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

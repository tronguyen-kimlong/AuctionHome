using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AuctionHome.Repositories
{
    
    public class PaidItemsService : IPaidItems
    {
        private readonly AuctionContext _context;
        public PaidItemsService(AuctionContext auctionContext)
        {
            _context = auctionContext;
        }
        public async Task<bool> create(PaidItem paidItem)
        {
            try
            {
               _context.PaidItems.Add(paidItem);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }

        public async Task<bool> delete(PaidItem paidItem)
        {
            try
            {
                _context.PaidItems.Remove(paidItem);
                await _context.SaveChangesAsync();
                return true;

            } catch { return false;}
        }

        public async Task<List<PaidItem>> getAll()
        {
            try
            {
                return await _context.PaidItems.ToListAsync();
            } catch { return null; }
        }

        public async Task<PaidItem> getByID(int id)
        {
            try
            {
                PaidItem result = await _context.PaidItems.FindAsync(id);
                return result;
            } catch { return null; }
        }

        public async Task<List<PaidItem>> getByUsername(string username)
        {
            try
            {
                var itemiii = await _context.PaidItems
                    .Where(ii => ii.IdUser == username)
                    .Include(ii => ii.IdItemsNavigation)
                    .ThenInclude(ii => ii.IdCategoryNavigation)
                    .ToListAsync();
                return itemiii;
            } catch { return null; }
        }

        public async Task<bool> update(PaidItem paidItem)
        {
            try
            {
                _context.PaidItems.Update(paidItem);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class ListAuctioningService : IListAuctioning
    {
        private readonly AuctionContext _context;
        ListAuctioningService(AuctionContext context)
        {
            _context = context;
        }
        public async Task<bool> create(ListAuctioning listAuctioning)
        {
            try
            {
                _context.ListAuctionings.Add(listAuctioning);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> delete(ListAuctioning listAuctioning)
        {
            try
            {
                _context.ListAuctionings.Remove(listAuctioning);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }

        public async Task<bool> deleteAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ListAuctioning>> getAll()
        {
            try
            {
                return await _context.ListAuctionings.ToListAsync();
            } catch { return null; }
        }

        public async Task<ListAuctioning> getByID(int id)
        {
            try
            {
                var listAuctioning = await _context.ListAuctionings.FindAsync(id);
                return listAuctioning;
            } catch { return null; }
        }

        public async Task<bool> update(ListAuctioning listAuctioning)
        {
            try
            {
                _context.ListAuctionings.Update(listAuctioning);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

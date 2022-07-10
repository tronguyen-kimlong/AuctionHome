using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class MyAuctioningService : IMyAuctioning
    {
        private readonly AuctionContext _context;
        public MyAuctioningService(AuctionContext auction)
        {
            _context = auction;
        }

        public async Task<bool> addOrEdit(MyAuctioning myAuctioning)
        {
            try
            {
                if(myAuctioning != null)
                {
                    if(await getByID(myAuctioning.Id) != null)
                    {
                        // already exists, so update
                        await update(myAuctioning);
                        return true;
                    } else
                    {
                        // not exists, so create;
                        await create(myAuctioning);
                        return true;
                    }
                }
            } catch { return false; }
            return false;
        }

        public async Task<bool> create(MyAuctioning myAuctioning)
        {
           try
            {
                _context.MyAuctionings.Add(myAuctioning);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
            
        }

        public async Task<bool> delete(MyAuctioning myAuctioning)
        {
           try
            {
                _context.MyAuctionings.Remove(myAuctioning);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }

        public async Task<bool> deleteAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MyAuctioning>> getAll()
        {
            try
            {
                return await _context.MyAuctionings.ToListAsync();
            } catch { return null; }
        }

        public async Task<MyAuctioning> getByID(int id)
        {
            try
            {
                return await _context.MyAuctionings.FindAsync(id);
                
            } catch { return null; }
        }

        public async Task<bool> update(MyAuctioning myAuctioning)
        {
           try
            {
                _context.MyAuctionings.Update(myAuctioning);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

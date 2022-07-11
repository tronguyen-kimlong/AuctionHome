using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
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



        public async Task<MyAuctioning> getByIdItemAndIdUser(int idItem, string idUser)
        {
            try
            {
                if(idItem != 0 && idUser != null)
                {
                    var myAuctioning =  await _context.MyAuctionings
                    .Where(kk => kk.IdItem == idItem)
                    .Where(kk => kk.IdUser == idUser)
                    .FirstOrDefaultAsync();

                    return myAuctioning;
                }
            } catch { return null; }
            return null;
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
                var oldMyAuc = await getByID(myAuctioning.Id);
                oldMyAuc.IdItem = myAuctioning.IdItem;
                oldMyAuc.IdUser = myAuctioning.IdUser;
                oldMyAuc.Cost = myAuctioning.Cost;

                _context.MyAuctionings.Update(oldMyAuc);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
        public async Task<bool> updateCost(MyAuctioning myAuctioning, int cost)
        {
            try
            {
                var oldMyAuc = await getByID(myAuctioning.Id);
                oldMyAuc.Cost = cost;

                _context.MyAuctionings.Update(oldMyAuc);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public MyAuctioning new_IdItem_IdUser_Cost(int idItem, string idUser, int cost)
        {
            try
            {
                MyAuctioning newAuctioning = new MyAuctioning();
                newAuctioning.IdItem = idItem;
                newAuctioning.IdUser = idUser;
                newAuctioning.Cost = cost;
                return newAuctioning;

            }
            catch { return null; }
        }

       
    }
}

using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Library;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class ListAuctioningService : IListAuctioning
    {
        private readonly AuctionContext _context;
        public ListAuctioningService(AuctionContext context)
        {
            _context = context;
        }

        public async Task<bool> addOrEdit(ListAuctioning listAuctioning, string idMyAuctioning)
        {
            try
            {
                if(listAuctioning != null)
                {
                    if(await getByID(listAuctioning.Id) != null)
                    {
                        // already exists, so update
                        await update(listAuctioning, idMyAuctioning);
                        return true;
                    }
                    else
                    {
                        // not exists, so create;
                        await create(listAuctioning);
                        return true;
                    }
                }
            }
            catch { return false; }
            return false;
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

        public ListAuctioning newByIdItemAndArrayIdMyAuctioning(int idItem, string arrayId)
        {
            try
            {
                ListAuctioning newAuctioning = new ListAuctioning();
                newAuctioning.Id = idItem;
                newAuctioning.ArrayIdMyAuctioningString = arrayId;
                return newAuctioning;
            }
            catch { return null; }

        }

        public async Task<bool> removeMyAuctioning(ListAuctioning listAuctioning, string idMyAuctioning)
        {
            try
            {

                var oldList = await getByID(listAuctioning.Id);
                var stringAndList = new ConvertStringAndList();
                List<string> newList = new List<string>();
                if (oldList != null)
                {
                    newList = stringAndList.stringToList(oldList.ArrayIdMyAuctioningString);
                    if(newList.Count > 0)
                    {
                        newList.Remove(idMyAuctioning);
                    }
                }
               
                oldList.ArrayIdMyAuctioningString = stringAndList.listToString(newList);

                _context.ListAuctionings.Update(oldList);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> update(ListAuctioning listAuctioning, string idMyAuctioning)
        {
            try
            {
                
                var oldList = await getByID(listAuctioning.Id);
                //optimize the array Id Auctioning;
                List<string> newList = new List<string>();
                var stringAndList = new ConvertStringAndList();

                newList =stringAndList.stringToList(oldList.ArrayIdMyAuctioningString);
                // checking the id already exists yet;
                if (stringAndList.checkingAlreadyExistsItem(newList, idMyAuctioning) == false)
                {
                    newList.Add(idMyAuctioning);
                }
                   
               
                oldList.ArrayIdMyAuctioningString = stringAndList.listToString(newList);

                _context.ListAuctionings.Update(oldList);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

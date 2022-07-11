using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Library;
using AuctionHome.Models;
using AuctionHome.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class ItemService : IItem
    {
        private readonly AuctionContext _context;
        private readonly IMyAuctioning myAuctioningInterface;
        private readonly IListAuctioning listAuctioningInterface;

        public ItemService(AuctionContext context, IMyAuctioning myAuctioning, IListAuctioning listAuctioning)
        {
            _context = context;
            myAuctioningInterface = myAuctioning;
            listAuctioningInterface = listAuctioning;
           
        }

        public async Task<PagingItem> GetPagingItem(int currentPage=0)
        {

           var _paginItem = new PagingItem();
           int rowPerPage = 8;            
           if(currentPage < 1)
            {
                // get all
                _paginItem.Items = await _context.Items.ToListAsync();
                _paginItem.PageIndex = 0;
                _paginItem.PageTotal = 0;
              
            }
            else
            {
                // paging Items
                _paginItem.Items = await _context.Items
                    .Where(ii => ii.IsAccept == true)
                    .Where(ii => ii.Auction2 >= DateTime.Now)
                    .Skip((currentPage - 1)*rowPerPage)
                    .Take(rowPerPage).ToListAsync();
                _paginItem.PageIndex = currentPage;
                double total = (double)_paginItem.Items.Count()/rowPerPage;
                _paginItem.PageTotal = (int)Math.Ceiling(total); // round up
            }
            return _paginItem;
        }
        public async Task<bool> create(Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
            
        }
        public async Task<bool> update(Item item)
        {
            try
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

           
        }
        public async Task<bool> delete(Item item)
        {
            try
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }catch { return false; }
        }

        public Task<bool> deleteAll()
        {
            throw new System.NotImplementedException();
        }

        // đây là FC  get Item bởi ID cho trước
        public async Task<Item> getByID(int id)
        {
            try
            {
                return await _context.Items.FindAsync(id);
            }
            catch { return null; }
           
        }

        public async Task<Item> getByIDAsync(int id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);
                return item;
            }
            catch { return null;}
        }

        public async Task<bool> updateDescription(Item item)
        {
            if(item == null) { return false; }
            try
            {
                //var tempItem = await _context.Items.FindAsync(item.Id);
                var tempItem = await getByID(item.Id);

                tempItem.Description = item.Description;

                _context.Items.Update(tempItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        // đây là FC lưu tất cả các trường của Item mà không cần tải lại hình ảnh.
        public async Task<bool> updateWithoutImage(Item item)
        {
            if (item == null) { return false; }
            try
            {              
                var tempItem = await getByID(item.Id); //  gọi Item trước đó
                                                       
                // gán Item (giá trị mới) cho giá trị tạm khởi tạo
                tempItem.Auction2 = item.Auction2;
                tempItem.Description = item?.Description;
                tempItem.IsAccept = item.IsAccept;
                tempItem.IsPaid = item.IsPaid;  
                tempItem.IsSold = item.IsSold;
                tempItem.Price = item.Price;
                tempItem.PriceAuction = item.PriceAuction;
                tempItem.PriceBuyNow = item.PriceBuyNow;             
                _context.Items.Update(tempItem); // nếu truyền temItem thì lưu bình thường,
                                                 // nhưng làm hơi lâu một tí.

                await _context.SaveChangesAsync(); // lưu thành công.
                return true;
            }
            catch { return false; }

        }

        public async Task<bool> isMyItem(string usernameClaim, int id)
        {
            try
            {
                var item = await getByID(id);
                if(item.IdUser == usernameClaim) { return true; }
            } catch { return false; }
            return false;
        }

        public long getAuctionTime(Item item)
        {
            long timetimeAuctionSeconds = 0;
            try
            {
                DateTime dateTimeNow = DateTime.Now;           
                
                if (item.Auction2 != null)
                {
                    TimeSpan dateDate = ((TimeSpan)(item.Auction2 - dateTimeNow));
                    timetimeAuctionSeconds =                        
                        + dateDate.Days * 1000000
                        + dateDate.Hours * 10000
                        + dateDate.Minutes * 100
                        + dateDate.Seconds;


                    // timetimeAuctionSeconds = long.Parse(date.ToString("yyyyMMddHHmmss"));
                    return timetimeAuctionSeconds;
                }
            }
            catch { return timetimeAuctionSeconds; }
            return timetimeAuctionSeconds;
        }

        public async Task<bool> updatePriceAuction(Item item, decimal priceAuction)
        {
            try
            {
                var oldItem = item;
                // query where idItem = 6(example) that in myAuctioning DB;
                var newListAuctioning = await listAuctioningInterface.getByID(item.Id);
                string arrayIdMyAuctioningString = newListAuctioning.ArrayIdMyAuctioningString;
                var arrayList = new ConvertStringAndList().stringToList(arrayIdMyAuctioningString);

               
                List<decimal> costList = new List<decimal>();
                foreach(var id in arrayList)
                {
                    var newMyAuctioning = await myAuctioningInterface.getByID((int)long.Parse(id));
                    decimal cost = (decimal)newMyAuctioning.Cost;
                   
                    costList.Add(cost);

                }
                // find seconds costMax;
                costList.Sort(); // increasing;
                costList.Reverse(); // decreasing;

                decimal costSecondsMax = -999;
                if(costList.Count == 1)
                {
                    costSecondsMax = costList[0];
                }
                else
                {
                    costSecondsMax = costList[1];
                }
                decimal disCount = (decimal)(oldItem.Discount / 100 * oldItem.PriceAuction + 5);
                oldItem.PriceAuction = costSecondsMax + disCount; // that is the line to update Price Auction

                _context.Update(oldItem);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }
    }
}

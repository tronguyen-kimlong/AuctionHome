using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IPaidItems
    {
        Task<PaidItem> getByID(int id);
        Task<List<PaidItem>> getAll();

        Task<bool> update(PaidItem paidItem);
        Task<bool> delete(PaidItem paidItem);
        
        Task<bool> create(PaidItem paidItem);
    }
}


using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AuctionHome.Interfaces
{
    public interface IMyAuctioning
    {
        Task<MyAuctioning> getByID(int id);
        Task<List<MyAuctioning>> getAll();

        Task<bool> update(MyAuctioning myAuctioning);
        Task<bool> delete(MyAuctioning myAuctioning);
        Task<bool> deleteAll();
        Task<bool> create(MyAuctioning myAuctioning);
        Task<bool> addOrEdit(MyAuctioning myAuctioning);
    }
}

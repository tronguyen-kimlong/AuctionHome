
using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AuctionHome.Interfaces
{
    public interface IMyAuctioning
    {
        Task<MyAuctioning> getByID(int id);
        Task<List<MyAuctioning>> getAll();
        Task<List<MyAuctioning>> getByUser(string username);

        Task<bool> update(MyAuctioning myAuctioning);
        Task<bool> updateCost(MyAuctioning myAuctioning, int cost);
        Task<bool> delete(MyAuctioning myAuctioning);
        Task<bool> deleteAll();
        Task<bool> create(MyAuctioning myAuctioning);
        Task<bool> addOrEdit(MyAuctioning myAuctioning);
        Task<MyAuctioning> getByIdItemAndIdUser(int idItem, string idUser);

        MyAuctioning new_IdItem_IdUser_Cost(int idItem, string idUser, int cost);
        
    }
}

using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IListAuctioning
    {
        Task<ListAuctioning> getByID(int id);
        Task<List<ListAuctioning>> getAll();

        Task<bool> update(ListAuctioning listAuctioning, string idMyAuctioning);
        Task<bool> delete(ListAuctioning listAuctioning);
        Task<bool> deleteAll();
        Task<bool> create(ListAuctioning listAuctioning);
        Task<bool> addOrEdit(ListAuctioning listAuctioning,  string idMyAuctioning);

        ListAuctioning newByIdItemAndArrayIdMyAuctioning(int idItem, string arrayId);
    }
}

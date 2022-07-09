using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface ICategory
    {

        Task<Category> getByID(int id);
        Task<List<Category>> getAll();
        
        Task<bool> update(Category category);
        Task<bool> delete(Category category);
        Task<bool> deleteAll();
        Task<bool> create(Category category);
    }
}

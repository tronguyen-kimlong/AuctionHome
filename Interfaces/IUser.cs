using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IUser
    {
        Task<User> getByUsername(string username);
        Task<List<User>> getAll();
        Task<bool> update(User user);
        Task<bool> delete(User user);
        
        Task<bool> create(User user);

        Task<bool> deleteAll();

        Task<bool> decryptPassword(User user);
    }
}

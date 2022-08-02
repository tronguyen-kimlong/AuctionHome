using Auction.Libraries.HashPassword;
using AuctionHome.Data;
using AuctionHome.Interfaces;
using AuctionHome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Repositories
{
    public class UserService : IUser
    {
        private readonly AuctionContext _context;
        public UserService(AuctionContext context) { _context = context; }
        public async Task<bool> create(User user)
        {
            
                user.Password = new HashPassword().EncryptString(user.Password); // encrypt pass word string;
                _context.Users.Add(user); // save the user to the database;
                await _context.SaveChangesAsync();
                return true;
            

        }

        public async Task<bool> decryptPassword(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> delete(User user)
        {
            try 
            { 
                _context.Users.Remove(user);
                await  _context.SaveChangesAsync();
                return true;
            } catch { return false; }
        }

        public async Task<bool> deleteAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<User>> getAll()
        {
            try
            {

                return await _context.Users.ToListAsync();
            }
            catch 
            {
                return null; 
            }
        }

        public async Task<User> getByUsername(string username)
        {
           try
            {
                var user = await _context.Users.FindAsync(username);
                return user;
            }
            catch { return null; }
        }

        public async Task<bool> update(User user)
        {
            try
            {
                user.Password = new HashPassword().EncryptString(user.Password); // encrypt pass word string;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            } catch { return false; }

        }
    }
}

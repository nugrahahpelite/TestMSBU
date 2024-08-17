using Microsoft.EntityFrameworkCore;
using WebApplicationLogin.Models;
using WebApplicationLogin.Services.Contract;

namespace WebApplicationLogin.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly MSBU _dbContext; // Reference to the database

        public UserService(MSBU dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> GetUser(string username, string password)
        {
            User getUser = await _dbContext.User.Where(u=>u.username == username && u.password == password).FirstOrDefaultAsync();

            return getUser;
        }

        public async Task<User> SaveUser(User model)
        {
            _dbContext.User.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}

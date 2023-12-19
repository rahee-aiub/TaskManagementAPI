using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class UserService : IUserService
    {
        //private readonly List<UserModel> _users = new List<UserModel>();
        //private int _userIdCounter = 1;

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> RegisterUser(UserModel user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {             
                return null;
            }


            _context.Users.Add(user);
            _context.SaveChanges();

            return await Task.FromResult(user);
        }

        public async Task<UserModel> AuthenticateUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return await Task.FromResult(user);
        }
    }
}

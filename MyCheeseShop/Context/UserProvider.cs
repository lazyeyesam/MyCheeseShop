using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public User? GetUserByUsername(string? username)
        {
            // Return the user with the specified username
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        public async Task<User?> GetUserByIdAsync(string? id)
        {
            // Return the user with the id
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> IsAdmin(User user)
        {
            // Check if the user is an admin
            return await _userManager.IsInRoleAsync(user, "Admin");
        }

        public async Task MakeAdmin(User user)
        {
            // Add the user to the admin role
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        public async Task RemoveAdmin(User user)
        {
            // Remove the user from the admin role
            await _userManager.RemoveFromRoleAsync(user, "Admin");
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Return all users
            return await _context.Users.Include(user => user.Orders)
                         .OrderBy(user => user.LastName).ToListAsync();
        }
    }
}

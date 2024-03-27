using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;

        public UserProvider(DatabaseContext context)
        {
            _context = context;
        }

        public User? GetUser(string username)
        {
            // Return the user with the specified username
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }
    }
}

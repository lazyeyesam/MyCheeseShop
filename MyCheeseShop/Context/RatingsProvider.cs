using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class RatingsProvider
    {
        private readonly DatabaseContext _context;

        public RatingsProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddRatingAsync(Cheese cheese, User user, int stars)
        {
            // if the user has already rated this cheese, update the rating else add a new rating
            var rating = _context.Ratings.FirstOrDefault(r => r.Cheese == cheese && r.User == user);
            if (rating != null)
            {
                rating.Stars = stars;
            }
            else
            {
                rating = new Rating { Cheese = cheese, User = user, Stars = stars };
                _context.Ratings.Add(rating);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rating>> GetRatingsAsync(Cheese cheese)
        {
            var ratings = await _context.Ratings.Where(r => r.Cheese == cheese).ToListAsync();
            return ratings;
        }

        public Rating? GetUserRating(Cheese cheese, User user)
        {
            return _context.Ratings.FirstOrDefault(r => r.Cheese == cheese && r.User == user);
        }
    }
}

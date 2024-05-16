namespace MyCheeseShop.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public Cheese Cheese { get; set; }
        public User User { get; set; }
    }
}

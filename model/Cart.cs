using System.Windows.Media.Animation;

namespace MarkEdPlace.model
{
    internal class Cart
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public uint Quantity { get; set; } = 1;
        public float Summary => Product.Cost * Quantity;

        public Cart() { }
        public Cart(User user, Product product, uint quantity = 1)
        {
            User = user;
            Product = product;
            Quantity = quantity;
        }
        public Cart(int userID, int productID, uint quantity = 1)
        {
            UserID = userID;
            ProductID = productID;
            Quantity = quantity;
        }
    }
}

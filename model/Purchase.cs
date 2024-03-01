namespace MarkEdPlace.model
{
	internal class Purchase
	{
		public int ID { get; set; }
		public int UserID { get; set; }
		public User User { get; set; }
		public int ProductID { get; set; }
		public Product Product { get; set; }
		public DateTime DateTime { get; set; }
		public uint Quantity { get; set; }

		public Purchase(User user, Product product, uint quantity)
		{
			User = user;
			Product = product;
			Quantity = quantity;
			DateTime = DateTime.Now;
		}
		public Purchase(int userID, int productID, uint quantity)
		{
			UserID = userID;
			ProductID = productID;
			Quantity = quantity;
			DateTime = DateTime.Now;
		}
	}
}
namespace MarkEdPlace.model
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public float Cost { get; set; }
        public uint Quantity { get; set; }
        public int VendorID { get; set; }
        public Vendor Vendor { get; set; }

        public Product() { }

        public Product(string name, float cost, uint quantity)
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }

        public Product(string name, float cost, uint quantity, int vendorID) : this(name, cost, quantity)
        {
            VendorID = vendorID;  
        }
    }
}

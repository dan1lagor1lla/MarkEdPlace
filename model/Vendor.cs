namespace MarkEdPlace.model
{
    internal class Vendor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Vendor(string name)
        {
            Name = name;
        }
    }
}

public class Item
{
    public double id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public Item(double id = 0,
                string Name = "",
                int Quantity = 0,
                float Price = 0)
    {
        this.id = id;
        this.Name = Name;
        this.Quantity = Quantity;
        this.Price = Price;
    }
}



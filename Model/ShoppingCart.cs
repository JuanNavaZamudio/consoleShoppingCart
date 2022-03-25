public class ShoppingCart
{
    public DateTime PurchaseDate { get; set; }
    public List<Item> Items { get; set; }
    public float TotalPurshase { get; set; }

    public ShoppingCart()
    {
        this.Items = new List<Item>();
        this.TotalPurshase = 0;
    }

    public void AddItem(Item NewItem)
    {
        Item itemExists = Items.Find(item => item.id == NewItem.id);
        if (itemExists != null)
            itemExists.Quantity++;
        else
            this.Items.Add(NewItem);
    }

    public bool Purchase()
    {
        this.PurchaseDate = DateTime.Now;
        return true;
    }

    public int GetItemQuantity()
    {
        int TotalItems = 0;
        this.Items.ForEach(item => TotalItems += item.Quantity);
        return TotalItems;
    }

    public float GetTotalPurchase()
    {
        return this.Items.Aggregate(0.0f,
        (tot, item) => tot + (item.Quantity * item.Price));
    }
}
public class ItemsProvider
{
    public List<Item> getAllItems()
    {
        List<Item> items = new List<Item>();
        items.Add(new Item(1, "Item1", 10, 1.99f));
        items.Add(new Item(2, "Item2", 6, 10.50f));
        items.Add(new Item(3, "Item3", 5, 15.0f));
        items.Add(new Item(4, "Item4", 7, 9.0f));
        items.Add(new Item(5, "Item5", 8, 39.5f));
        return items;
    }
}
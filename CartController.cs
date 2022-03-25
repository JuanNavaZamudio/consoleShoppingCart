public class CartController
{
    ShoppingCart cart;
    ItemsProvider itemsAvailable;
    public CartController()
    {
        this.cart = new ShoppingCart();
        itemsAvailable = new ItemsProvider();
    }

    enum MenuOptions { AddItem = 1, Purchase = 2, GetTotalItems = 3, GetTotalPurchase = 4, Exit = 5, NotValid = 0 }

    public void run()
    {
        MenuOptions selected = 0;
        do
        {
            Console.WriteLine("Welcome, choose an option");
            printOptions();
            selected = (MenuOptions)GetUserInput();
            switch (selected)
            {
                case MenuOptions.AddItem:
                    AddItem();
                    break;
                case MenuOptions.Purchase:
                    Purchase();
                    break;
                case MenuOptions.GetTotalItems:
                    GetTotalItems();
                    break;
                case MenuOptions.GetTotalPurchase:
                    GetTotalPurchase();
                    break;
                case MenuOptions.Exit:
                    Console.WriteLine("Have a nice day!");
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        } while (selected != MenuOptions.Exit);
    }

    private void GetTotalPurchase()
    {
        Console.WriteLine($"the total is: ${this.cart.GetTotalPurchase()}");
    }

    private void GetTotalItems()
    {
        Console.WriteLine($"The total items in the cart are: {this.cart.GetItemQuantity()}");
    }

    private void Purchase()
    {
        float total = this.cart.GetTotalPurchase();
        bool successSale = this.cart.Purchase();
        if (successSale)
        {
            Console.WriteLine($"Purchase successful, total: ${total}");
            this.cart.Items.Clear();
            this.cart.TotalPurshase = 0;
        }
        else
        {
            Console.WriteLine("Purchase failed");
        }
    }

    private void AddItem()
    {
        printItemsAvailable();
        Console.WriteLine("choose the item you want to add");

        Item itemSelected = GetSelectedUserItem();
        if(itemSelected == null)
        {
            Console.WriteLine("Not a valid item");
            return;
        }

        Item oneItem = new Item(itemSelected.id, itemSelected.Name, 1, itemSelected.Price);
        itemSelected.Quantity--;

        this.cart.AddItem(oneItem);
    }

    private Item GetSelectedUserItem()
    {
        int itemSelected = GetUserInput();
        return  itemsAvailable.getAllItems().Find(item => item.id == itemSelected);
    }

    private void printItemsAvailable()
    {
        itemsAvailable.getAllItems().ForEach(
            item => Console.WriteLine($" id:{item.id} - {item.Name} - ${item.Price} - Available:{item.Quantity}")
            );
    }

    void printOptions()
    {
        Console.WriteLine("1) Add an item");
        Console.WriteLine("2) buy cart");
        Console.WriteLine("3) Get total items");
        Console.WriteLine("4) Get total purchase");
        Console.WriteLine("5) Exit");
    }

    int GetUserInput()
    {
        try
        {
            return Convert.ToInt32((Console.ReadLine()));
        }
        catch
        {
            return 0;
        }
    }


}
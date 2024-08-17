namespace delegates;

class Program
{
    static ShoppingCartModel cart = new ShoppingCartModel();

    static void Main(string[] args)
    {
        // SimpleDelegates simpleDelegates = new SimpleDelegates();

        // simpleDelegates.Print("Hello World!");

        // simpleDelegates.ConnectToDatabase(simpleDelegates.PrintConsole);

        PopulateCartWithDemoData();

        System.Console.WriteLine(
            $"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalcualteLeveledDiscount, AlertUser):C2}"
        );

        // Call delegates inline
        decimal total = cart.GenerateTotal(
            (subTotal) => System.Console.WriteLine($"The subtotal for cart 2 is {subTotal}"),
            (products, subTotal) =>
            {
                if (products.Count > 3)
                {
                    return subTotal * 0.5M;
                }
                else
                {
                    return subTotal;
                }
            },
            (message) => System.Console.WriteLine($"Cart 2 Alert: {message}")
        );
        System.Console.WriteLine($"The total for the cart is {total:C2}");
    }

    private static void SubTotalAlert(decimal subTotal)
    {
        System.Console.WriteLine($"The subtotal is {subTotal:C2}");
    }

    private static void AlertUser(string message)
    {
        System.Console.WriteLine(message);
    }

    private static decimal CalcualteLeveledDiscount(List<ProductModel> items, decimal subTotal)
    {
        if (subTotal > 100)
        {
            return subTotal * 0.80M;
        }
        else if (subTotal > 50)
        {
            return subTotal * 0.85M;
        }
        else if (subTotal > 10)
        {
            return subTotal * 0.90M;
        }
        else
        {
            return subTotal;
        }
    }

    private static void PopulateCartWithDemoData()
    {
        cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
        cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
        cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
        cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
    }
}

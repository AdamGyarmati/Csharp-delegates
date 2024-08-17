namespace delegates;

public class ShoppingCartModel
{
    // Almost like an interface
    public delegate void MentionDiscount(decimal subTotal);

    public List<ProductModel> Items { get; set; } = new List<ProductModel>();

    // Calculate discount
    public decimal GenerateTotal(
        MentionDiscount mentionDiscount,
        Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
        Action<string> alertUserAboutDiscounting
    )
    {
        decimal subTotal = Items.Sum(x => x.Price);

        // GenerateTotal metódusnak nincs fogalma hogy mit csinál ez a method. Loosly coupled.
        // Majd kapni fog egy metódust ami csinál valamit a subtotal-al.
        mentionDiscount(subTotal);

        alertUserAboutDiscounting("We are apllying your discount.");

        // if (subTotal > 100)
        // {
        //     return subTotal * 0.80M;
        // }
        // else if (subTotal > 50)
        // {
        //     return subTotal * 0.85M;
        // }
        // else if (subTotal > 10)
        // {
        //     return subTotal * 0.90M;
        // }
        // else
        // {
        //     return subTotal;
        // }

        return calculateDiscountedTotal(Items, subTotal);
    }
}

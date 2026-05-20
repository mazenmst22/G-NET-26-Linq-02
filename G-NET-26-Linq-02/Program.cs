using static G_NET_26_Linq_02.Data_Source.Source;
namespace G_NET_26_Linq_02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Q1
            var top3 = ProductList
                .OrderByDescending(p => p.UnitPrice)
                .Take(3);
            foreach (var product in top3)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice}");
            }
            #endregion
        }
    }
}

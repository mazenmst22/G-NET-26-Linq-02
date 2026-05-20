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
                Console.WriteLine($"Name: {product.ProductName}, Price: ${product.UnitPrice}");
            }
            #endregion
            #region Q2
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            int pageNo = 2, pageSize = 5;
            var pageProducts = ProductList
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize);
            foreach (var item in pageProducts)
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: ${item.UnitPrice}");
            }
            #endregion
            #region Q3
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var price25 = ProductList
                .OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);
            foreach (var item in price25)
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: ${item.UnitPrice}");
            }
            #endregion
            #region Q4
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            bool allSeafood = ProductList
                .Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);
            if (allSeafood)
            {
                Console.WriteLine("All Seafood products are currently in stock.");
            }
            else
            {
                Console.WriteLine("Some Seafood products are out of stock.");
            }
            #endregion


        }
    }
}

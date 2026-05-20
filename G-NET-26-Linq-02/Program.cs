using G_NET_26_Linq_02.Models;
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
            #region Q5
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            int[] ids = { 3, 9, 13, 18 };
            bool contains9 = ids.Contains(9);
            Console.WriteLine(contains9);
            #endregion
            #region Q6
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var groupedProducts = ProductList.GroupBy(p => p.Category);

            foreach (var g in groupedProducts)
            {
                Console.WriteLine($"Category: {g.Key}, Product Count: {g.Count()}");
            }
            #endregion
            #region Q7
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var groupedNames = ProductList
                .GroupBy(P => P.Category, P => P.ProductName);
            foreach(var g in groupedNames)
            {
                Console.WriteLine($"Category: {g.Key}");
                foreach (var name in g)
                {
                    Console.WriteLine($"  - {name}");
                }
                Console.WriteLine("=============================");
            }
            #endregion
            #region Q8
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var CategoryMoreThan3 = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Count() > 3);
            foreach (var g in CategoryMoreThan3)
            {
                Console.WriteLine($"Category: {g.Key}, Product Count: {g.Count()}");
            }
            #endregion
            #region Q9
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var customerStats = from c in CustomerList
                                group c by c.Country
                                into g
                                select new
                                {
                                    Country = g.Key,
                                    Count = g.Count(),
                                    TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                                };

            foreach (var s in customerStats)
            {
                Console.WriteLine($"Country: {s.Country}, Count: {s.Count}, Total Value: ${s.TotalOrderValue}");
            }
            #endregion
            #region Q10
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            int totalUnits = ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine($"Total units in stock: {totalUnits}");
            #endregion
            #region Q11
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var cheapest = ProductList.Min(p => p.UnitPrice);
            var mostExpensive = ProductList.Max(p => p.UnitPrice);
            Console.WriteLine($"Cheapest price: ${cheapest}, Most Expensive price: ${mostExpensive}");
            #endregion
            #region Q12
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            var distinctCategories = ProductList
                                    .Select(p => p.Category)
                                    .Distinct();

            foreach (var c in distinctCategories)
            {
                Console.Write($"{c}, ");
            }
            #endregion
            #region Q13
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var uniqueToSetA = setA.Except(setB);

            Console.WriteLine("Product IDs in A and not in B:");
            foreach (var id in uniqueToSetA)
            {
                Console.WriteLine(id);
            }
            #endregion 
        }
    }
}

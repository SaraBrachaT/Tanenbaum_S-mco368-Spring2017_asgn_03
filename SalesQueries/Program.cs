using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQueries
{
    class Program
    {
        static double TotalProfit(Sale[] sales, Func<Sale, bool> include, Func<Sale, double> findProfit, Action<Sale, double> listItemsandProfit,
            Action<Sale> listItems)
        {
            //This is calculating the profit made on small sales

            List<Sale> smallSales = new List<Sale>();
            Double totalProfit = 0.0;
            foreach (var sale in sales)
            {
                if (include(sale))
                {
                    Double profit = findProfit(sale);
                    listItemsandProfit(sale, profit);
                    totalProfit += profit;
                }
                else
                {
                    listItems(sale);
                }
            }
            return totalProfit;
        }



        static void Main(string[] args)
        {
            Sale[] Sales = new Sale[5];

            Sales[0] = new Sale();
            Sales[0].Address = "750 Mador Ct.";
            Sales[0].Customer = "TovaLLC";
            Sales[0].ExpeditedShipping = true;
            Sales[0].Item = "Apple";
            Sales[0].PricePerItem = 15;
            Sales[0].Quantity = 5;

            Sales[1] = new Sale();
            Sales[1].Address = "26 Cabinfield Circle";
            Sales[1].Customer = "SBK";
            Sales[1].ExpeditedShipping = false;
            Sales[1].Item = "Coffee";
            Sales[1].PricePerItem = 5;
            Sales[1].Quantity = 1;

            Sales[2] = new Sale();
            Sales[2].Address = "1352 E23 St.";
            Sales[2].Customer = "Tovallc";
            Sales[2].ExpeditedShipping = true;
            Sales[2].Item = "Coffee";
            Sales[2].PricePerItem = 9;
            Sales[2].Quantity = 1;

            Sales[3] = new Sale();
            Sales[3].Address = "1448 E23 St.";
            Sales[3].Customer = "LLCBracha";
            Sales[3].ExpeditedShipping = false;
            Sales[3].Item = "Tea";
            Sales[3].PricePerItem = 89;
            Sales[3].Quantity = 10;

            Sales[4] = new Sale();
            Sales[4].Address = "1552 E23 St.";
            Sales[4].Customer = "Sara";
            Sales[4].ExpeditedShipping = true;
            Sales[4].Item = "Tea";
            Sales[4].PricePerItem = 8;
            Sales[4].Quantity = 10;


            /*Part 1
             * var results =
                from s in Sales
                where s.PricePerItem > 10.0
                select s;
            display(results);


            var query2 =
                from s in Sales
                where s.Quantity == 1
                orderby s.PricePerItem descending
                select s;

            display(query2);

            var query3 =
                from s in Sales
                where s.Item == "Tea" && s.ExpeditedShipping == false
                select s;

            display(query3);

            var query4 =
                from s in Sales
                where (s.PricePerItem * s.Quantity) > 100.0
                select s.Address;

            display(query4);

            var query5 =
                from s in Sales
                where s.Customer.Contains("LLC") || s.Customer.Contains("llc")
                select new
                {
                    s.Item,
                    TotalPrice = s.PricePerItem * s.Quantity,
                    Shipping = s.ExpeditedShipping ? s.Address : s.Address + " EXPEDITE"
                };
            query5 = query5.OrderBy(s => s.TotalPrice);

            display(query5);

             var priceOverTen = Sales.Where(s => s.PricePerItem > 10.0);
             display(priceOverTen);
             var quantityOne = Sales.Where(s => s.Quantity == 1)
                 .OrderByDescending(s => s.PricePerItem);
             display(priceOverTen);
             var teaNoExShipping = Sales.Where(s => s.Item == "Tea" && s.ExpeditedShipping == false);
             display(teaNoExShipping);
             var addressOrderOver100 = Sales.Where(s => (s.PricePerItem * s.Quantity) > 100.0)
                 .Select(s => s.Address);
             display(addressOrderOver100);
             var numberFive = Sales.Where(s => s.Customer.Contains("LLC") || s.Customer.Contains("llc"))
                 .Select(s => new
                 {
                     s.Item,
                     TotalPrice = s.PricePerItem * s.Quantity,
                     Shipping = s.ExpeditedShipping ? s.Address : s.Address + " EXPEDITE"
                 })
                 .OrderBy(s => s.TotalPrice);

             display(numberFive);*/

            //Part 2
 
            Console.WriteLine("Total Profit: " + TotalProfit(Sales, s => s.PricePerItem < 10,
                s => .9 * s.PricePerItem * s.Quantity,
                (sale, d) =>  Console.WriteLine("Item: {0} \tProfit: {1}", sale.Item, d),
                (sale) => Console.WriteLine("{0} not included in calculation", sale.Item)));

            Console.WriteLine("");

            Console.WriteLine("Total Profit: " + TotalProfit(Sales, s => s.Item == "Coffee", s => .8 * s.PricePerItem * s.Quantity, 
                (sale, d) => Console.WriteLine("Coffee item for {0}, total profit: {1}", sale.Customer, d),
                (sale) => Console.WriteLine("Non-coffee item, skipping")));

            Console.WriteLine("");

            Console.WriteLine("Total Profit: " + TotalProfit(Sales, s => s.Quantity > 1, s => s.PricePerItem * s.Quantity + (s.ExpeditedShipping? 0 : 20),
                                  (sale, d) => Console.WriteLine(sale.ExpeditedShipping? "" : "Expedited shipping sale of {0} - Extra $20 profit", sale.Item),
                                  (sale) => Console.WriteLine("Single order item, skipping")));

            Console.ReadKey();
        }



        static void display(IEnumerable<Object> results)
        {
            foreach (var variable in results)
            {
                Console.WriteLine(variable);
            }
            Console.ReadKey();
        }
    }
}

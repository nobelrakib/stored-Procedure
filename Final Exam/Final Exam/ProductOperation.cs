using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Final_Exam
{
    public class ProductOperation : IProductModel
    {
        public static List<Product> products=new List<Product>();
        public static List<string> Productcode= new List<string>();
        public static List<int> price= new List<int>();
        public void AddingProduct()
        {
            var product = new Product();
            Console.WriteLine("ProductCode");
            product.Code = Console.ReadLine();
            Console.WriteLine("ProductName");
            product.Name = Console.ReadLine();
            Console.WriteLine("ProductPrice");
            product.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ProductStock");
            product.RemainingStock = Convert.ToInt32(Console.ReadLine());
            
            products.Add(product);
            Console.WriteLine("Product added successfull");
        }
        public void ShowProduct()
        {
            foreach(var item in products)
            {
                Console.WriteLine("Code : " + item.Code + "  " + " Name : " + item.Name + " price : " + item.Price + " stock : " + item.RemainingStock);
            }
        }
        public void DeleteProduct()
        {
            Console.WriteLine("ProductCode");
            string code = Console.ReadLine();
            var result = products.Where(x => x.Code == code).FirstOrDefault();
            products.Remove(result);
            Console.WriteLine("Sucessfully deleted product");
        }
        public void BuyProduct()
        {
           // var product = new Product();
            Console.WriteLine("ProductCode");
            string code = Console.ReadLine();
            //Console.WriteLine("ProductName");
            Console.WriteLine("ProductQuantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            var result1 = products.Where(x => x.Code == code).FirstOrDefault();
            var result2 = result1;
            if (result2.RemainingStock >= quantity)
            {
                Console.WriteLine("Product bought successfull");
                result2.RemainingStock = result2.RemainingStock - quantity;
                price.Add(quantity * result2.Price);
                Productcode.Add(result2.Code);
                products.Remove(result1);
                products.Add(result2);
            }
            else Console.WriteLine("Sorry given quantity is not available on stock");
        }
        public void totalprice()
        {
            Console.WriteLine("totalprice "+price.Sum());
            
        }
        public void boughtproduct()
        {
            foreach (var code in Productcode)
            {
                var item = products.Where(x => x.Code == code).FirstOrDefault();
                Console.WriteLine("Code : " + item.Code + "  " + " Name : " + item.Name + " price : " + item.Price + " stock : " + item.RemainingStock);
            }
        }
    }
}

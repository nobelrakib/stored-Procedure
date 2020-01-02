using System;

namespace Final_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("select option");
                Console.WriteLine("1: Add Product to Store");
                Console.WriteLine(" 2: Show Product List of Store");
                // Console.WriteLine(" 3: Show Product List of Store");
                Console.WriteLine(" 3: Bye product");
                Console.WriteLine(" 4: Show all bought Product List ");
                Console.WriteLine(" 5: Show total price of all bought product");
                Console.WriteLine(" 6: Delete a product from Store");
                Console.WriteLine(" 7: Exit");
                int check = Convert.ToInt32(Console.ReadLine());
                if (check == 1) new ProductOperation().AddingProduct();
                else if (check == 2) new ProductOperation().ShowProduct();
                else if (check == 3) new ProductOperation().BuyProduct();
                else if (check == 4) new ProductOperation().boughtproduct();
                else if (check == 5) new ProductOperation().totalprice();
                else if (check == 6) new ProductOperation().DeleteProduct();
                else break;

            }


        }
    }
}

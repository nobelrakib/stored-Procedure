using System;

namespace problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please give number");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            s= new string(arr);
        
           int num= Convert.ToInt32(s);
            int  flag = 0;
           // int.TryParse(input1, out size); //Console.WriteLine(size);
           // int num = size;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0) { flag++; }
            }
            if (flag == 2) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}

using System;

namespace problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("give dimension");
            int num = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[num, num];
            for(int i = 0; i < num; i++)
            {
                for(int j=0;j<num;j++)
                {
                    a[i,j]= Convert.ToInt32(Console.ReadLine());
                }
            }
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i == j) sum = sum + a[i, j];
                }
            }
            for (int i = num-1; i >=0; i--)
            {
                for (int j = num-1; j >=0; j--)
                {
                    if (i == j) sum = sum + a[i, j];
                }
            }
            Console.WriteLine(sum);
        }
    }
}

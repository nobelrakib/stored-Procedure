using System;

namespace problems
{
    class Program
    {
        static void Main(string[] args)
        {
            string year;
            int intyear;
            do
            {
                Console.WriteLine("please give year");
                year = Console.ReadLine();
                intyear = Convert.ToInt32(year);
                if (intyear >= 1971 && intyear <= 2019)
                {
                    char a = year[2];
                    char b = year[3];
                    year = "" + a + b;
                }
                else Console.WriteLine("Invalid year");
            } while (intyear < 1971 || intyear > 2019);
            
            string month;
            int intmonth;
            do
            {
                Console.WriteLine("please give month");
                month = Console.ReadLine();
                intmonth = Convert.ToInt32(month);
                if (intmonth < 1 && intmonth > 12)
                {
                    Console.WriteLine("Invalid month");
                }
            }
            while (intmonth < 1 || intmonth > 12);


            string day;
            int intday;
            do
            {
                Console.WriteLine("please give day");
                day = Console.ReadLine();
                intday = Convert.ToInt32(day);
                if (intmonth == 2 && intday > 28)
                {
                    Console.WriteLine("invalid day");
                }
                else if ((intmonth == 4 || intmonth == 6 || intmonth == 9 || intmonth == 11) && intday > 30)
                {
                    Console.WriteLine("invalid day");
                }
                else if ((intmonth == 1 || intmonth == 3 || intmonth == 5 || intmonth == 7 || intmonth == 8 || intmonth == 10 || intmonth == 10) && intday > 31)
                {
                    Console.WriteLine("invalid day");
                }
                else if(intday<1) Console.WriteLine("invalid day");
            } while ((intmonth == 2 && intday > 28) || (intday < 1)||((intmonth == 4 || intmonth == 6 || intmonth == 9 || intmonth == 11) && intday > 30) || ((intmonth == 1 || intmonth == 3 || intmonth == 5 || intmonth == 7 || intmonth == 8 || intmonth == 10 || intmonth == 10) && intday > 31));

            Console.WriteLine("your date" + intday + "-" + intmonth + "-" + intyear);




        }
    }
}

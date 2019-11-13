using System;
using System.Collections.Generic;
using System.Text;

namespace StockApi.Client
{
    class Messege
    {
        public void MessegeForEntireProgramme()
        {
            string msg = @"press 1 : Create Company
                         press 2 :Delete Company 
                         press 3 : Update Company
                         press 4 :Get ListOf Company
                         press 5 :Get Single Company
                         press 6 :Create StockRecord
                         press 7 :  Delete Single StockRecord
                         press 8 :Delete StockList
                         press 9 : Update StockRecord
                         press 10:Get StockList
                         press 11:Get StockList for a range";
            Console.WriteLine(msg);
        }
        public void CompanyName()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Company Name";
            output.OutPut(msg);
        }
        public void CompanySymbol()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Company Symbol";
            output.OutPut(msg);
        }
        public void CompanyId()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Company Id";
            output.OutPut(msg);
        }
        public void GiveDate()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Give Date";
            output.OutPut(msg);
        }
        public void GiveMinPrice()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Give MinPrice";
            output.OutPut(msg);
        }
        public void GiveMaxPrice()
        {
            ConsoleOutput output = new ConsoleOutput();
            String msg = "Give MaxPrice";
            output.OutPut(msg);
        }

    }
}

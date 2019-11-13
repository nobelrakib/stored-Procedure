using System;

namespace StockApi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Messege output = new Messege();
            output.MessegeForEntireProgramme();
            CompanyCrudOperation cro = new CompanyCrudOperation(); ;
            StockCrudOperation sco = new StockCrudOperation();
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1) cro.Create();
            else if (num == 2) cro.DeleteCompany();
            else if (num == 3) cro.Update();
            else if (num == 4) cro.GetCompanyList();
            else if (num == 5) cro.GetSingleCompany();
            else if (num == 6) sco.Create();
            else if (num == 7) sco.Delete();
            else if (num == 8) sco.DeleteList();
            else if (num == 9) sco.Update();
            else if (num == 10) sco.GetStockList();
            else if (num == 11) sco.GetListByRange();
            
        }
    }
}

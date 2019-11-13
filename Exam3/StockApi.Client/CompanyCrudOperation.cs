using System;
using System.Collections.Generic;
using System.Text;
using StockMarketApi.Store3;
namespace StockApi.Client
{
    public class CompanyCrudOperation
    {
        public  void GetSingleCompany()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            GetObject data = new GetObject();
            output.CompanySymbol();
            String input1 = input.Input();
            data.GetData("Company3/"+input1);
        }
        public void GetCompanyList()
        {
           // ConsoleInputTaking input = new ConsoleInputTaking();
           // Messege output = new Messege();
            GetObject data = new GetObject();
           // output.CompanySymbol();
           // String input1 = input.Input();
            data.GetData("Company3");
        }
        public void Create()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            PostObject data = new PostObject();
            string[] inputarr = new string[2];
            output.CompanySymbol();
            inputarr[0] = input.Input();
            output.CompanyName();
            inputarr[1] = input.Input();
            data.Create(inputarr, "Company3");
        }
        public void Update()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            PutObject data = new PutObject();
            string[] inputarr = new string[2];
            output.CompanySymbol();
            inputarr[0] = input.Input();
            output.CompanyName();
            inputarr[1] = input.Input();
            data.Update(inputarr, "Company3");
        }
        public void DeleteCompany()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            DeleteObject data = new DeleteObject();
            output.CompanySymbol();
            String input1 = input.Input();
            data.GetData("Company3/" + input1);
        }

    }
}

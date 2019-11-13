using System;
using System.Collections.Generic;
using System.Text;

namespace StockApi.Client
{
    public class StockCrudOperation
    {
        public void GetStockList()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            GetObject data = new GetObject();
            output.CompanySymbol();
            String input1 = input.Input();
            data.GetData("Stock/" + input1);
        }
        public void GetListByRange()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            GetObject data = new GetObject();
            string[] inputarr = new string[3];
            output.CompanySymbol();
            inputarr[0] = input.Input();
            output.GiveDate();
            inputarr[1] = input.Input();
            output.GiveDate();
            inputarr[2] = input.Input();
            data.GetData( "Stock/"+inputarr[0]+"/"+inputarr[1]+"/"+inputarr[2]);
        }
        public void Create()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            PostObject data = new PostObject();
            string[] inputarr = new string[4];
            output.CompanyId();
            inputarr[0] = input.Input();
            output.GiveDate();
            inputarr[1] = input.Input();
            output.GiveMinPrice();
            inputarr[2] = input.Input();
            output.GiveMaxPrice();
            inputarr[3] = input.Input();
            data.Create(inputarr, "Stock");
        }
        public void Update()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            PutObject data = new PutObject();
            string[] inputarr = new string[2];
            output.CompanySymbol();
            inputarr[0] = input.Input();
            output.GiveMinPrice();
            inputarr[1] = input.Input();
            data.Update(inputarr, "Stock");
        }
        public void DeleteList()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            DeleteObject data = new DeleteObject();
            output.CompanySymbol();
            String input1 = input.Input();
            data.GetData("Stock/" + input1);
        }
        public void Delete()
        {
            ConsoleInputTaking input = new ConsoleInputTaking();
            Messege output = new Messege();
            DeleteObject data = new DeleteObject();
            output.CompanySymbol();
            String input1 = input.Input();
            output.GiveDate();
            String input2 = input.Input();
            data.GetData("Stock/" + input1+"/"+input2);
        }
    }
}

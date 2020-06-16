using System;
using System.ServiceModel;
using TcpBinding.Contracts;

namespace TcpBinding.Server
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class StockService : IStockService
    {
        public void PostStockDetails(Stock stock)
        {
            Console.ForegroundColor = (ConsoleColor)new Random().Next(10);
            Console.WriteLine($"Received <--------- {stock.City} \t {stock.TimeSent.ToString("F").Split(',')[0]} {stock.TimeSent:T} {stock.Name}  {stock.Price}");


        }
    }
}

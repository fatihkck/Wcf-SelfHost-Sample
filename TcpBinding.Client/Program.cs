using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            StockServiceStart();
            //ProductServiceStart()

            Console.ReadLine();

        }


        #region STOCK
        public static void StockServiceStart()
        {
            int i = 0;
            var location = new[] { "London", "New York", "Berlin", "Tokyo" };
            var processName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(processName).Count() <= 2)
            {
                Process.Start("TcpBinding.Client.exe");
            }

            i = Process.GetProcessesByName(processName).Count();

            Console.WriteLine(i);
            string loc = location[i];
            new Program().DisplayStockDetails(loc);
        }

        private void DisplayStockDetails(string loc)
        {
            Console.WriteLine("press any key continue...");
            Console.ReadLine();

            var uri = "net.tcp://localhost:4345/StockService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<IStockService>(binding);
            var endPoint = new EndpointAddress(uri);
            var proxy = channel.CreateChannel(endPoint);
            if (proxy != null)
            {
                Timer time = new Timer(obj =>
                {
                    var stock = GetStock(loc);
                    Console.ForegroundColor = (ConsoleColor)new Random().Next(10);
                    Console.WriteLine($"Sending -----> { loc}  {stock.TimeSent} {stock.Name} {stock.Price}");
                    proxy.PostStockDetails(stock);

                }, null, TimeSpan.FromSeconds(0.54), TimeSpan.FromSeconds(0.54));
            }

        }
        private Stock GetStock(string loc)
        {
            var rnd = new Random();

            var stock = new Stock
            {
                TimeSent = DateTime.UtcNow,
                Name = GetStockName(),
                Price = rnd.Next(13, 120) + rnd.NextDouble(),
                City = loc
            };

            return stock;
        }

        private string GetStockName()
        {
            char[] stp = "ASBJSBIUDSIFGUIHDFJLMNPR".ToCharArray();
            string name = string.Empty;
            Random rnd = new Random();
            for(int i=0; i < 4; i++){
                name += stp.GetValue(rnd.Next(stp.Length-1));
            }

            return name;
        }
        #endregion

        #region PRODUCT
        public static void ProductServiceStart()
        {

            Console.WriteLine("Press key");
            Console.ReadLine();

            var uri = "net.tcp://localhost:4345/ProductService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<IProductService>(binding);
            var endPoint = new EndpointAddress(uri);
            var proxy = channel.CreateChannel(endPoint);
            proxy?.GetStrings().ToList()
               .ForEach(p => Console.WriteLine(p));
            
        }
        #endregion
    }
}

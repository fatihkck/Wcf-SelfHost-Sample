using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Server
{

    class Program
    {
        static void Main(string[] args)
        {
            //ServerStart();
            StockServerStart();
            Console.ReadLine();
        }


        public static void ProductServerStart()
        {
            var uris = new Uri[1];

            string addr = "net.tcp://localhost:4345/ProductService";
            
            uris[0] = new Uri(addr);
            IProductService productService = new ProductService();
            ServiceHost host = new ServiceHost(productService, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IProductService), binding, "");
            host.Opened += HostOnOpened;
            try
            {
                host.Open();

            }
            catch (Exception ex)
            {

                Console.WriteLine("error opening service host");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }


        public static void StockServerStart()
        {
            var uris = new Uri[1];

            string addr = "net.tcp://localhost:4345/StockService";

            uris[0] = new Uri(addr);
            IStockService stockService = new StockService();
            ServiceHost host = new ServiceHost(stockService, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IStockService), binding, "");
            host.Opened += HostOnOpened;
            try
            {
                host.Open();

            }
            catch (Exception ex)
            {

                Console.WriteLine("error opening service host");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void HostOnOpened(object sender, EventArgs e)
        {
            Console.WriteLine("Wcf service is started");
        }
    }
}

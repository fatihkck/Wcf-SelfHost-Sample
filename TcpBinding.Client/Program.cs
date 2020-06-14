using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Client
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadLine();

        }
    }
}

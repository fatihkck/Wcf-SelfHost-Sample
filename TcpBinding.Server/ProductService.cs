using System.ServiceModel;
using TcpBinding.Contracts;

namespace TcpBinding.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ProductService : IProductService
    {
        public string[] GetStrings()
        {
            return new[] { "Server1", "Server2", "Server3" };
        }
    }
}

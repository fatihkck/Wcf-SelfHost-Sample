using System.ServiceModel;

namespace TcpBinding.Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        string[] GetStrings();
    }
}

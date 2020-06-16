using System.ServiceModel;

namespace TcpBinding.Contracts
{

    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        void PostStockDetails(Stock stock);
    }
}

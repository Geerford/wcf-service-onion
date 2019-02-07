using Service.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract()]
    public interface IWcfService
    {
        [OperationContract]
        IEnumerable<ClientDTO> GetClients();

        [OperationContract]
        CartDTO GetByClient(int clientID);

        [OperationContract]
        IEnumerable<GoodsDTO> GetGoods();

        [OperationContract]
        IEnumerable<OrderItem> GetOrdersGroup();

        [OperationContract]
        ResponseHitsModel TotalHits();
    }
}
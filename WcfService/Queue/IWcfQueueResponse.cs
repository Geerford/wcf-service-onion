using Service.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService.Queue
{
    [ServiceContract]
    public interface IWcfQueueResponse
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveCustomers(IEnumerable<CustomerDTO> customers);
        
        [OperationContract(IsOneWay = true)]
        void ReceiveGoods(IEnumerable<GoodsDTO> goods);
    }
}
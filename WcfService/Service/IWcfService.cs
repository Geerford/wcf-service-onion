using Service.DTO;
using System.Collections.Generic;
using System.ServiceModel;
using WcfService.Callback;

namespace WcfService.Service
{
    [ServiceContract(CallbackContract = typeof(IRequestCounter))]
    public interface IWcfService
    {
        [OperationContract]
        IEnumerable<CustomerDTO> GetCustomers();

        [OperationContract]
        IEnumerable<GoodsDTO> GetGoods();
    }
}
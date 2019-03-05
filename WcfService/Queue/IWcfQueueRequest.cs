using System.ServiceModel;

namespace WcfService.Queue
{
    [ServiceContract]
    public interface IWcfQueueRequest
    {
        [OperationContract(IsOneWay = true)]
        void SendCustomersRequest();

        [OperationContract(IsOneWay = true)]
        void SendGoodsRequest();
    }
}
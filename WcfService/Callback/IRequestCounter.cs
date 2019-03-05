using Service.DTO;
using System.ServiceModel;

namespace WcfService.Callback
{
    public interface IRequestCounter
    {
        [OperationContract(IsOneWay = true)]
        void ShowRequestCount(RequestModel count);
    }
}
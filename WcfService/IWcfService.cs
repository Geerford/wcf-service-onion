using Service.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        IEnumerable<ClientDTO> GetClients();

        [OperationContract]
        IEnumerable<ClientDTO> GetOrders(int clientID);
    }
}
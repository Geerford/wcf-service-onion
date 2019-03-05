using System;
using System.Configuration;
using System.ServiceModel;
using System.Transactions;

namespace WcfService.Queue
{
    public class WcfQueueRequest : ServiceBase, IWcfQueueRequest
    {
        private readonly string clientName;

        public WcfQueueRequest()
        {
            clientName = ConfigurationManager.AppSettings["queueClientName"];
        }

        public void SendCustomersRequest()
        {
            SendQuoteRequest(x => x.ReceiveCustomers(GetClientsInternal()));
        }

        public void SendGoodsRequest()
        {
            SendQuoteRequest(x => x.ReceiveGoods(GetGoodsInternal()));
        }

        private void SendQuoteRequest(Action<IWcfQueueResponse> sendAction)
        {
            using (var cf = new ChannelFactory<IWcfQueueResponse>(clientName))
            {
                var channel = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    sendAction(channel);
                    scope.Complete();
                }
                cf.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WCF.WindowsForms.Callback;
using WCF.WindowsForms.QueueReference;
using WCF.WindowsForms.Handler;
using WCF.WindowsForms.ServiceReference;
using Service.DTO;
using System.ServiceModel;

namespace WCF.WindowsForms.Services
{
    public class ClientService : IDisposable
    {
        private readonly Lazy<WcfServiceClient> client;
        private readonly Lazy<WcfQueueRequestClient> queue;
        private readonly List<CustomerDTO> customersFromQueue;
        private readonly List<GoodsDTO> goodsFromQueue;
        private readonly Action<RequestModel> updateCountCallback;
        private readonly Action<IEnumerable<CustomerDTO>, IEnumerable<GoodsDTO>> queueResponseCallback;
        private ServiceHost host;

        public ClientService(Action<RequestModel> updateCountCallback, Action<IEnumerable<CustomerDTO>, IEnumerable<GoodsDTO>> queueResponseCallback)
        {
            client = new Lazy<WcfServiceClient>(CreateClient);
            queue = new Lazy<WcfQueueRequestClient>(() => new WcfQueueRequestClient());
            customersFromQueue = new List<CustomerDTO>();
            goodsFromQueue = new List<GoodsDTO>();
            this.updateCountCallback = updateCountCallback;
            this.queueResponseCallback = queueResponseCallback;
        }
        
        public void Initalize()
        {
            var handler = new QueueResponseHandler(AddCustomers);
            host = new ServiceHost(handler);
            host.Open();
        }

        private void AddCustomers(IEnumerable<CustomerDTO> customers)
        {
            customersFromQueue.AddRange(customers);
            queueResponseCallback?.Invoke(customersFromQueue, goodsFromQueue);
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            return await client.Value.GetCustomersAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<GoodsDTO>> GetGoodsAsync()
        {
            return await client.Value.GetGoodsAsync().ConfigureAwait(false);
        }

        public async Task SendRequestAsync()
        {
            customersFromQueue.Clear();
            goodsFromQueue.Clear();
            await queue.Value.SendCustomersRequestAsync();
        }

        private WcfServiceClient CreateClient()
        {
            var context = new InstanceContext(new RequestCounter(updateCountCallback));
            return new WcfServiceClient(context);
        }

        public void Dispose()
        {
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
            }
        }
    }
}
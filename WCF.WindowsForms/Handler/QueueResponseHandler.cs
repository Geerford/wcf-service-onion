using System;
using System.Collections.Generic;
using System.ServiceModel;
using Service.DTO;

namespace WCF.WindowsForms.Handler
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class QueueResponseHandler : IWcfQueueResponse
    {
        private readonly Action<IEnumerable<CustomerDTO>> customersCallback;
        private readonly Action<IEnumerable<GoodsDTO>> goodsCallback;

        public QueueResponseHandler(Action<IEnumerable<CustomerDTO>> customersCallback, Action<IEnumerable<GoodsDTO>> goodsCallback)
        {
            this.customersCallback = customersCallback;
            this.goodsCallback = goodsCallback;
        }

        public void ReceiveCustomers(IEnumerable<CustomerDTO> customers)
        {
            customersCallback?.Invoke(customers);
        }

        public void ReceiveGoods(IEnumerable<GoodsDTO> goods)
        {
            goodsCallback?.Invoke(goods);
        }
    }
}
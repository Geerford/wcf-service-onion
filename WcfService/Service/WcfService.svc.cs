using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Service.DTO;
using WcfService.Callback;

namespace WcfService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WcfService : ServiceBase, IWcfService
    {
        private static RequestModel Counter = new RequestModel();

        public IEnumerable<CustomerDTO> GetCustomers() => WrapCounter(func: () => GetClientsInternal());

        public IEnumerable<GoodsDTO> GetGoods()
        {
            Thread.Sleep(5000);
            return WrapCounter(() => GetGoodsInternal());
        }

        private T WrapCounter<T>(Func<T> func)
        {
            switch (typeof(T).GetGenericArguments().FirstOrDefault().Name)
            {
                case "CustomerDTO":
                    Interlocked.Increment(ref Counter.GetCustumerRequest);
                    break;
                case "GoodsDTO":
                    Interlocked.Increment(ref Counter.GetGoodsRequest);
                    break;
                default:
                    break;
            }
            Interlocked.Increment(ref Counter.TotalRequest);
            var callback = OperationContext.Current.GetCallbackChannel<IRequestCounter>();
            Task.Run(() => callback.ShowRequestCount(Counter));
            Thread.Sleep(500);
            try
            {
                return func();
            }
            finally
            {
                switch (typeof(T).GetGenericArguments().FirstOrDefault().Name)
                {
                    case "CustomerDTO":
                        Interlocked.Decrement(ref Counter.GetCustumerRequest);
                        break;
                    case "GoodsDTO":
                        Interlocked.Decrement(ref Counter.GetGoodsRequest);
                        break;
                    default:
                        break;
                }
                Interlocked.Decrement(ref Counter.TotalRequest);
                Task.Run(() => callback.ShowRequestCount(Counter));
            }
        }
    }
}
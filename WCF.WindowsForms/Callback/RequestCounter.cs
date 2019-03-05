using Service.DTO;
using System;
using WCF.WindowsForms.ServiceReference;

namespace WCF.WindowsForms.Callback
{
    public class RequestCounter : IWcfServiceCallback
    {
        private readonly Action<RequestModel> updateAction;
        
        public RequestCounter(Action<RequestModel> updateAction)
        {
            this.updateAction = updateAction;
        }

        public void ShowRequestCount(RequestModel count)
        {
            updateAction?.Invoke(count);
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.WindowsForms.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IWcfService")]
    public interface IWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetClients", ReplyAction="http://tempuri.org/IWcfService/GetClientsResponse")]
        Service.DTO.ClientDTO[] GetClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetClients", ReplyAction="http://tempuri.org/IWcfService/GetClientsResponse")]
        System.Threading.Tasks.Task<Service.DTO.ClientDTO[]> GetClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetByClient", ReplyAction="http://tempuri.org/IWcfService/GetByClientResponse")]
        Service.DTO.CartDTO GetByClient(int clientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetByClient", ReplyAction="http://tempuri.org/IWcfService/GetByClientResponse")]
        System.Threading.Tasks.Task<Service.DTO.CartDTO> GetByClientAsync(int clientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetGoods", ReplyAction="http://tempuri.org/IWcfService/GetGoodsResponse")]
        Service.DTO.GoodsDTO[] GetGoods();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetGoods", ReplyAction="http://tempuri.org/IWcfService/GetGoodsResponse")]
        System.Threading.Tasks.Task<Service.DTO.GoodsDTO[]> GetGoodsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetOrdersGroup", ReplyAction="http://tempuri.org/IWcfService/GetOrdersGroupResponse")]
        Service.DTO.OrderItem[] GetOrdersGroup();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/GetOrdersGroup", ReplyAction="http://tempuri.org/IWcfService/GetOrdersGroupResponse")]
        System.Threading.Tasks.Task<Service.DTO.OrderItem[]> GetOrdersGroupAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/TotalHits", ReplyAction="http://tempuri.org/IWcfService/TotalHitsResponse")]
        Service.DTO.ResponseHitsModel TotalHits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/TotalHits", ReplyAction="http://tempuri.org/IWcfService/TotalHitsResponse")]
        System.Threading.Tasks.Task<Service.DTO.ResponseHitsModel> TotalHitsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfServiceChannel : WCF.WindowsForms.ServiceReference.IWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfServiceClient : System.ServiceModel.ClientBase<WCF.WindowsForms.ServiceReference.IWcfService>, WCF.WindowsForms.ServiceReference.IWcfService {
        
        public WcfServiceClient() {
        }
        
        public WcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Service.DTO.ClientDTO[] GetClients() {
            return base.Channel.GetClients();
        }
        
        public System.Threading.Tasks.Task<Service.DTO.ClientDTO[]> GetClientsAsync() {
            return base.Channel.GetClientsAsync();
        }
        
        public Service.DTO.CartDTO GetByClient(int clientID) {
            return base.Channel.GetByClient(clientID);
        }
        
        public System.Threading.Tasks.Task<Service.DTO.CartDTO> GetByClientAsync(int clientID) {
            return base.Channel.GetByClientAsync(clientID);
        }
        
        public Service.DTO.GoodsDTO[] GetGoods() {
            return base.Channel.GetGoods();
        }
        
        public System.Threading.Tasks.Task<Service.DTO.GoodsDTO[]> GetGoodsAsync() {
            return base.Channel.GetGoodsAsync();
        }
        
        public Service.DTO.OrderItem[] GetOrdersGroup() {
            return base.Channel.GetOrdersGroup();
        }
        
        public System.Threading.Tasks.Task<Service.DTO.OrderItem[]> GetOrdersGroupAsync() {
            return base.Channel.GetOrdersGroupAsync();
        }
        
        public Service.DTO.ResponseHitsModel TotalHits() {
            return base.Channel.TotalHits();
        }
        
        public System.Threading.Tasks.Task<Service.DTO.ResponseHitsModel> TotalHitsAsync() {
            return base.Channel.TotalHitsAsync();
        }
    }
}

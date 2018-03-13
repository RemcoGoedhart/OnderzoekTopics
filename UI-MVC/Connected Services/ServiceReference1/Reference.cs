﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SC.UI.Web.MVC.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NewTicketResponseDTO", Namespace="http://schemas.datacontract.org/2004/07/SC.UI.Web.MVC.Models")]
    [System.SerializableAttribute()]
    public partial class NewTicketResponseDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsClientResponseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResponseTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TicketNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsClientResponse {
            get {
                return this.IsClientResponseField;
            }
            set {
                if ((this.IsClientResponseField.Equals(value) != true)) {
                    this.IsClientResponseField = value;
                    this.RaisePropertyChanged("IsClientResponse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResponseText {
            get {
                return this.ResponseTextField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseTextField, value) != true)) {
                    this.ResponseTextField = value;
                    this.RaisePropertyChanged("ResponseText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TicketNumber {
            get {
                return this.TicketNumberField;
            }
            set {
                if ((this.TicketNumberField.Equals(value) != true)) {
                    this.TicketNumberField = value;
                    this.RaisePropertyChanged("TicketNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTicketResponse", ReplyAction="http://tempuri.org/IService1/GetTicketResponseResponse")]
        SC.BL.Domain.TicketResponse[] GetTicketResponse(int ticketNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTicketResponse", ReplyAction="http://tempuri.org/IService1/GetTicketResponseResponse")]
        System.Threading.Tasks.Task<SC.BL.Domain.TicketResponse[]> GetTicketResponseAsync(int ticketNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddResponse", ReplyAction="http://tempuri.org/IService1/AddResponseResponse")]
        SC.BL.Domain.TicketResponse AddResponse(SC.UI.Web.MVC.ServiceReference1.NewTicketResponseDTO response);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddResponse", ReplyAction="http://tempuri.org/IService1/AddResponseResponse")]
        System.Threading.Tasks.Task<SC.BL.Domain.TicketResponse> AddResponseAsync(SC.UI.Web.MVC.ServiceReference1.NewTicketResponseDTO response);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CloseTicket", ReplyAction="http://tempuri.org/IService1/CloseTicketResponse")]
        void CloseTicket(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CloseTicket", ReplyAction="http://tempuri.org/IService1/CloseTicketResponse")]
        System.Threading.Tasks.Task CloseTicketAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : SC.UI.Web.MVC.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<SC.UI.Web.MVC.ServiceReference1.IService1>, SC.UI.Web.MVC.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SC.BL.Domain.TicketResponse[] GetTicketResponse(int ticketNumber) {
            return base.Channel.GetTicketResponse(ticketNumber);
        }
        
        public System.Threading.Tasks.Task<SC.BL.Domain.TicketResponse[]> GetTicketResponseAsync(int ticketNumber) {
            return base.Channel.GetTicketResponseAsync(ticketNumber);
        }
        
        public SC.BL.Domain.TicketResponse AddResponse(SC.UI.Web.MVC.ServiceReference1.NewTicketResponseDTO response) {
            return base.Channel.AddResponse(response);
        }
        
        public System.Threading.Tasks.Task<SC.BL.Domain.TicketResponse> AddResponseAsync(SC.UI.Web.MVC.ServiceReference1.NewTicketResponseDTO response) {
            return base.Channel.AddResponseAsync(response);
        }
        
        public void CloseTicket(int id) {
            base.Channel.CloseTicket(id);
        }
        
        public System.Threading.Tasks.Task CloseTicketAsync(int id) {
            return base.Channel.CloseTicketAsync(id);
        }
    }
}

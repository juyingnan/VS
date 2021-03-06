﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShopLiteDemoClient.OnlineShopLiteService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="ss.pku.edu.cn", ConfigurationName="OnlineShopLiteService.OnlineShopPortType")]
    public interface OnlineShopPortType {
        
        // CODEGEN: Generating message contract since the operation process is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="ss.pku.edu.cn/process", ReplyAction="ss.pku.edu.cn/OnlineShop/processResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse process(OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="ss.pku.edu.cn/process", ReplyAction="ss.pku.edu.cn/OnlineShop/processResponse")]
        System.Threading.Tasks.Task<OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse> processAsync(OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="ss.pku.edu.cn")]
    public partial class OnlineShopRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string creditCardNoField;
        
        private string customerIDField;
        
        private string toasterTypeField;
        
        private int quantityField;
        
        private bool isCanceledField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CreditCardNo {
            get {
                return this.creditCardNoField;
            }
            set {
                this.creditCardNoField = value;
                this.RaisePropertyChanged("CreditCardNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CustomerID {
            get {
                return this.customerIDField;
            }
            set {
                this.customerIDField = value;
                this.RaisePropertyChanged("CustomerID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ToasterType {
            get {
                return this.toasterTypeField;
            }
            set {
                this.toasterTypeField = value;
                this.RaisePropertyChanged("ToasterType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
                this.RaisePropertyChanged("Quantity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public bool IsCanceled {
            get {
                return this.isCanceledField;
            }
            set {
                this.isCanceledField = value;
                this.RaisePropertyChanged("IsCanceled");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="ss.pku.edu.cn")]
    public partial class OnlineShopResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string purchaseResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PurchaseResult {
            get {
                return this.purchaseResultField;
            }
            set {
                this.purchaseResultField = value;
                this.RaisePropertyChanged("PurchaseResult");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class processRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="ss.pku.edu.cn", Order=0)]
        public OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopRequest OnlineShopRequest;
        
        public processRequest() {
        }
        
        public processRequest(OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopRequest OnlineShopRequest) {
            this.OnlineShopRequest = OnlineShopRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class processResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="ss.pku.edu.cn", Order=0)]
        public OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopResponse OnlineShopResponse;
        
        public processResponse() {
        }
        
        public processResponse(OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopResponse OnlineShopResponse) {
            this.OnlineShopResponse = OnlineShopResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OnlineShopPortTypeChannel : OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OnlineShopPortTypeClient : System.ServiceModel.ClientBase<OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType>, OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType {
        
        public OnlineShopPortTypeClient() {
        }
        
        public OnlineShopPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OnlineShopPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OnlineShopPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OnlineShopPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType.process(OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest request) {
            return base.Channel.process(request);
        }
        
        public OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopResponse process(OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopRequest OnlineShopRequest) {
            OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest inValue = new OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest();
            inValue.OnlineShopRequest = OnlineShopRequest;
            OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse retVal = ((OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType)(this)).process(inValue);
            return retVal.OnlineShopResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse> OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType.processAsync(OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest request) {
            return base.Channel.processAsync(request);
        }
        
        public System.Threading.Tasks.Task<OnlineShopLiteDemoClient.OnlineShopLiteService.processResponse> processAsync(OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopRequest OnlineShopRequest) {
            OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest inValue = new OnlineShopLiteDemoClient.OnlineShopLiteService.processRequest();
            inValue.OnlineShopRequest = OnlineShopRequest;
            return ((OnlineShopLiteDemoClient.OnlineShopLiteService.OnlineShopPortType)(this)).processAsync(inValue);
        }
    }
}

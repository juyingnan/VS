﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BPEL_Client.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://correlation.bpel.tps", ConfigurationName="ServiceReference2.No_CorrelationPortType")]
    public interface No_CorrelationPortType {
        
        // CODEGEN: Generating message contract since the operation process is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://correlation.bpel.tps/process", ReplyAction="http://correlation.bpel.tps/No_Correlation/processResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        BPEL_Client.ServiceReference2.processResponse process(BPEL_Client.ServiceReference2.processRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://correlation.bpel.tps")]
    public partial class No_CorrelationRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int inputField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int input {
            get {
                return this.inputField;
            }
            set {
                this.inputField = value;
                this.RaisePropertyChanged("input");
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://correlation.bpel.tps")]
    public partial class No_CorrelationResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int resultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("result");
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
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://correlation.bpel.tps", Order=0)]
        public BPEL_Client.ServiceReference2.No_CorrelationRequest No_CorrelationRequest;
        
        public processRequest() {
        }
        
        public processRequest(BPEL_Client.ServiceReference2.No_CorrelationRequest No_CorrelationRequest) {
            this.No_CorrelationRequest = No_CorrelationRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class processResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://correlation.bpel.tps", Order=0)]
        public BPEL_Client.ServiceReference2.No_CorrelationResponse No_CorrelationResponse;
        
        public processResponse() {
        }
        
        public processResponse(BPEL_Client.ServiceReference2.No_CorrelationResponse No_CorrelationResponse) {
            this.No_CorrelationResponse = No_CorrelationResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface No_CorrelationPortTypeChannel : BPEL_Client.ServiceReference2.No_CorrelationPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class No_CorrelationPortTypeClient : System.ServiceModel.ClientBase<BPEL_Client.ServiceReference2.No_CorrelationPortType>, BPEL_Client.ServiceReference2.No_CorrelationPortType {
        
        public No_CorrelationPortTypeClient() {
        }
        
        public No_CorrelationPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public No_CorrelationPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public No_CorrelationPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public No_CorrelationPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BPEL_Client.ServiceReference2.processResponse BPEL_Client.ServiceReference2.No_CorrelationPortType.process(BPEL_Client.ServiceReference2.processRequest request) {
            return base.Channel.process(request);
        }
        
        public BPEL_Client.ServiceReference2.No_CorrelationResponse process(BPEL_Client.ServiceReference2.No_CorrelationRequest No_CorrelationRequest) {
            BPEL_Client.ServiceReference2.processRequest inValue = new BPEL_Client.ServiceReference2.processRequest();
            inValue.No_CorrelationRequest = No_CorrelationRequest;
            BPEL_Client.ServiceReference2.processResponse retVal = ((BPEL_Client.ServiceReference2.No_CorrelationPortType)(this)).process(inValue);
            return retVal.No_CorrelationResponse;
        }
    }
}
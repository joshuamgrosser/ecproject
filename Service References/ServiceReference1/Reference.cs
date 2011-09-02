﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnergyCAP.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Building", Namespace="http://schemas.datacontract.org/2004/07/EnergyCAPService")]
    [System.SerializableAttribute()]
    public partial class Building : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BuildingIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingMemoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingNameField;
        
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
        public string BuildingCode {
            get {
                return this.BuildingCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingCodeField, value) != true)) {
                    this.BuildingCodeField = value;
                    this.RaisePropertyChanged("BuildingCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BuildingID {
            get {
                return this.BuildingIDField;
            }
            set {
                if ((this.BuildingIDField.Equals(value) != true)) {
                    this.BuildingIDField = value;
                    this.RaisePropertyChanged("BuildingID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuildingMemo {
            get {
                return this.BuildingMemoField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingMemoField, value) != true)) {
                    this.BuildingMemoField = value;
                    this.RaisePropertyChanged("BuildingMemo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuildingName {
            get {
                return this.BuildingNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingNameField, value) != true)) {
                    this.BuildingNameField = value;
                    this.RaisePropertyChanged("BuildingName");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBuildings", ReplyAction="http://tempuri.org/IService1/GetBuildingsResponse")]
        EnergyCAP.ServiceReference1.Building GetBuildings();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : EnergyCAP.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<EnergyCAP.ServiceReference1.IService1>, EnergyCAP.ServiceReference1.IService1 {
        
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
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public EnergyCAP.ServiceReference1.Building GetBuildings() {
            return base.Channel.GetBuildings();
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SweepLoadMine.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Sweep", ConfigurationName="ServiceReference1.IService1", CallbackContract=typeof(SweepLoadMine.ServiceReference1.IService1Callback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Login")]
        void Login(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Login")]
        System.Threading.Tasks.Task LoginAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Start")]
        void Start(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Start")]
        System.Threading.Tasks.Task StartAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Win")]
        void Win(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Win")]
        System.Threading.Tasks.Task WinAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Fail")]
        void Fail(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Fail")]
        System.Threading.Tasks.Task FailAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Logout")]
        void Logout(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/Logout")]
        System.Threading.Tasks.Task LogoutAsync(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Callback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/ShowLogin")]
        void ShowLogin(string loginUserName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/ShowStart")]
        void ShowStart(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/ShowWin")]
        void ShowWin(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/ShowFail")]
        void ShowFail(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="Sweep/IService1/ShowLogout")]
        void ShowLogout(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : SweepLoadMine.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.DuplexClientBase<SweepLoadMine.ServiceReference1.IService1>, SweepLoadMine.ServiceReference1.IService1 {
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Login(string userName) {
            base.Channel.Login(userName);
        }
        
        public System.Threading.Tasks.Task LoginAsync(string userName) {
            return base.Channel.LoginAsync(userName);
        }
        
        public void Start(string userName) {
            base.Channel.Start(userName);
        }
        
        public System.Threading.Tasks.Task StartAsync(string userName) {
            return base.Channel.StartAsync(userName);
        }
        
        public void Win(string userName) {
            base.Channel.Win(userName);
        }
        
        public System.Threading.Tasks.Task WinAsync(string userName) {
            return base.Channel.WinAsync(userName);
        }
        
        public void Fail(string userName) {
            base.Channel.Fail(userName);
        }
        
        public System.Threading.Tasks.Task FailAsync(string userName) {
            return base.Channel.FailAsync(userName);
        }
        
        public void Logout(string userName) {
            base.Channel.Logout(userName);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string userName) {
            return base.Channel.LogoutAsync(userName);
        }
    }
}

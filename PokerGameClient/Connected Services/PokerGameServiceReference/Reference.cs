﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokerGameClient.PokerGameServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PokerGameServiceReference.IPokerService", CallbackContract=typeof(PokerGameClient.PokerGameServiceReference.IPokerServiceCallback))]
    public interface IPokerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/GetRooms", ReplyAction="http://tempuri.org/IPokerService/GetRoomsResponse")]
        PokerLibrary.Room[] GetRooms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/GetRooms", ReplyAction="http://tempuri.org/IPokerService/GetRoomsResponse")]
        System.Threading.Tasks.Task<PokerLibrary.Room[]> GetRoomsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/RegisterToRoom", ReplyAction="http://tempuri.org/IPokerService/RegisterToRoomResponse")]
        PokerLibrary.Room RegisterToRoom(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/RegisterToRoom", ReplyAction="http://tempuri.org/IPokerService/RegisterToRoomResponse")]
        System.Threading.Tasks.Task<PokerLibrary.Room> RegisterToRoomAsync(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/RegisterPlayer", ReplyAction="http://tempuri.org/IPokerService/RegisterPlayerResponse")]
        PokerLibrary.Player RegisterPlayer(string playerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/RegisterPlayer", ReplyAction="http://tempuri.org/IPokerService/RegisterPlayerResponse")]
        System.Threading.Tasks.Task<PokerLibrary.Player> RegisterPlayerAsync(string playerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/ExitFromRoom", ReplyAction="http://tempuri.org/IPokerService/ExitFromRoomResponse")]
        bool ExitFromRoom(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/ExitFromRoom", ReplyAction="http://tempuri.org/IPokerService/ExitFromRoomResponse")]
        System.Threading.Tasks.Task<bool> ExitFromRoomAsync(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/SendReady", ReplyAction="http://tempuri.org/IPokerService/SendReadyResponse")]
        void SendReady(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/SendReady", ReplyAction="http://tempuri.org/IPokerService/SendReadyResponse")]
        System.Threading.Tasks.Task SendReadyAsync(string playerName, string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/TestConnection", ReplyAction="http://tempuri.org/IPokerService/TestConnectionResponse")]
        bool TestConnection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/TestConnection", ReplyAction="http://tempuri.org/IPokerService/TestConnectionResponse")]
        System.Threading.Tasks.Task<bool> TestConnectionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/GetRoom", ReplyAction="http://tempuri.org/IPokerService/GetRoomResponse")]
        PokerLibrary.Room GetRoom(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPokerService/GetRoom", ReplyAction="http://tempuri.org/IPokerService/GetRoomResponse")]
        System.Threading.Tasks.Task<PokerLibrary.Room> GetRoomAsync(string roomId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPokerServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPokerService/StartTheGame")]
        void StartTheGame(string roomId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPokerService/RefreshRoomList")]
        void RefreshRoomList(string roomId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPokerServiceChannel : PokerGameClient.PokerGameServiceReference.IPokerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PokerServiceClient : System.ServiceModel.DuplexClientBase<PokerGameClient.PokerGameServiceReference.IPokerService>, PokerGameClient.PokerGameServiceReference.IPokerService {
        
        public PokerServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PokerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PokerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PokerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PokerServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public PokerLibrary.Room[] GetRooms() {
            return base.Channel.GetRooms();
        }
        
        public System.Threading.Tasks.Task<PokerLibrary.Room[]> GetRoomsAsync() {
            return base.Channel.GetRoomsAsync();
        }
        
        public PokerLibrary.Room RegisterToRoom(string playerName, string roomId) {
            return base.Channel.RegisterToRoom(playerName, roomId);
        }
        
        public System.Threading.Tasks.Task<PokerLibrary.Room> RegisterToRoomAsync(string playerName, string roomId) {
            return base.Channel.RegisterToRoomAsync(playerName, roomId);
        }
        
        public PokerLibrary.Player RegisterPlayer(string playerName) {
            return base.Channel.RegisterPlayer(playerName);
        }
        
        public System.Threading.Tasks.Task<PokerLibrary.Player> RegisterPlayerAsync(string playerName) {
            return base.Channel.RegisterPlayerAsync(playerName);
        }
        
        public bool ExitFromRoom(string playerName, string roomId) {
            return base.Channel.ExitFromRoom(playerName, roomId);
        }
        
        public System.Threading.Tasks.Task<bool> ExitFromRoomAsync(string playerName, string roomId) {
            return base.Channel.ExitFromRoomAsync(playerName, roomId);
        }
        
        public void SendReady(string playerName, string roomId) {
            base.Channel.SendReady(playerName, roomId);
        }
        
        public System.Threading.Tasks.Task SendReadyAsync(string playerName, string roomId) {
            return base.Channel.SendReadyAsync(playerName, roomId);
        }
        
        public bool TestConnection() {
            return base.Channel.TestConnection();
        }
        
        public System.Threading.Tasks.Task<bool> TestConnectionAsync() {
            return base.Channel.TestConnectionAsync();
        }
        
        public PokerLibrary.Room GetRoom(string roomId) {
            return base.Channel.GetRoom(roomId);
        }
        
        public System.Threading.Tasks.Task<PokerLibrary.Room> GetRoomAsync(string roomId) {
            return base.Channel.GetRoomAsync(roomId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(Namespace = "Sweep",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IService1Callback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName);

        [OperationContract(IsOneWay = true)]
        void Start(string userName);

        [OperationContract(IsOneWay = true)]
        void Win(string userName);

        [OperationContract(IsOneWay = true)]
        void Fail(string userName);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        // TODO: 在此添加您的服务操作
    }

    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string loginUserName);

        [OperationContract(IsOneWay = true)]
        void ShowStart(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowWin(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowFail(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowLogout(string userName);
    }
}

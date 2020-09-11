using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。

    public class Service1 : IService1
    {
        public Service1()
        {
            if (CC.Users == null)
            {
                CC.Users = new List<User>();
            }
        }


        public void Login(string userName)
        {
            OperationContext context = OperationContext.Current;
            IService1Callback callback = context.GetCallbackChannel<IService1Callback>();
            User newUser = new User(userName, callback);
            CC.Users.Add(newUser);
            foreach (var v in CC.Users)
            {
                v.callback.ShowLogin(userName);
            }
        }

        public void Start(string userName)
        {
            User user = CC.GetUser(userName);
            user.IsStarted = true;
            foreach (var v in CC.Users)
            {
                v.callback.ShowStart(userName);
            }
        }

        public void Win(string userName)
        {
            User user = CC.GetUser(userName);
            foreach (var v in CC.Users)
            {
                v.callback.ShowWin(userName);
            }
        }

        public void Fail(string userName)
        {
            User user = CC.GetUser(userName);
            foreach (var v in CC.Users)
            {
                v.callback.ShowFail(userName);
            }
        }

        public void Logout(string userName)
        {
            User logoutUser = CC.GetUser(userName);
            CC.Users.Remove(logoutUser);
            logoutUser = null;
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogout(userName);
            }
        }
    }
}

using QFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Model;

namespace Script.ChomnFramework
{
    public class SteamEx : Architecture<SteamEx>
    {
        protected override void Init()
        {
            //这儿是该项目的逻辑，搬项目的时候不用搬或者酌情搬
            this.RegisterModel<ISteamUserInfo>(new SteamUserInfoModel());
            this.RegisterModel<ISDKModel>(new SDKModel());
            
            //以下是框架通用，换Architecture的话一起复制过去
            this.RegisterUtility<IJsonHelper>(new JsonEx());
            this.RegisterUtility<IHttpHelper>(HttpRestful.Instance);
        }
    }
}

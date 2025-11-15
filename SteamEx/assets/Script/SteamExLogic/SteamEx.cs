using QFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Model;
using UnityEngine;
using UnityEngine.Device;

namespace Script.SteamExLogic
{
    public class SteamEx : Architecture<SteamEx>
    {
        protected override void Init()
        {
            //这儿是该项目的逻辑，搬项目的时候不用搬或者酌情搬
            this.RegisterModel<ISteamUserInfo>(new SteamUserInfoModel());
            this.RegisterModel<ISDKModel>(new SDKModel());
            
            //以下是框架通用，换Architecture的话一起复制过去
            //Application.targetFrameRate = 120;
            QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 120;
            this.RegisterUtility<IJsonHelper>(new JsonEx());
            this.RegisterUtility<IHttpHelper>(new HttpHelpEx());
            this.RegisterUtility<ILocalStorage>(new LocalStorageEx());
            this.RegisterUtility<IAsyncTaskQueueWaitEX>(new AsyncTaskQueueWaitEX());
            this.RegisterUtility<IAsyncTaskQueueNoWaitEx>(new AsyncTaskQueueNoWaitEx());
        }
    }
}

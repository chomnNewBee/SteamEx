using System.Collections;
using System.Collections.Generic;
using QFramework;
using Script.ChomnFramework.Utility;
using UnityEngine;

public class SteamEx : Architecture<SteamEx>
{
    protected override void Init()
    {
        
        
        
        //以下是框架通用，换Architecture的话一起复制过去
        this.RegisterUtility<IJsonHelper>(new JsonEx());
        this.RegisterUtility<IHttpHelper>(HttpRestful.Instance);
    }
}

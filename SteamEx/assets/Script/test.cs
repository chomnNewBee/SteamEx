using System.Collections;
using System.Collections.Generic;
using QFramework;
using Script.ChomnFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Command;
using Script.SteamExLogic.Model;
using TMPro;
using UnityEngine;

public class a
{
    public int b = 1;
}
public class test : MonoBehaviourEx<test>
{
    public TMP_Text ui_txt;
    public override void StartEx()
    {
        base.StartEx();
       
        this.SendCommand(new GetUserInfoCmd("76561199469130560"));
        this.RegisterEvent<OnUserInfoUpdate>((update =>
        {
            ui_txt.text = this.GetModel<ISteamUserInfo>().userInfo.response.players[0].realname;
        })).UnRegisterWhenGameObjectDestroyed(gameObject);


    }

  
}

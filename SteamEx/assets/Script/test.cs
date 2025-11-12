using System.Collections;
using System.Collections.Generic;
using QFramework;
using Script.ChomnFramework;
using Script.ChomnFramework.Utility;
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
        a a = new a();
        a.b = 2;
        string json = this.GetUtility<IJsonHelper>().ToJson(a);
        Debug.Log(json);
        
        this.GetUtility<IHttpHelper>().Get("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=28582A112299D03C6C51E463A1F15081&steamids=76561199546918606",(
            (s) =>
            {
                ui_txt.text = s;
                    
                Debug.Log(s);
              
            }));

        // HttpRestful.Instance.Get("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=28582A112299D03C6C51E463A1F15081&steamids=76561199546918606",(
        //     (b, s) =>
        //     {
        //         if (b)
        //         {
        //             ui_txt.text = s;
        //             
        //             Debug.Log(s);
        //         }
        //     }));
    }

  
}

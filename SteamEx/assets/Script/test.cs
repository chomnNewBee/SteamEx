using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HttpRestful.Instance.Get("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=28582A112299D03C6C51E463A1F15081&steamids=76561199546918606",(
            (b, s) =>
            {
                if (b)
                {
                    Debug.Log(s);
                }
            }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

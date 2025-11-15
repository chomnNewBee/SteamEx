using QFramework;
using Script.ChomnFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Command;
using UnityEngine;

namespace Script.SteamExLogic.View
{
    public class GameViewCtrl : MonoBehaviourEx<GameViewCtrl>
    {
        public override void StartEx()
        {
            base.StartEx();
            //this.SendCommand(new GetUserInfoCmd("76561199546918606"));
          
        }
    }
}

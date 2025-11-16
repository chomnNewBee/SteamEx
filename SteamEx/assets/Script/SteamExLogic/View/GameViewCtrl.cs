using QFramework;
using Script.ChomnFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Command;
using TMPro;
using UnityEngine;

namespace Script.SteamExLogic.View
{
    public class GameViewCtrl : MonoBehaviourEx<GameViewCtrl>
    {
        public TMP_Text ui_txt_fps;
        public override void StartEx()
        {
            base.StartEx();
            //this.SendCommand(new GetUserInfoCmd("76561199546918606"));
            //UnityEngine.Application.targetFrameRate = 120;
            
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 120;
            this.GetUtility<IFPSEx>().AddListener((fps =>
            {
                ui_txt_fps.text = "FPS: " + fps;
            }));
            
        }
    }
}

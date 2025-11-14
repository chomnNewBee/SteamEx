using QFramework;
using Script.ChomnFramework;
using Script.SteamExLogic.Command;

namespace Script.SteamExLogic.View
{
    public class GameViewCtrl : MonoBehaviourEx<GameViewCtrl>
    {
        public override void StartEx()
        {
            base.StartEx();
            this.SendCommand(new GetUserInfoCmd("76561199546918606"));
        }
    }
}

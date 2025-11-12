using QFramework;
using Script.SteamExLogic.Command;

namespace Script.SteamExLogic.Model
{
    public interface ISteamUserInfo : IModel
    {
        SC_GetUserInfo userInfo { get; set; }
    }
    public class SteamUserInfoModel : AbstractModel,ISteamUserInfo
    {
        public SC_GetUserInfo userInfo { get; set; }
        protected override void OnInit()
        {
            
        }


        
    }
}
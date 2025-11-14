using QFramework;

namespace Script.SteamExLogic.Model
{
    public interface ISDKModel : IModel
    {
        public string SteamToken { get; }
        string SteamUrl_GetUserInfo { get; }
    }
    public class SDKModel:AbstractModel,ISDKModel
    {
        public string SteamToken { get; } = "28582A112299D03C6C51E463A1F15081";
        public string SteamUrl_GetUserInfo { get; } = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/";
        protected override void OnInit()
        {
            
        }

        
    }
}
using QFramework;

namespace Script.SteamExLogic.Model
{
    public interface ISDKModel : IModel
    {
        public string SteamToken { get; }
    }
    public class SDKModel:AbstractModel,ISDKModel
    {
        public string SteamToken { get; } = "28582A112299D03C6C51E463A1F15081";
        protected override void OnInit()
        {
            
        }

        
    }
}
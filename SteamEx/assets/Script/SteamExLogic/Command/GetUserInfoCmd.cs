using System.Collections.Generic;
using QFramework;
using Script.ChomnFramework.Utility;
using Script.SteamExLogic.Model;
using UnityEngine;

namespace Script.SteamExLogic.Command
{
    public class GetUserInfoCmd : AbstractCommand
    {
        private readonly string steamId;
        

        public GetUserInfoCmd(string steamId)
        {
            this.steamId = steamId;
            
        }
        protected override void OnExecute()
        {
            string steamToken = this.GetModel<ISDKModel>().SteamToken;
            string url = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={steamToken}&steamids={this.steamId}";
            this.GetUtility<IHttpHelper>().Get(url, (ret =>
            {
                Debug.Log(ret);
                SC_GetUserInfo userInfo = this.GetUtility<IJsonHelper>().FromJson<SC_GetUserInfo>(ret);
                this.GetModel<ISteamUserInfo>().userInfo = userInfo;
                this.SendEvent<OnUserInfoUpdate>();
            }),(Debug.LogError));
        }
        
        
    }

    public struct OnUserInfoUpdate
    {
    }
    public class PlayersItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string steamid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int communityvisibilitystate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int profilestate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string personaname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string profileurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarmedium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarfull { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarhash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lastlogoff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int personastate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string realname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string primaryclanid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timecreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int personastateflags { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public List <PlayersItem > players { get; set; }
    }

    public class SC_GetUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Response response { get; set; }
    }

}
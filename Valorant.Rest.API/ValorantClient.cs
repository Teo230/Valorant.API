using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Valorant.Rest.API.ModelDTO;
using static Valorant.Rest.API.Utilities.ValorantEnum;

namespace Valorant.Rest.API
{
    public class ValorantClient
    {
        private HttpClient _session;

        public ValorantClient(HttpClient session, string clientVersion)
        {
            _session = session;
            _session.DefaultRequestHeaders.Add("X-Riot-ClientVersion", clientVersion);
        }

        #region PrivateClientRequest
        private T Post<T>(string url, dynamic data)
        {
            var result = _session.PostAsync(url, new StringContent(data.ToString(), Encoding.UTF8, "application/json")).Result;

            if (result.IsSuccessStatusCode)
            {
                var resultString = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resultString);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception();
                throw new Exception("POST Call failure");
            }
        }

        private T Get<T>(string url)
        {
            var result = _session.GetAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {
                var resultString = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resultString);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception();
                throw new Exception("GET Call failure");
            }
        }

        private T Put<T>(string url, dynamic data)
        {
            var result = _session.PutAsync(url, new StringContent(data.ToString(), Encoding.UTF8, "application/json")).Result;

            if (result.IsSuccessStatusCode)
            {
                var resultString = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resultString);
            }
            else
            {
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception();
                throw new Exception("PUT Call failure");
            }
        }
        #endregion

        private string GetAuthorization()
        {
            dynamic data = new JObject();

            data.client_id = "play-valorant-web-prod";
            data.nonce = "1";
            data.redirect_uri = "https://playvalorant.com/opt_in";
            data.response_type = "token id_token";

            return Post<dynamic>("https://auth.riotgames.com/api/v1/authorization", data).type;
        }

        private string GetRightEndpoint(RegionEnum region)
        {
            switch (region)
            {
                case RegionEnum.Europe:
                    return "https://pd.EU.a.pvp.net/";
                case RegionEnum.NorthAmerica:
                    return "https://pd.NA.a.pvp.net/";
                case RegionEnum.Asia:
                    return "https://pd.AP.a.pvp.net/";
                case RegionEnum.Korea:
                    return "https://pd.KO.a.pvp.net/";
            }
            return null;
        }

        /// <summary>
        /// Get user parameters.
        /// Use this method to retrieve the Bearer Token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserParametersDTO GetUserParameters(string username, string password)
        {
            dynamic userData = new JObject();

            userData.type = GetAuthorization();
            userData.username = username;
            userData.password = password;

            return Put<UserParametersDTO>("https://auth.riotgames.com/api/v1/authorization", userData);
        }

        /// <summary>
        /// Get the user Entitlements Token
        /// </summary>
        /// <returns></returns>
        public string GetEntitlementsToken()
        {
            return Post<dynamic>("https://entitlements.auth.riotgames.com/api/token/v1", new JObject().ToString()).entitlements_token;
        }

        /// <summary>
        /// Get Player information like Username in game, PlayerId and Tag.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public PlayerDTO GetPlayer(RegionEnum region)
        {
            dynamic data = new JObject();
            List<PlayerDTO> result = Post<List<PlayerDTO>>($"{GetRightEndpoint(region)}userinfo", data);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Get Player's Match History.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public MatchDTO GetMatches(RegionEnum region, string playerId)
        {
            return Get<MatchDTO>($"{GetRightEndpoint(region)}match-history/v1/history/{playerId}");
        }

        /// <summary>
        /// Get User's Valorant Points, Radianite Points, and ___
        /// </summary>
        /// <param name="region"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public BalanceDTO GetBalance(RegionEnum region, string playerId)
        {
            return Get<BalanceDTO>($"{GetRightEndpoint(region)}store/v1/wallet/{playerId}");
        }

        /// <summary>
        /// Shows User' Competitve History, Including Match ID, Competitve Movement, And Tier after update.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public CompetitiveMatchDTO GetCompetitiveMatch(RegionEnum region, string playerId)
        {
            return Get<CompetitiveMatchDTO>($"{GetRightEndpoint(region)}mmr/v1/players/{playerId}/competitiveupdates");
        }

        /// <summary>
        /// Get Player's MMR, Including Competitve Rank, and more.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerMMRDTO GetPlayerMMR(RegionEnum region, string playerId)
        {
            return Get<PlayerMMRDTO>($"{GetRightEndpoint(region)}mmr/v1/players/{playerId}/competitiveupdates");
        }

        /// <summary>
        /// Get Player's store, Including Items, Prices and Featured Bundles.
        /// All of these ID's are listed and provided by method <see cref="GetIDList"></see>
        /// </summary>
        /// <param name="region"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public PlayerStoreDTO GetPlayerStore(RegionEnum region, string playerId)
        {
            return Get<PlayerStoreDTO>($"{GetRightEndpoint(region)}store/v2/storefront/{playerId}");
        }

        /// <summary>
        /// Get all Items, Maps, Attachments, Sprays, GameModes, Charms, etc Ids.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public IdListDTO GetIDList(RegionEnum region)
        {
            return Get<IdListDTO>($"{GetRightEndpoint(region).Replace("pd","shared")}content-service/v2/content");
        }

        /// <summary>
        /// Get Infomation regarding the Contract
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public StoryContractDTO GetStoryContract(RegionEnum region)
        {
            return Get<StoryContractDTO>($"{GetRightEndpoint(region)}contract-definitions/v2/definitions/story");
        }
    }
}

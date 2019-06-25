using Beblue.CrossCutting.IntegrationSpotify.DTO;
using Beblue.CrossCutting.IntegrationSpotify.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Beblue.CrossCutting.IntegrationSpotify
{
    class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }
    public class SpotiFyIntegrationService : ISpotiFyIntegrationService
    {

        public const string CLIENTID = "f726b11d6b4d4642891a71bd5deb7ff3";
        public const string CLIENTSECRET = "1917ebff93e0419fa2137ab19e8b1fac";
        private async Task<AccessToken> GetAccessToken()
        {
            AccessToken token = new AccessToken();
            string url = "https://accounts.spotify.com/api/token";

            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", CLIENTID, CLIENTSECRET)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = await webRequest.GetRequestStreamAsync();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp =  (HttpWebResponse) await webRequest.GetResponseAsync();
            
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    token = JsonConvert.DeserializeObject<AccessToken>(rdr.ReadToEnd());
                    rdr.Close();
                }
            }

            return token;
        }

        public async Task<List<Item>> RecoverySpotifyDiscs()
        {
            var rootObject = new RootObject();
            var list = new List<Item>();
            var genres =  new List<string> { "pop","rock", "classical" };//TODO não encontrei o id da cetegoria MPB
            string url = " https://api.spotify.com/v1/browse/categories/{0}/playlists?limit=50&offset=0";
            var token = await GetAccessToken();
            foreach (var genre in genres)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(url,genre));

                webRequest.Method = "GET";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("Authorization: Bearer " + token.access_token);

                HttpWebResponse resp = (HttpWebResponse)await webRequest.GetResponseAsync();

                using (Stream respStr = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                    {
                        rootObject = JsonConvert.DeserializeObject<RootObject>(rdr.ReadToEnd());
                        rdr.Close();
                    }
                }

                foreach (var item in rootObject.playlists.items)
                {
                    item.genre = genre;
                    list.Add(item);
                }
                list.AddRange(rootObject.playlists.items);
            }
            return list;
        }
    }
}

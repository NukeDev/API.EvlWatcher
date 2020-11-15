using api.evl.watch.Utils;
using client.evl.watch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace client.evl.watch
{
    public class Client
    {
        private const string API_URL = "http://api.evl.watch.local";
        private const string REGISTER_NEW_USER = API_URL + "/v1/user/register";

        private string ApiKey { get; set; }
        private HttpClient apiClient { get; set; }
        public Client()
        {
            this.apiClient = new HttpClient();
            this.apiClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            this.apiClient.Timeout = new TimeSpan(0, 1, 0);

        }

        public Client(string _apiKey, string _username)
        {
            this.ApiKey = _apiKey;
            this.apiClient = new HttpClient();
            this.apiClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            this.apiClient.Timeout = new TimeSpan(0, 1, 0);
        }

        public async Task<bool> IsApiOnline()
        {
            try
            {
                var data = await apiClient.GetAsync(API_URL);
                if ( data.IsSuccessStatusCode )
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        /// <summary>
        /// By Default it will retun a Task<DefaultResponseModel<string>> but it can throw an ApiException if the Server will deny some inputs!
        /// ApiException will help you to know the problem
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<DefaultResponseModel<string>> Register(User user)
        {
            try
            {
                var myContent = JsonConvert.SerializeObject(user);
                var data = await apiClient.PostAsync(REGISTER_NEW_USER,  new StringContent(myContent, Encoding.UTF8, "application/json"));

                var response =  data.Content.ReadAsStringAsync().Result;
                if ( data.IsSuccessStatusCode )
                {
                    var toReturn = JsonConvert.DeserializeObject<DefaultResponseModel<string>>(response);
                    return toReturn;
                }

                throw JsonConvert.DeserializeObject<ApiException>(response);
            }
            catch(Exception ex )
            {
                throw ex;
            }
            
        }

    }
}

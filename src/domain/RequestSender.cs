using front_bot.src.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;

namespace front_bot.src.domain
{
    internal static class RequestSender
    {
        public static async Task<(int, string?)> SendRegisterRequest(src.repository.User usr)
        {
            string route = Environment.GetEnvironmentVariable("AUTH_BASE_ROUTE")! + "register";

            var postData = new
            {
                uuid = usr.Uuid,
                email = usr.Email,
                password = usr.Password
            };

            string jsonContent = JsonConvert.SerializeObject(postData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(route, content);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;

            Console.WriteLine(responseBody);

            return ((int)response.StatusCode, responseBody);
        }

        public static async Task<(int, string?)> SendLoginRequest(src.repository.User usr)
        {
            string route = Environment.GetEnvironmentVariable("AUTH_BASE_ROUTE")! + "login";

            var postData = new
            {
                email = usr.Email,
                password = usr.Password
            };

            string jsonContent = JsonConvert.SerializeObject(postData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            using HttpClient client = new HttpClient();

            

            HttpResponseMessage response = await client.PostAsync(route, content);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;

            Console.WriteLine(responseBody);

            return ((int)response.StatusCode, responseBody);
        }

        public static async Task<(int, string?)> SendCreateBotRequest(src.repository.User usr, string json)
        {
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots";

            var content = new StringContent(json, Encoding.UTF8, "application/json");


            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.PutAsync(route, content);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }

        public static async Task<(int,string?)> GetUserBots(src.repository.User usr)
        {
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots";

            using HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.GetAsync(route);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }

        public static async Task<(int,string?)> GetBot(src.repository.User usr,string uuid)
        {
    
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots/" + uuid;

            using HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.GetAsync(route);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }
        public static async Task<(int, string?)> TurnON(src.repository.User usr, string bot_uuid)
        {
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots/" + bot_uuid + "/start";

            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.PostAsync(route,null);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }
        public static async Task<(int, string?)> TurnOFF(src.repository.User usr, string bot_uuid)
        {
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots/" + bot_uuid + "/stop";

            using HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.PostAsync(route, null);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }
        public static async Task<(int, string?)> GET_CSV(src.repository.User usr, string bot_uuid)
        {
            string route = Environment.GetEnvironmentVariable("BOTS_BASE_ROUTE")! + "bots/" + bot_uuid + "/answers";

            using HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Jwt);

            HttpResponseMessage response = await client.GetAsync(route);

            string? responseBody = await response.Content.ReadAsStringAsync() ?? null;


            return ((int)response.StatusCode, responseBody);

        }
    
        
    }
}

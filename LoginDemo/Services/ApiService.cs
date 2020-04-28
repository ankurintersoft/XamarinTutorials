using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LoginDemo.Interface;
using LoginDemo.Models;
using Refit;

namespace LoginDemo.Services
{
    public class ApiService : IApi
    {
        private static ApiService _instance;
        public static ApiService Instance = _instance ?? (_instance = new ApiService());
        private readonly IApi _api;

        private ApiService()
        {
            // Debug API code
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri("http://demoapi.ormsmobile.com:9966/api") };
            //_api = RestService.For<IApi>(httpClient);

            _api = RestService.For<IApi>("http://demoapi.ormsmobile.com:9966");
        }

        public async Task<LoginResponse> Login(LoginRequest requestParams)
        {
            try
            {
                LoginResponse data = await _api.Login(requestParams);
                return data;
            }
            catch (ApiException ex)
            {
                return null;
            }
        }
    }
}

//public static async Task<LoginResponse> UserLogin(string username, string password, string grant_type)
//{
//    using (var httpClient = new HttpClient())
//    {
//        var result = new LoginResponse();
//        var requestUri = "http://demoapi.ormsmobile.com:9966";
//        var content = new FormUrlEncodedContent(new[]
//        {
//                new KeyValuePair<string, string>("password", password),
//                new KeyValuePair<string, string>("username", username),
//                new KeyValuePair<string, string>("grant_type","password"),
//                // ...
//            });
//        try
//        {
//            var response = await httpClient.PostAsync(requestUri, content);
//            var responseContent = await response.Content.ReadAsStringAsync();
//            var statusCode = (int)response.StatusCode;
//            if (statusCode != 200 && statusCode != 201)
//            {
//                result.isError = true;
//                if (statusCode == 401)
//                {
//                    result.message = "Authorization failed";
//                    return result;
//                }
//                result.message = "some problem occured, status code" + statusCode;
//            }
//            if (statusCode == 200)
//            {
//                LoginResponse deserialized = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
//                if (deserialized != null)
//                {
//                    result.access_token = deserialized.access_token;
//                    App.userToken = result.access_token;
//                    result.message = "Authorized";
//                }
//                else
//                {
//                    result.message = "Invalid Response from server";
//                }
//            }
//            return result;


//        }
//        catch (Exception ex)
//        {
//            result.isError = true;
//            result.message = "Unable to login. Please check you connection or the server is offline";
//            return result;

//        }


//    }
//}
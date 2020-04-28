using System;
using System.Threading.Tasks;
using LoginDemo.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace LoginDemo.Services
{
    public class CallAPI
    {
        public CallAPI()
        {
        }

        public static async Task<LoginResponse> UserLogin(string username, string password, string grant_type)
        {
            using (var httpClient = new HttpClient())
            {
                //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var result = new LoginResponse();
                var requestUri = "http://demoapi.ormsmobile.com:9966/token";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("grant_type","password"),
                });
                try
                {
                    var response = await httpClient.PostAsync(requestUri, content);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var statusCode = (int)response.StatusCode;
                    if (statusCode != 200 && statusCode != 201)
                    {
                        result.isError = true;
                        if (statusCode == 401)
                        {
                            result.message = "Authorization failed";
                            return result;
                        }
                        result.message = "some problem occured, status code" + statusCode;
                    }
                    if (statusCode == 200)
                    {
                        LoginResponse deserialized = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                        if (deserialized != null)
                        {
                            result.access_token = deserialized.access_token;
                            //App.userToken = result.access_token;
                            result.message = "Authorized";
                        }
                        else
                        {
                            result.message = "Invalid Response from server";
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    result.isError = true;
                    result.message = "Unable to login. Please check you connection or the server is offline";
                    return result;
                }
            }

        }
    }
}

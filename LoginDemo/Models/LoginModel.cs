using System;
using Newtonsoft.Json;

namespace LoginDemo.Models
{
    public class LoginModel
    {
        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }

        //[JsonProperty("email")]
        //public string Email { get; set; }

        //[JsonProperty("photo")]
        //public string Photo { get; set; }
    }

    public class LoginRequest
    {
        public string username { get; set; }
        public string grant_type { get; set; }
        public string password { get; set; }

        public LoginRequest(string usrName, string grntType, string pwd)
        {
            this.username = usrName;
            this.grant_type = grntType;
            this.password = pwd;
        }
    }

    public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string message { get; set; } = "";
        public bool isError { get; set; } = false;
    }
}

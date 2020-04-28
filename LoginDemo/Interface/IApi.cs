using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginDemo.Models;
using Refit;

namespace LoginDemo.Interface
{
    public interface IApi
    {
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/token")]
        Task<LoginResponse> Login([Body(BodySerializationMethod.UrlEncoded)]LoginRequest requestParams);
    }
}
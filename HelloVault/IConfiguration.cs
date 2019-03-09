using System;

namespace HelloVault
{
    public interface IConfiguration
    {
        string Token { get; }
        Uri FieldUrl { get; }
    }
}
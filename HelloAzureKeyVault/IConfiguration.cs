using System;

namespace HelloAzureKeyVault
{
    public interface IConfiguration
    {
        string Token { get; }
        Uri FieldUrl { get; }
    }
}
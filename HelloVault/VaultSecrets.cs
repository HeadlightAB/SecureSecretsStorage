using System.Collections.Generic;
using VaultSharp;

namespace HelloVault
{
    public class VaultSecrets
    {
        public static IDictionary<string, object> Read(VaultClientSettings clientSettings)
        {
            var vaultClient = new VaultClient(clientSettings);
            var secrets = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync("thingspeak", mountPoint: "blog-demo").Result;

            return secrets.Data.Data;
        }
    }
}
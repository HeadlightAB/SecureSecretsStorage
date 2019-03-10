using System.Collections.Generic;
using System.Linq;
using VaultSharp;

namespace HelloVaultWWW
{
    public class VaultSecrets
    {
        public static IEnumerable<KeyValuePair<string, string>> Read(VaultClientSettings clientSettings)
        {
            var vaultClient = new VaultClient(clientSettings);
            var secrets = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync("thingspeak", mountPoint: "blog-demo").Result;

            return secrets.Data.Data.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()));
        }
    }
}
namespace AWSSecretsManagerConsole.Models
{
    public class ClaseTest
    {
        private KeysModel keys;

        public ClaseTest(KeysModel keys)
        {
            this.keys = keys;
        }

        public string GetApiKey()
        {
            return this.keys.Api;
        }
    }
}

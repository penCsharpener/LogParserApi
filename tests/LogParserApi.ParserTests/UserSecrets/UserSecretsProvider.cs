using Microsoft.Extensions.Configuration;

namespace LogParserApi.ParserTests.UserSecrets
{
    public class UserSecretsProvider
    {
        private readonly IConfigurationRoot _config;
        public IConfiguration Configuration => _config;

        public UserSecretsProvider()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddUserSecrets("6eab779a-52ce-4804-a487-a3e381744591");
            _config = configBuilder.Build();
        }
    }
}

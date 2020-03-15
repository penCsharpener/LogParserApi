using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogParserApi.Core.Contracts;
using LogParserApi.Core.Models;
using LogParserApi.ParserTests.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace LogParserApi.ParserTests
{

    [TestFixture]
    public class Log4NetParserTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserSecretsProvider _userSecrets;

        public Log4NetParserTests()
        {
            _userSecrets = new UserSecretsProvider();
            var deps = new DependencyRegistration();
            _serviceProvider = deps.AddLog4NetParser()
                .AddConfigurations(_userSecrets.Configuration)
                .Build();
        }

        [Test]
        public async Task ReadTest()
        {
            var logReader = _serviceProvider.GetService<ILogReader>();
            var locations = _serviceProvider.GetService<IOptions<Locations>>();
            var logs = logReader.ReadAsync(locations.Value.FilePaths.FirstOrDefault());
            var logList = new List<LogEntry>();
            await foreach (var logEntry in logs)
            {
                logList.Add(logEntry);
            }

            Assert.IsTrue(logList.Count > 0);
        }
    }
}
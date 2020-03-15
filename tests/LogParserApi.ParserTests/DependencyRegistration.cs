using System;
using LogParserApi.Core.Contracts;
using LogParserApi.Parsers;
using LogParserApi.Parsers.FileSystem;
using LogParserApi.Parsers.Log4Net;
using LogParserApi.ParserTests.UserSecrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogParserApi.ParserTests
{
    public class DependencyRegistration
    {
        private readonly ServiceCollection _services;

        public DependencyRegistration()
        {
            _services = new ServiceCollection();
            _services.AddTransient<IFileReader, FileReader>();
        }

        public DependencyRegistration AddLog4NetParser()
        {
            _services.AddTransient<ILogReader, Log4NetParser>();
            _services.AddSingleton<ILineParser, Log4NetLineParser>();
            return this;
        }

        public DependencyRegistration AddConfigurations(IConfiguration config)
        {
            _services.Configure<Locations>(config.GetSection(nameof(Locations)));
            return this;
        }

        public IServiceProvider Build()
        {
            return _services.BuildServiceProvider();
        }
    }
}

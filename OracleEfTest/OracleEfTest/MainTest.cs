using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OracleEfTest.Logger;
using System;
using System.Threading.Tasks;

namespace OracleEfTest
{
    public class Tests
    {
        static string connectStr = "DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=***)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));PASSWORD=***;PERSIST SECURITY INFO=True;USER ID=***; enlist=dynamic;";
        private static MyDbContext _dbcontext;
        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<MyDbContext>(builder => {
                var loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new EFLoggerProvider());
                builder.UseOracle(connectStr, opt =>
                {
                    opt.UseOracleSQLCompatibility("11");
                }).UseLoggerFactory(loggerFactory);
            });
            IServiceProvider sp = services.BuildServiceProvider();
            _dbcontext = sp.GetService<MyDbContext>();
        }

        [Test]
        public async Task CreateRightSQL()
        {
            var service = new ParentService(_dbcontext);
            await service.Get1();            
        }

        [Test]
        public async Task CreateWrongSQL1()
        {
            var service = new ParentService(_dbcontext);
            await service.Get2();
        }
        [Test]
        public async Task CreateWrongSQL2()
        {
            var service = new ParentService(_dbcontext);
            await service.Get3();
        }
    }
}

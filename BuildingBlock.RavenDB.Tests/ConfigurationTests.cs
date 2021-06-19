using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using Xunit;

namespace BuildingBlock.RavenDB.Tests
{
    public class ConfigurationTests
    {

            [Fact]
            public void RAVENDB_INSTANCE_NAME_IS_EMPTY()
            {
                const string msg = "O parametro RAVENDB_INSTANCE_NAME está null ou empty";

                var ex = Assert.Throws<ArgumentException>(() => Configurations.Configurations.AddRavenDB(It.IsAny<IServiceCollection>(), It.IsAny<IConfiguration>()));
                Assert.AreEqual(msg, ex.Message);
            }
        
    }
}
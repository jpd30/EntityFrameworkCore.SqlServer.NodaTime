using EntityFrameworkCore.SqlServer.NodaTime.Scaffolding.Internal;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.SqlServer.NodaTime.Design.Internal
{
    public class SqlServerNodaTimeDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<IRelationalTypeMappingSourcePlugin, SqlServerNodaTimeTypeMappingSourcePlugin>()
                .AddSingleton<IProviderCodeGeneratorPlugin, SqlServerNodaTimeCodeGeneratorPlugin>();
    }
}

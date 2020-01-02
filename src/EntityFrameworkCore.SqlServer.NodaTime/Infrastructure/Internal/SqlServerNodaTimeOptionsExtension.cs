using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.SqlServer.NodaTime.Infrastructure.Internal
{
    public class SqlServerNodaTimeOptionsExtension : IDbContextOptionsExtension
    {
        private DbContextOptionsExtensionInfo info;

        public DbContextOptionsExtensionInfo Info => this.info ??= new ExtensionInfo(this);

        public void ApplyServices(IServiceCollection services) => services.AddEntityFrameworkSqlServerNodaTime();

        public void Validate(IDbContextOptions options)
        {
            var internalServiceProvider = options.FindExtension<CoreOptionsExtension>()?.InternalServiceProvider;
            if (internalServiceProvider != null)
            {
                using (var scope = internalServiceProvider.CreateScope())
                {
                    if (scope.ServiceProvider.GetService<IEnumerable<IRelationalTypeMappingSourcePlugin>>()
                        ?.Any(s => s is SqlServerNodaTimeTypeMappingSourcePlugin) != true)
                    {
                        throw new InvalidOperationException($"{nameof(SqlServerNodaTimeDbContextOptionsBuilderExtensions.UseNodaTime)} requires {nameof(SqlServerNodaTimeServiceCollectionExtensions.AddEntityFrameworkSqlServerNodaTime)} to be called on the internal service provider used.");
                    }
                }
            }
        }

        private sealed class ExtensionInfo : DbContextOptionsExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
            }

            new SqlServerNodaTimeOptionsExtension Extension => (SqlServerNodaTimeOptionsExtension)base.Extension;

            public override bool IsDatabaseProvider => false;

            public override long GetServiceProviderHashCode() => 0;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo) =>
                debugInfo["SqlServer:" + nameof(SqlServerNodaTimeDbContextOptionsBuilderExtensions.UseNodaTime)] = "1";

            public override string LogFragment => "using NodaTime ";
        }
    }
}

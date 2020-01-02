using EntityFrameworkCore.SqlServer.NodaTime.Query.ExpressionTranslators.Internal;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.SqlServer.NodaTime.Extensions
{
    public static class SqlServerNodaTimeServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkSqlServerNodaTime(
            [NotNull] this IServiceCollection serviceCollection)
        {
            Check.NotNull(serviceCollection, nameof(serviceCollection));

            new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAddProviderSpecificServices(
                    x => x
                        .TryAddSingletonEnumerable<IRelationalTypeMappingSourcePlugin, SqlServerNodaTimeTypeMappingSourcePlugin>()
                        .TryAddSingletonEnumerable<IMethodCallTranslatorPlugin, SqlServerNodaTimeMethodCallTranslatorPlugin>()
                        .TryAddSingletonEnumerable<IMemberTranslatorPlugin, SqlServerNodaTimeMemberTranslatorPlugin>());

            return serviceCollection;
        }
    }
}

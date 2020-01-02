using EntityFrameworkCore.SqlServer.NodaTime.Infrastructure.Internal;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.SqlServer.NodaTime.Extensions
{
    public static class SqlServerNodaTimeDbContextOptionsBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder UseNodaTime(
            [NotNull] this SqlServerDbContextOptionsBuilder optionsBuilder)
        {
            var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;

            var extension = coreOptionsBuilder.Options.FindExtension<SqlServerNodaTimeOptionsExtension>()
                ?? new SqlServerNodaTimeOptionsExtension();

            ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }
    }
}

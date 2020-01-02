using EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace EntityFrameworkCore.SqlServer.NodaTime.Scaffolding.Internal
{
    public class SqlServerNodaTimeCodeGeneratorPlugin : ProviderCodeGeneratorPlugin
    {
        public override MethodCallCodeFragment GenerateProviderOptions()
            => new MethodCallCodeFragment(nameof(SqlServerNodaTimeDbContextOptionsBuilderExtensions.UseNodaTime));
    }
}

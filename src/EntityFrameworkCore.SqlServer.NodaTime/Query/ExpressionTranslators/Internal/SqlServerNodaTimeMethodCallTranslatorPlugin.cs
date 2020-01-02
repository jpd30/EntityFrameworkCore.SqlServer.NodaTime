using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.SqlServer.NodaTime.Query.ExpressionTranslators.Internal
{
    public class SqlServerNodaTimeMethodCallTranslatorPlugin : IMethodCallTranslatorPlugin
    {
        public SqlServerNodaTimeMethodCallTranslatorPlugin(ISqlExpressionFactory sqlExpressionFactory)
        {
            this.Translators = new IMethodCallTranslator[]
            {
                new SqlServerNodaTimeMethodCallTranslator(sqlExpressionFactory)
            };
        }

        public IEnumerable<IMethodCallTranslator> Translators { get; }
    }
}

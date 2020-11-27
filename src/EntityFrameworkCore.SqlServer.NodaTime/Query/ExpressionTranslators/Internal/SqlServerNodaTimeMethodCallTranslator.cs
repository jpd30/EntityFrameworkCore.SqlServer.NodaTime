using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EntityFrameworkCore.SqlServer.NodaTime.Query.ExpressionTranslators.Internal
{
    public class SqlServerNodaTimeMethodCallTranslator : IMethodCallTranslator
    {
        readonly ISqlExpressionFactory sqlExpressionFactory;

        public SqlServerNodaTimeMethodCallTranslator(ISqlExpressionFactory sqlExpressionFactory)
            => this.sqlExpressionFactory = sqlExpressionFactory;

        /// <inheritdoc />
        [CanBeNull]
        public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger) => null;
    }
}

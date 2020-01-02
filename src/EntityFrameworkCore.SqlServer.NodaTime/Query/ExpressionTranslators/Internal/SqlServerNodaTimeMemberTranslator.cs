using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EntityFrameworkCore.SqlServer.NodaTime.Query.ExpressionTranslators.Internal
{
    internal class SqlServerNodaTimeMemberTranslator : IMemberTranslator
    {
        private readonly ISqlExpressionFactory sqlExpressionFactory;

        public SqlServerNodaTimeMemberTranslator(ISqlExpressionFactory sqlExpressionFactory) =>
            this.sqlExpressionFactory = sqlExpressionFactory;

        public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType) => null;
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.SqlServer.NodaTime.Query.ExpressionTranslators.Internal
{
    public class SqlServerNodaTimeMemberTranslatorPlugin : IMemberTranslatorPlugin
    {
        public SqlServerNodaTimeMemberTranslatorPlugin(ISqlExpressionFactory sqlExpressionFactory)
        {
            this.Translators = new IMemberTranslator[]
            {
                new SqlServerNodaTimeMemberTranslator(sqlExpressionFactory)
            };
        }

        public IEnumerable<IMemberTranslator> Translators { get; }
    }
}

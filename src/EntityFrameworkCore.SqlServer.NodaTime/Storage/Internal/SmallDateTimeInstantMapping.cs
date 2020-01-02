using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class SmallDateTimeInstantMapping : RelationalTypeMapping
    {
        public SmallDateTimeInstantMapping()
            : base(SqlServerTypeNames.SmallDateTime, typeof(Instant))
        {
        }

        protected SmallDateTimeInstantMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => InstantToDateTimeConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.SmallDateTimeFormat;

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new SmallDateTimeInstantMapping(parameters);

        protected override void ConfigureParameter(DbParameter parameter)
        {
            base.ConfigureParameter(parameter);

            if (parameter is SqlParameter sqlParameter)
            {
                sqlParameter.SqlDbType = SqlDbType.SmallDateTime;
            }
        }
    }
}

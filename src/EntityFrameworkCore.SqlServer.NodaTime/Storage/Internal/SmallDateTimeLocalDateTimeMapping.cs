using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class SmallDateTimeLocalDateTimeMapping : RelationalTypeMapping
    {
        public SmallDateTimeLocalDateTimeMapping()
            : base(SqlServerTypeNames.SmallDateTime, typeof(LocalDateTime))
        {
        }

        protected SmallDateTimeLocalDateTimeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => LocalDateTimeToDateTimeConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.SmallDateTimeFormat;

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new SmallDateTimeLocalDateTimeMapping(parameters);

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

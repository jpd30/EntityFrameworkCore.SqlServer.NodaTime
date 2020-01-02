using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class DateTimeLocalDateTimeMapping : RelationalTypeMapping
    {
        public DateTimeLocalDateTimeMapping()
            : base(SqlServerTypeNames.DateTime, typeof(LocalDateTime))
        {
        }

        protected DateTimeLocalDateTimeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => LocalDateTimeToDateTimeConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.DateTimeFormat;

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new DateTimeLocalDateTimeMapping(parameters);

        protected override void ConfigureParameter(DbParameter parameter)
        {
            base.ConfigureParameter(parameter);

            if (parameter is SqlParameter sqlParameter)
            {
                sqlParameter.SqlDbType = SqlDbType.DateTime;
            }

            if (Size.HasValue && Size.Value != -1)
            {
                parameter.Size = Size.Value;
            }
        }
    }
}

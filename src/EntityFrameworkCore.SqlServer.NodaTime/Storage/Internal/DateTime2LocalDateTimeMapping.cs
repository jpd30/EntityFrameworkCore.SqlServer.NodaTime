using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class DateTime2LocalDateTimeMapping : RelationalTypeMapping
    {
        public DateTime2LocalDateTimeMapping()
            : base(SqlServerTypeNames.DateTime2, typeof(LocalDateTime))
        {
        }

        protected DateTime2LocalDateTimeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => LocalDateTimeToDateTimeConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.GetDateTime2Format(this.Size);

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new DateTime2LocalDateTimeMapping(parameters);

        protected override void ConfigureParameter(DbParameter parameter)
        {
            base.ConfigureParameter(parameter);

            if (parameter is SqlParameter sqlParameter)
            {
                sqlParameter.SqlDbType = SqlDbType.DateTime2;
            }

            if (Size.HasValue && Size.Value != -1)
            {
                parameter.Size = Size.Value;
            }
        }
    }
}

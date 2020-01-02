using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class TimeLocalTimeMapping : RelationalTypeMapping
    {
        public TimeLocalTimeMapping()
            : base(SqlServerTypeNames.Time, typeof(LocalTime))
        {
        }

        protected TimeLocalTimeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => LocalTimeToTimeSpanConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.GetTimeFormat(Size);

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new TimeLocalTimeMapping(parameters);

        protected override void ConfigureParameter(DbParameter parameter)
        {
            base.ConfigureParameter(parameter);

            if (parameter is SqlParameter sqlParameter)
            {
                sqlParameter.SqlDbType = SqlDbType.Time;
            }

            if (Size.HasValue && Size.Value != -1)
            {
                parameter.Size = Size.Value;
            }
        }
    }
}

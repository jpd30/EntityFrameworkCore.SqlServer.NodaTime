using System.Data;
using System.Data.Common;
using EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class DateLocalDateMapping : RelationalTypeMapping
    {
        public DateLocalDateMapping()
            : base(SqlServerTypeNames.Date, typeof(LocalDate))
        {
        }

        protected DateLocalDateMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }

        public override ValueConverter Converter => LocalDateToDateTimeConverter.Instance;

        protected override string SqlLiteralFormatString => FormatStrings.DateFormat;

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new DateLocalDateMapping(parameters);

        protected override void ConfigureParameter(DbParameter parameter)
        {
            base.ConfigureParameter(parameter);

            if (parameter is SqlParameter sqlParameter)
            {
                sqlParameter.SqlDbType = SqlDbType.Date;
            }
        }
    }
}

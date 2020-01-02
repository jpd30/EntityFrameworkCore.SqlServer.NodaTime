using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal class OffsetDateTimeToDateTimeOffsetConverter : ValueConverter<OffsetDateTime, DateTimeOffset>
    {
        public readonly static OffsetDateTimeToDateTimeOffsetConverter Instance = new OffsetDateTimeToDateTimeOffsetConverter();

        private OffsetDateTimeToDateTimeOffsetConverter()
            : base(
                  offsetDateTime => offsetDateTime.ToDateTimeOffset(),
                  dateTimeOffset => OffsetDateTime.FromDateTimeOffset(dateTimeOffset))
        {
        }
    }
}

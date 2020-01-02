using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal class InstantToDateTimeOffsetConverter : ValueConverter<Instant, DateTimeOffset>
    {
        public readonly static InstantToDateTimeOffsetConverter Instance = new InstantToDateTimeOffsetConverter();

        private InstantToDateTimeOffsetConverter()
            : base(
                  instant => instant.ToDateTimeOffset(),
                  dateTimeOffset => Instant.FromDateTimeOffset(dateTimeOffset))
        {
        }
    }
}

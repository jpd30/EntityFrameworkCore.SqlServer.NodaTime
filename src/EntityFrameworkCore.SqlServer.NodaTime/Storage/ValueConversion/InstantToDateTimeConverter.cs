using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal sealed class InstantToDateTimeConverter : ValueConverter<Instant, DateTime>
    {
        public readonly static InstantToDateTimeConverter Instance = new InstantToDateTimeConverter();

        private InstantToDateTimeConverter()
            : base(
                  instant => instant.ToDateTimeUtc(),
                  dateTime => Instant.FromDateTimeUtc(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)))
        {
        }
    }
}

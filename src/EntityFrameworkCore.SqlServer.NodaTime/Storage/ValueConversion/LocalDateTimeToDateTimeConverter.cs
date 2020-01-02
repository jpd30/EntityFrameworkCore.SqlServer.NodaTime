using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal class LocalDateTimeToDateTimeConverter : ValueConverter<LocalDateTime, DateTime>
    {
        public readonly static LocalDateTimeToDateTimeConverter Instance = new LocalDateTimeToDateTimeConverter();

        private LocalDateTimeToDateTimeConverter()
            : base(
                  localDateTime => localDateTime.ToDateTimeUnspecified(),
                  dateTime => LocalDateTime.FromDateTime(dateTime))
        {
        }
    }
}

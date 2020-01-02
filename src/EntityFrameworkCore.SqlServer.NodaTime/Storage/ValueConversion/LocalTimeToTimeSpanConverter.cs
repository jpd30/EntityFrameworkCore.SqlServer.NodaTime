using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal class LocalTimeToTimeSpanConverter : ValueConverter<LocalTime, TimeSpan>
    {
        public readonly static LocalTimeToTimeSpanConverter Instance = new LocalTimeToTimeSpanConverter();
        private LocalTimeToTimeSpanConverter()
            : base(
                  localTime => new TimeSpan(localTime.TickOfDay),
                  timeSpan => LocalTime.FromTicksSinceMidnight(timeSpan.Ticks))
        {
        }
    }
}

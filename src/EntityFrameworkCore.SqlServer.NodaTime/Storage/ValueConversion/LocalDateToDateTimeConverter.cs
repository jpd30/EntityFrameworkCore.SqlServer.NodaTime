using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.ValueConversion
{
    internal class LocalDateToDateTimeConverter : ValueConverter<LocalDate, DateTime>
    {
        public readonly static LocalDateToDateTimeConverter Instance = new LocalDateToDateTimeConverter();

        private LocalDateToDateTimeConverter()
            : base(
                  localDate => localDate.ToDateTimeUnspecified(),
                  dateTime => LocalDate.FromDateTime(dateTime))
        {
        }
    }
}

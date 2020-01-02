using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using NodaTime;

namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    public class SqlServerNodaTimeTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
    {
        private readonly Dictionary<string, RelationalTypeMapping[]> storeTypeMappings;

        private readonly Dictionary<Type, RelationalTypeMapping> clrTypeMappings;

        private readonly string[] storeTypesWithPrecision =
        {
            SqlServerTypeNames.DateTime,
            SqlServerTypeNames.DateTime2,
            SqlServerTypeNames.DateTimeOffset,
            SqlServerTypeNames.Time
        };

        public SqlServerNodaTimeTypeMappingSourcePlugin()
        {
            var dateLocalDateMapping = new DateLocalDateMapping();
            var dateTime2InstantMapping = new DateTime2InstantMapping();
            var dateTime2LocalDateTimeMapping = new DateTime2LocalDateTimeMapping();
            var dateTimeInstantMapping = new DateTimeInstantMapping();
            var dateTimeLocalDateTimeMapping = new DateTimeLocalDateTimeMapping();
            var dateTimeOffsetInstantMapping = new DateTimeOffsetInstantMapping();
            var dateTimeOffsetOffsetDateTimeMapping = new DateTimeOffsetOffsetDateTimeMapping();
            var smallDateTimeInstantMapping = new SmallDateTimeInstantMapping();
            var smallDateTimeLocalDateTimeMapping = new SmallDateTimeLocalDateTimeMapping();
            var timeLocalTimeMapping = new TimeLocalTimeMapping();

            this.storeTypeMappings = new Dictionary<string, RelationalTypeMapping[]>
            {
                { SqlServerTypeNames.Date, new RelationalTypeMapping[] { dateLocalDateMapping } },
                { SqlServerTypeNames.DateTime, new RelationalTypeMapping[] { dateTimeInstantMapping, dateTimeLocalDateTimeMapping } },
                { SqlServerTypeNames.DateTime2, new RelationalTypeMapping[] { dateTime2InstantMapping, dateTime2LocalDateTimeMapping} },
                { SqlServerTypeNames.DateTimeOffset, new RelationalTypeMapping[] { dateTimeOffsetOffsetDateTimeMapping, dateTimeOffsetInstantMapping } },
                { SqlServerTypeNames.SmallDateTime, new RelationalTypeMapping[] { smallDateTimeInstantMapping, smallDateTimeLocalDateTimeMapping } },
                { SqlServerTypeNames.Time, new RelationalTypeMapping[] { timeLocalTimeMapping } }
            };

            this.clrTypeMappings = new Dictionary<Type, RelationalTypeMapping>
            {
                { typeof(Instant), dateTime2InstantMapping },
                { typeof(LocalDate), dateLocalDateMapping },
                { typeof(LocalTime), timeLocalTimeMapping },
                { typeof(LocalDateTime), dateTime2LocalDateTimeMapping },
                { typeof(OffsetDateTime), dateTimeOffsetOffsetDateTimeMapping }
            };
        }

        public RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var storeTypeName = mappingInfo.StoreTypeName;
            var storeTypeNameBase = mappingInfo.StoreTypeNameBase;
            var clrType = mappingInfo.ClrType;

            if (storeTypeName != null)
            {
                if (this.storeTypeMappings.TryGetValue(storeTypeName, out var storeTypeNameMappings))
                {
                    return clrType == null ? storeTypeNameMappings[0] : storeTypeNameMappings.FirstOrDefault(m => m.ClrType == clrType);
                }

                if (this.storeTypeMappings.TryGetValue(storeTypeNameBase, out var storeTypeNameBaseMappings))
                {
                    return clrType == null ? storeTypeNameBaseMappings[0].Clone(mappingInfo) : storeTypeNameBaseMappings.FirstOrDefault(m => m.ClrType == clrType).Clone(mappingInfo);
                }
            }

            if (clrType == null || !this.clrTypeMappings.TryGetValue(clrType, out var clrTypeMapping))
            {
                return null;
            }

            return mappingInfo.Precision.HasValue && storeTypesWithPrecision.Contains(clrTypeMapping.StoreType)
                ? clrTypeMapping.Clone($"{clrTypeMapping.StoreType}({mappingInfo.Precision.Value})", null)
                : clrTypeMapping;
        }
    }
}

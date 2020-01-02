namespace EntityFrameworkCore.SqlServer.NodaTime.Storage.Internal
{
    internal static class FormatStrings
    {
        public const string DateFormat = "'{0:yyyy-MM-dd}'";
        public const string SmallDateTimeFormat = "'{0:yyyy-MM-ddTHH:mm:ss}'";
        public const string DateTimeFormat = "'{0:yyyy-MM-dd HH:mm:ss.fff}'";

        private static readonly string[] dateTime2Formats =
        {
            "'{0:yyyy-MM-ddTHH:mm:ss}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.f}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ff}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fff}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffff}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffff}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffffff}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffffff}'"
        };

        private static readonly string[] dateTimeOffsetUtcFormats =
        {
            "'{0:yyyy-MM-ddTHH:mm:ss}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.f}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ff}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fff}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffff}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffff}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffffff}+00:00'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffffff}+00:00'"
        };

        private static readonly string[] dateTimeOffsetFormats =
        {
            "'{0:yyyy-MM-ddTHH:mm:sso<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffffo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffffo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.ffffffo<+HH:mm>}'",
            "'{0:yyyy-MM-ddTHH:mm:ss.fffffffo<+HH:mm>}'"
        };

        private static readonly string[] timeFormats =
        {
            "'{0:HH:mm:ss}'",
            "'{0:HH:mm:ss.f}'",
            "'{0:HH:mm:ss.ff}'",
            "'{0:HH:mm:ss.fff}'",
            "'{0:HH:mm:ss.ffff}'",
            "'{0:HH:mm:ss.fffff}'",
            "'{0:HH:mm:ss.ffffff}'",
            "'{0:HH:mm:ss.fffffff}'"
        };

        public static string GetDateTime2Format(int? size = null) =>
            size.HasValue && size.Value >= 0 && size.Value < dateTime2Formats.Length
                ? dateTime2Formats[size.Value]
                : dateTime2Formats[^1];

        public static string GetDateTimeOffsetUtcFormat(int? size = null) =>
            size.HasValue && size.Value >= 0 && size.Value < dateTimeOffsetUtcFormats.Length
                ? dateTimeOffsetUtcFormats[size.Value]
                : dateTimeOffsetUtcFormats[^1];

        public static string GetDateTimeOffsetFormat(int? size = null) =>
            size.HasValue && size.Value >= 0 && size.Value < dateTimeOffsetFormats.Length
                ? dateTimeOffsetFormats[size.Value]
                : dateTimeOffsetFormats[^1];

        public static string GetTimeFormat(int? size = null) =>
            size.HasValue && size.Value >= 0 && size.Value < timeFormats.Length
                ? timeFormats[size.Value]
                : timeFormats[^1];
    }
}

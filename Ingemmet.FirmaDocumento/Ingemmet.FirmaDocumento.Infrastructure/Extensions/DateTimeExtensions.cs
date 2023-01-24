using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ingemmet.FirmaDocumento.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = new CultureInfo("es-ES");
            return dayInWeek.GetFirstDayOfWeek(defaultCultureInfo);
        }


        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        /// <summary>
        /// Converts a DateTime into a (JavaScript parsable) Int64.
        /// </summary>
        /// <param name="from">The DateTime to convert from</param>
        /// <returns>An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</returns>
        public static Int64 GetTime(this DateTime from)
        {
            var timeElapsed = (from.ToUniversalTime() - new DateTime(1970, 1, 1));
            return (Int64)(timeElapsed.TotalMilliseconds + 0.5);
        }

        /// <summary>
        /// Converts a (JavaScript parsable) Int64 into a DateTime.
        /// </summary>
        /// <param name="from">An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</param>
        /// <returns>The date as a DateTime</returns>
        public static DateTime ConvertToDateTime(this long from)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(from);
        }

        /// <summary>
        /// Cambiar horas, minutos, segundos y milisegundos de una fecha.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ChangeTime(this DateTime dateTime, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        /// <summary>
        /// Valida formato 24 horas (HH:mm:ss)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool ValidateTime(this string time)
            => new Regex("^([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?$").IsMatch(time);

        /// Extension method parsing a date string to a DateTime? <para/>
        /// <summary>
        /// </summary>
        /// <param name="dateTimeStr">The date string to parse</param>
        /// <param name="dateFmt">dateFmt is optional and allows to pass 
        /// a parsing pattern array or one or more patterns passed 
        /// as string parameters</param>
        /// <returns>Parsed DateTime or null</returns>
        public static DateTime? ToDate(this string dateTimeStr, params string[] dateFmt)
        {
            // example: var dt = "2011-03-21 13:26".ToDate(new string[]{"yyyy-MM-dd HH:mm", 
            //                                                  "M/d/yyyy h:mm:ss tt"});
            // or simpler: 
            // var dt = "2011-03-21 13:26".ToDate("yyyy-MM-dd HH:mm", "M/d/yyyy h:mm:ss tt");
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            if (dateFmt == null)
            {
                var dateInfo = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                dateFmt = dateInfo.GetAllDateTimePatterns();
            }       

            var result = DateTime.TryParseExact(dateTimeStr, dateFmt, CultureInfo.InvariantCulture,
                           style, out var dt) ? dt : null as DateTime?;
            return result;
        }
    }
}

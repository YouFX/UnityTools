using System;


public static class TimeTool
{
    public static long GetNowTimeLong()
    {
        DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        TimeSpan toNow = DateTime.Now.Subtract(dtStart);
        return Convert.ToInt64(toNow.TotalSeconds);
    }

    public static string GetNowTimeString()
    {
        DateTime dateTime = DateTime.Now;
        return string.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}", dateTime.Year, dateTime.Month, dateTime.Day,
            dateTime.Hour, dateTime.Minute, dateTime.Second);
    }

    // DateTime --> long
    public static long ConvertDateTimeToLong(DateTime dt)
    {
        DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        TimeSpan toNow = dt.Subtract(dtStart);
        return Convert.ToInt64(toNow.TotalSeconds);
    }


// long --> DateTime
    public static DateTime ConvertLongToDateTime(long d)
    {
        return TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local).AddSeconds(d);
    }
}
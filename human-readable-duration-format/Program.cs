// sec in a year
const long year = 31536000;
// sec in a day
const long day = 86400;
// sec in an hour
const long hour = 3600;
// sec in minute
const long minute = 60;

string formatDuration(int seconds)
{
    // 0 seconds case
    if (seconds == 0)
    {
        return "now";
    }
    // case up to a minute
    if (seconds > 0 && seconds < minute)
    {
        if (seconds == 1)
        {
            return $"{seconds} second";
        }
        return $"{seconds} seconds";
    }
    // place to store intermediate result which consist of parts
    var resultParts = new List<string>();
    
    // input string is bigger than year
    if (seconds >= year)
    {
        resultParts.Add(yearsCount(seconds));
        long _restDays = restDays(seconds);
        resultParts.Add(daysCount(_restDays));
        long _restHours = restHours(_restDays);
        resultParts.Add(hoursCount(_restHours));
        long _restMinutes = restMinutes(_restHours);
        resultParts.Add(minutesCount(_restMinutes));
        long _restSeconds = restSeconds(_restMinutes);
        resultParts.Add(secondsCount(_restSeconds));
    }
    // input string is bigger than day but smaller than year
    if (seconds < year && seconds >= day)
    {
        resultParts.Add(daysCount(seconds));
        long _restHours = restHours(seconds);
        resultParts.Add(hoursCount(_restHours));
        long _restMinutes = restMinutes(_restHours);
        resultParts.Add(minutesCount(_restMinutes));
        long _restSeconds = restSeconds(_restMinutes);
        resultParts.Add(secondsCount(_restSeconds));
    }
    // 59 min 59 sec < input string is < 24 hours
    if (seconds >= hour && seconds < day)
    {
        resultParts.Add(hoursCount(seconds));
        long _restMinutes = restMinutes(seconds);
        resultParts.Add(minutesCount(_restMinutes));
        long _restSeconds = restSeconds(_restMinutes);
        resultParts.Add(secondsCount(_restSeconds));
    }

    if (seconds >= minute && seconds < hour)
    {
        resultParts.Add(minutesCount(seconds));
        long _restSeconds = restSeconds(seconds);
        resultParts.Add(secondsCount(_restSeconds));
    }

    if (resultParts.Count == 1)
    {
        return resultParts[0];
    }
    string result = string.Join(", ", resultParts.GetRange(0, resultParts.Count - 1));
    string last = resultParts[^1]; // Последний элемент
    return $"{result} and {last}";
}
//counting years
string yearsCount(long seconds)
{
    long _yearsCount = seconds / year;
    if (_yearsCount == 1)
    {
        return $"{_yearsCount} year";
    }
    return $"{_yearsCount} years";
}
//counting rest of seconds from yearsCount
long restDays(long seconds)
{
    return seconds - (seconds / year * year);
}
//counting days using number we got in the upper function
string daysCount(long _restDays)
{
    long _daysCount = _restDays / day;
    if (_daysCount == 1)
    {
        return $"{_daysCount} day";
    }
    return $"{_daysCount} days";
}
//counting rest of seconds from yearsCount
long restHours(long seconds)
{
    return seconds - (seconds / day * day);
}
//hms count divided into 3 funcs
string hoursCount(long _restHours)
{
    long _hoursCount = _restHours / hour;
    if (_hoursCount == 1)
    {
        return $"{_hoursCount} hour";
    }
    return $"{_hoursCount} hours";
}

long restMinutes(long seconds)
{
    return seconds - (seconds / hour * hour);
}

string minutesCount(long _restMinutes)
{
    long _minutesCount = _restMinutes / minute;
    if (_minutesCount == 1)
    {
        return $"{_minutesCount} minute";
    }
    return $"{_minutesCount} minutes";
}

long restSeconds(long seconds)
{
    return seconds - (seconds / minute * minute);
}

string secondsCount(long _restSeconds)
{ 
    long _secondsCount = _restSeconds;
    if (_secondsCount == 1)
    {
        return $"{_secondsCount} second";
    }
    return $"{_secondsCount} seconds";
}


/*for (int i = 0; i < int.MaxValue; i+=110000)
{
    Console.WriteLine(formatDuration(i)+"\n");
    Thread.Sleep(10);
    Console.Clear();
}*/

Console.WriteLine(formatDuration(0));
Console.WriteLine(formatDuration(1));
Console.WriteLine(formatDuration(59));
Console.WriteLine(formatDuration(60));
Console.WriteLine(formatDuration(61));
Console.WriteLine(formatDuration(3599));
Console.WriteLine(formatDuration(3600));
Console.WriteLine(formatDuration(3601));
Console.WriteLine(formatDuration(3659));
Console.WriteLine(formatDuration(3660));
Console.WriteLine(formatDuration(3661));



Console.WriteLine(formatDuration(86399));
Console.WriteLine(formatDuration(86400));
Console.WriteLine(formatDuration(86401));
Console.WriteLine(formatDuration(31535999));
Console.WriteLine(formatDuration(31536000));
Console.WriteLine(formatDuration(31536001));


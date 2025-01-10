﻿// sec in a year
const int year = 31536000;
// sec in a day
const int day = 86400;
const int hour = 3600;
const int minute = 60;

string formatDuration(int seconds)
{
    // place to store intermediate result which consist of parts
    var resultParts = new List<string>();
    
    // 0 seconds case
    if (seconds == 0)
    {
        return "now";
    }
    // input string is bigger than year
    if (seconds >= year)
    {
        resultParts.Add(yearsCount(seconds));
        int _restDays = restDays(seconds);
        resultParts.Add(daysCount(_restDays));
        int _restHours = restHours(_restDays);
        TimeSpan timeSpan = TimeSpan.FromSeconds(_restHours);
        resultParts.Add(hoursCount(timeSpan));
        resultParts.Add(minutesCount(timeSpan));
        resultParts.Add(secondsCount(timeSpan));
    }
    // input string is bigger than day but smaller than year
    if (seconds < year && seconds >= day)
    {
        resultParts.Add(daysCount(seconds));
        int _restHoursMinutesSeconds = restHoursMinutesSeconds(seconds);
        TimeSpan timeSpan = TimeSpan.FromSeconds(_restHoursMinutesSeconds);
        if (timeSpan.Hours != 0) { resultParts.Add(hoursCount(timeSpan)); }
        if (timeSpan.Minutes != 0) { resultParts.Add(minutesCount(timeSpan)); }
        if (timeSpan.Seconds != 0) { resultParts.Add(secondsCount(timeSpan)); }
        
    }
    // input string is < 24 hours
    else
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        resultParts.Add(hoursCount(timeSpan));
        resultParts.Add(minutesCount(timeSpan));
        resultParts.Add(secondsCount(timeSpan));
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
string yearsCount(int number)
{
    int _yearsCount = number / year;
    if (_yearsCount == 1)
    {
        return $"{_yearsCount} year";
    }
    return $"{_yearsCount} years";
}
//counting rest of seconds from yearsCount
int restDays(int number)
{
    return number - (number / year);
}
//counting days using number we got in the upper function
string daysCount(int number)
{
    int _daysCount = number / day;
    if (_daysCount == 1)
    {
        return $"{_daysCount} day";
    }
    return $"{_daysCount} days";
}
//counting rest of seconds from yearsCount
int restHours(int number)
{
    return number - (number / 86400);
}
//hms count divided into 3 funcs
string hoursCount(TimeSpan timeSpan)
{
    if (timeSpan.Hours == 1)
    {
        return $"{timeSpan.Hours} hour";
    }
    return $"{timeSpan.Hours} hours";
}

int restMinutes(int number)
{
    return number - (number / 86400);
}

string minutesCount(TimeSpan timeSpan)
{
    if (timeSpan.Minutes == 1)
    {
        return $"{timeSpan.Minutes} minute";
    }
    return $"{timeSpan.Minutes} minutes";
}

int restSeconds(int number)
{
    return number - (number / 86400);
}

string secondsCount(TimeSpan timeSpan)
{ 
    if (timeSpan.Seconds == 1)
    {
        return $"{timeSpan.Seconds} second"; 
    } 
    return $"{timeSpan.Seconds} seconds";
}


/*for (int i = 0; i < int.MaxValue; i+=110000)
{
    Console.WriteLine(formatDuration(i)+"\n");
    Thread.Sleep(10);
    Console.Clear();
}*/

Console.WriteLine(formatDuration(31535998));
Console.WriteLine(1234 % 3);
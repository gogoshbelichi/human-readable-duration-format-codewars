string formatDuration(int seconds)
{
    if (seconds == 0)
    {
        return "now";
    }
    const int year = 31536000;
    const int day = 86400;
    Console.WriteLine(int.MaxValue);
    if (seconds >= year)
    {
        
    }
    if (seconds < year && seconds >= day)
    {
        
    }
    TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
    Console.WriteLine(timeSpan.Hours); 
    return $"Интервал времени: {timeSpan.Hours} hours {timeSpan.Minutes} minutes {timeSpan.Seconds} seconds";
}

int yearsCount(int number)
{
    return number / 31536000;
}

int daysCount(int number)
{
    return number / 86400;
    
}

Console.WriteLine(formatDuration(9));

//31 536 000 seconds in 1 year
//365 days in year
//else is work of TimeSpan
//31 536 000 000 в 1000
//int

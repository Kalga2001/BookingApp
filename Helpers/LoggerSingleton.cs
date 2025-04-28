using System;
using System.IO;

public class LoggerSingleton
{
    private static LoggerSingleton _instance;
    private static readonly object LockObj = new object();
    private readonly string _logFilePath = "bookingLog.txt";

    private LoggerSingleton() { }

    public static LoggerSingleton Instance
    {
        get
        {
            lock (LockObj)
            {
                if (_instance == null)
                {
                    _instance = new LoggerSingleton();
                }
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(_logFilePath, true))
            {
                sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to log: " + ex.Message);
        }
    }
}

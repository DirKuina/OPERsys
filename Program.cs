using System;
using System.IO;
using System.Timers;


public class Test
{
    private static Timer aTimer;
    public static void Main()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 3000;
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();

    }
    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine("Reading data {0}", e.SignalTime);
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            Console.WriteLine("Driver {0}", d.Name);
            Console.WriteLine("  Drive type: {0}", d.DriveType);
            if (d.IsReady == true)
            {
                Console.WriteLine(
                    "  Available space to current user:{0, 15} bytes",
                    d.AvailableFreeSpace);
                Console.WriteLine(
                    "  Total available space:          {0, 15} bytes",
                    d.TotalFreeSpace);

                Console.WriteLine(
                    "  Total size of drive:            {0, 15} bytes ",
                    d.TotalSize);
            }
        }
    }
}

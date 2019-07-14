
using System;
using System.Windows;

namespace GDataYoutube.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                YouTubeHelper.CreateNewPlaylist("_Test", SH.Split("80wu2glhFDU,N5-Ti1qkWNM", ",")).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.WriteLine("App finished its running");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class ProgressBar
{
    public static event Action AnotherSong;
    public static event Action<int> OverallSongs;
    public static event Action WriteProgressBarEnd;
    static int overallSongs = 10;



    public static List<int> GetAllSongFromInternet()
    {
        if(OverallSongs != null)
        {
            OverallSongs(overallSongs);
        }

        return GetAllSongFromInternet(overallSongs);
    }

    private static List<int> GetAllSongFromInternet(int overallSongs)
    {
        for (int i = 0; i < overallSongs; i++)
        {
            AnotherSong();
            Thread.Sleep(100);
        }

        WriteProgressBarEnd();

        return TestData.list04;
    }
}
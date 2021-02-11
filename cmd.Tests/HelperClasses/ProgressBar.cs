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
    static int overallSongs = 1000;



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

        return TestData.list04;
    }
}

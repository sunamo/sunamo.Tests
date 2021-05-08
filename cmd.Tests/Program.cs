using Roslyn;
using sunamo.Helpers.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd.Tests
{
    class Program
    {
        static PercentCalculator pc = null;
        static List<int> allSongs = null;

        static void Main(string[] args)
        {
            CLTests cl = new CLTests();
            cl.ClearCurrentConsoleLineTest();

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static void ProgressBarTests()
        {
            ProgressBar.OverallSongs += ProgressBar_OverallSongs;
            ProgressBar.AnotherSong += ProgressBar_AnotherSong;
            ProgressBar.WriteProgressBarEnd += ProgressBar_WriteProgressBarEnd;

            Action action = GetAllSongsThread;

            #region #1
            //Thread thread = new Thread(new ThreadStart(GetAllSongsThread));

            //thread.Start();
            //thread.Join(); 
            #endregion

            #region #2
            IAsyncResult ar = action.BeginInvoke(null, null);
            //while (!ar.IsCompleted)
            //{
            //    Thread.Sleep(200);
            //}
            ar.AsyncWaitHandle.WaitOne();
            #endregion
        }

        private static void ProgressBar_WriteProgressBarEnd()
        {
            CL.WriteProgressBarEnd();
        }

        static void GetAllSongsThread()
        {
            allSongs = ProgressBar.GetAllSongFromInternet();
        }

        private static void ProgressBar_AnotherSong()
        {
            bool writeProgressItem = true;
            WriteProgressBarArgs e = null;
            if (writeProgressItem)
            {
                e = new WriteProgressBarArgs(true, pc.last, pc._overallSum);
            }
            else
            {
                e = new WriteProgressBarArgs(true);
            }

            // Must be AddOnePercent, not AddOne
            pc.AddOnePercent();
            CL.WriteProgressBar((int)pc.last, e);
        }

        private static void ProgressBar_OverallSongs(int obj)
        {
            pc = new PercentCalculator(obj);
            CL.WriteProgressBar(0);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

public partial class ConccurentTasksThreads
{
    #region #3 CountdownEvent
    [Fact]
    public void CTT_3()
    {
        var numThreads = 10;
        var countdownEvent = new CountdownEvent(numThreads);

        List<int> d = new List<int>();

        // Start workers.
        for (var i = 0; i < numThreads; i++)
        {
            new Thread(delegate ()
            {
                d.Add(i);
                // Signal the CountdownEvent.
                countdownEvent.Signal();
            }).Start();
        }

        //3,3,4,5,6,8,9,10,10,10
        // Wait for workers.
        countdownEvent.Wait();
        Console.WriteLine("Finished.");
    }
    #endregion

    #region #6 Monitor
    /// <summary>
    /// 4,4,4,5,5
    /// </summary>
    [Fact]
    public void CTT_6()
    {
        resultLInt = new List<int>();

        int numThreads = 5;
        int toProcess = numThreads;
        object syncRoot = new object();

        // Start workers.
        for (int i = 0; i < numThreads; i++)
        {
            new Thread(delegate ()
            {
                resultLInt.Add(i);

                // If we're the last thread, signal
                if (Interlocked.Decrement(ref toProcess) == 0)
                {
                    lock (syncRoot)
                    {
                        Monitor.Pulse(syncRoot);
                    }
                }
            }).Start();
        }

        // Wait for workers.
        lock (syncRoot)
        {
            if (toProcess > 0)
            {
                Monitor.Wait(syncRoot);
            }
        }

        Console.WriteLine("Finished.");
    }
    #endregion

    #region #7 ThreadList+Join
    [Fact]
    public void CTT_7()
    {
        StopwatchStatic.Start();

        List<Thread> threadList = new List<Thread>();

        for (int i = 0; i < 5; i++)
        {
            var t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            threadList.Add(t);
            t.Start(i);
        }

        foreach (Thread thread in threadList)
        {
            // Zastaví UI, dokonce s IsBackground
            thread.Join();
        }

        // 530
        var l = StopwatchStatic.StopAndPrintElapsed("overall");
    }

    void ThreadMethod(object i)
    {
        Thread.Sleep(500);
    }
    #endregion


}
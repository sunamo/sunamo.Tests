using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public partial class ConccurentTasksThreads
{
    ConcurrentBag<object> result = null;
    ArrayList resultAl = null;
    List<int> resultLInt = null;

    #region #1 Task.Factory.StartNew+Task.WaitAll - immediately save values to result collection
    /// <summary>
    /// .NET 4.0
    /// </summary>
    [Fact]
    public void CTT_1()
    {
        List<Task> taskList = new List<Task>();
        ConcurrentBag<object> allObjectAttributes = new ConcurrentBag<object>();

        taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.Folder))));
        taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.XMLFile))));
        taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.TextFile))));
        taskList.Add(Task.Factory.StartNew(() => allObjectAttributes.Add(GetObjectAttributes(TreeViewAttrs.Parent))));

        Task.WaitAll(taskList.ToArray());

        // 3,2,4,1
        result = allObjectAttributes;
    }
    #endregion

    #region #2 Task.Factory.StartNew+Task.WaitAll - Create Task[] and then create values
    [Fact]
    /// <summary>
    /// .NET 4.0
    /// Alternative to _1 - use Task.Result once all tasks have completed (thread-safe collection no longer required as only one thread modifies ArrayList)
    /// </summary>
    public void CTT_2()
    {
        Task<object>[] taskList = {
    Task.Factory.StartNew(() => (object)GetObjectAttributes(TreeViewAttrs.Folder)),
    Task.Factory.StartNew(() => (object)GetObjectAttributes(TreeViewAttrs.XMLFile)),
    Task.Factory.StartNew(() => (object)GetObjectAttributes(TreeViewAttrs.TextFile)),
    Task.Factory.StartNew(() => (object)GetObjectAttributes(TreeViewAttrs.Parent))
};

        Task.WaitAll(taskList);

        ArrayList allObjectAttributes = new ArrayList();

        foreach (Task<object> task in taskList)
        {
            allObjectAttributes.Add(task.Result);
        }

        // 1,2,3,4
        resultAl = allObjectAttributes;
    } 
    #endregion

    private object GetObjectAttributes(string tv)
    {
        return tv;
    }

    


    

    #region #5 ManualResetEvent+WaitHandle+Interlocked
    /// <summary>
    /// Similar as CTT_3
    /// 
    /// My preference for this is to handle this via a single WaitHandle, and use Interlocked to avoid locking on a counter:
    /// </summary>
    [Fact]
    public void CTT_5()
    {
        resultLInt = new List<int>();

        int threadCount = 1;
        ManualResetEvent finished = new ManualResetEvent(false);
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Increment(ref threadCount);
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    // do work 

                    resultLInt.Add(i);
                }
                finally
                {
                    if (Interlocked.Decrement(ref threadCount) == 0)
                    {
                        finished.Set();
                    }
                }
            });
        }
        if (Interlocked.Decrement(ref threadCount) == 0)
        {
            finished.Set();
        }
        //5,5,5,5,5
        finished.WaitOne();
    } 
    #endregion

    

    #region #8
    /// <summary>
    /// https://stackoverflow.com/a/24119347
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl?redirectedfrom=MSDN
    /// </summary>
    [Fact]
    public void CTT_8()
    {
        List<Task> taskList = new List<Task>();

        resultLInt = new List<int>();
        // TaskFactory není staic
    //    Task.WaitAll(
    //        TestData.list04
    //.Select(job => TaskFactory.StartNew(() => resultLInt.Add(job)  /*run job*/);)
    //.ToArray()
    //);
    }
    #endregion

    #region #9
    private ManualResetEvent manual = new ManualResetEvent(false);
    /// <summary>
    /// 3,4,4,4
    /// </summary>
    [Fact]
    public void CTT_9()
    {
        StopwatchStatic.Start();

        resultLInt = new List<int>();

        var availPorts = TestData.list04;

        AutoResetEvent[] autos = new AutoResetEvent[availPorts.Count -1];

        manual.Set();

        for (int i = 0; i < availPorts.Count - 1; i++)
        {
            AutoResetEvent Auto = new AutoResetEvent(false);
            autos[i] = Auto;

            Thread t = new Thread(() => lookForValidDev(Auto, (object)availPorts[i]));
            t.Start();//start thread and pass it the port  

        }
        WaitHandle.WaitAll(autos);
        manual.Reset();

        StopwatchStatic.StopAndPrintElapsed(overall);
    }

    void lookForValidDev(AutoResetEvent auto, object obj)
    {
        try
        {
            manual.WaitOne();
            // do something with obj 

            resultLInt.Add((int)obj);
        }
        catch (Exception)
        {

        }
        finally
        {
            auto.Set();
        }


    }
    #endregion

    string overall = "overall";
}
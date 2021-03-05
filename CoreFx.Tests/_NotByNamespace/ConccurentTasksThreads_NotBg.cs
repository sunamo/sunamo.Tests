using System;
using System.Collections.Generic;
using System.Text;

public partial class ConccurentTasksThreads
{
    #region 4# Parallel.ForEach
    /// <summary>
    /// Perfect and simple
    /// 
    /// </summary>
    [Fact]
    public void CTT_4()
    {
        resultLInt = new List<int>();

        StopwatchStatic.Start();

        Parallel.ForEach(TestData.list04, curJob =>
        {
            Thread.Sleep(500);
            resultLInt.Add(curJob);
        });

        //2,1,0,4,3
        // Nejjednodušší
        // 557
        var l = StopwatchStatic.StopAndPrintElapsed("overall");
    }
    #endregion


}

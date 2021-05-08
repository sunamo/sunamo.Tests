using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ExcTests
{
    [Fact]
    public void CallingMethodTest()
    {
        /*
2 - InvokeMethod
1 - CallingMethodTest
0 - CallingMethod
         */
        var cm0 = Exc.CallingMethod(0);

        Init1();

        Exc._trimTestOnEnd = false;
        var cm = Exc.CallingMethod();
        Exc._trimTestOnEnd = true;

        var cm2 = Exc.CallingMethod(2);

        Assert.Equal("", cm);
    }

    //void Do()
    //{
    //    Init
    //}

    void Init1()
    {
        Init2();
    }

    void Init2()
    {
        Exc._trimTestOnEnd = false;

        //Init1();
        var cm0 = Exc.CallingMethod(0);
        Exc._trimTestOnEnd = false;
        var cm = Exc.CallingMethod();
        Exc._trimTestOnEnd = true;

        var cm2 = Exc.CallingMethod(2);

        Exc._trimTestOnEnd = true;
    }
}

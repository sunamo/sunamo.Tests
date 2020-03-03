using System;
using System.Collections.Generic;
using System.Text;


public class DataClass
{
    public string variable = null;

    public string Property
    {
        get
        {
            return variable + "2";
        }
    }
}
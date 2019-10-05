using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Roslyn;
using Xunit;

public class RoslynHelperTests
{
    /// <summary>
    /// better is use d:\pa\CodeFormatter\ with lang attr
    /// </summary>
    [Fact]
    public void FormatTest()
    {
        string input = @"    public partial class InsertIntoXlfAndConstantCsUC : UserControl, IUserControl, IKeysHandler<KeyEventArgs>, IUserControlWithSettingsManager, IUserControlWithMenuItemsList, IWindowOpener, IUserControlWithSizeChange
    {
        #region Class data
        static InsertIntoXlfAndConstantCsUC instance = null;
#endregion
}";



        var s = RoslynHelper.Format(input);
        Debug.WriteLine(s);
    }

    
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using sunamo.Constants;
using sunamo.Essential;
using sunamo.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using win.Helpers.Powershell;

namespace win.Tests.Helpers.Powershell
{
    /// <summary>
    /// Must be from template Unit Tests which is only which use classic .NET. 
    /// </summary>
    [TestClass]
    public class PowershellRunnerTests
    {
        [TestMethod]
        public void InvokeTest()
        {
            var result = Invoke();
            Assert.AreEqual(2, result.Count);
            // First is from cd - empty strings
            Assert.AreEqual(exceptedPath, result[1][0]);
        }

        [TestMethod]
        public void InvokeAsyncTests()
        {
            const string excepted = "s";
            var resultTask = InvokeAsync();
            resultTask.Wait();
            var result = resultTask.Result;
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(excepted, result[0][0]);
            Assert.AreEqual(excepted, result[1][0]);
        }

        string usedCommand = "";
        const string exceptedPath = "D:\\Documents\\vs\\Projects\\sunamo.Tests\\win.Tests";
        const string cd = "cd \""+exceptedPath+AllStrings.qm;
        const string appendToFile = "Out-File -Append -Literal-Path ";
        const string getActualFolder = "(Get-Item -Path \".\\\").FullName";
        const string getClipboard = "Get-Clipboard";
        string waitCommand = "Start-sleep -Milliseconds 1000";
        string echoCommand = "echo s";
        int miliseconds = 1000;

        /// <summary>
        /// Path should be in full path, Path is not supported here
        /// </summary>
        string oneSecWaitApp = @"d:\pa\_sunamo\SleepWithRandomOutputConsole.exe";

        public PowershellRunnerTests()
        {
            usedCommand = echoCommand;
        }

        [TestMethod]
        public void TryMagickTest()
        {
            //exceptedPath = DefaultPaths.Downloads;
            var listCmd = CA.ToListString("cd " + DefaultPaths.Downloads, "magick Ostman.webp Ostman.jpg");
            PowershellRunner.Invoke(listCmd);
        }

        private List<List<string>> Invoke()
        {
            List<List<string>> result = new List<List<string>>();
            int repeat = 2;
            int maxMs = repeat * miliseconds;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var listCmd = CA.ToListString(cd, getActualFolder);
                var list = PowershellRunner.Invoke(listCmd);

                foreach (var item in list)
                {
                    result.Add(item);
                }
            
            /*
             * 1 - 
             * 3 - 3514
             */
            stopwatch.Stop();
            //DebugLogger.Instance.WriteLine("max", maxMs);
            //DebugLogger.Instance.WriteLine("elapsed", stopwatch.ElapsedMilliseconds);

            return result;
        }

        public async Task<List<List<string>>> InvokeAsync()
        {
            List < List<string>> result = null;
            int repeat = 2;
            int maxMs = repeat * miliseconds;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> commands = new List<string>();

            for (int i = 0; i < repeat; i++)
            {
                commands.Add(usedCommand);
                // vzdycky vrati vysledky jen 1, at volam skript treba 9x
            }
            result = await PowershellRunner.InvokeAsync(commands.ToArray());
            /*
             * 1 - 1479
             * 3 - 3495
             */
            stopwatch.Stop();
            //DebugLogger.Instance.WriteLine("max", maxMs);
            //DebugLogger.Instance.WriteLine("elapsed", stopwatch.ElapsedMilliseconds);

            return result;
        }
    }
}
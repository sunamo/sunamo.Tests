using System;
using System.Collections.Generic;
using System.Text;
namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncVoid
    {
static Type type = typeof(AsyncVoid);
        private async void ThrowExceptionAsync()
        {
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),InvalidOperationException();
        }
        public void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception ex)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}

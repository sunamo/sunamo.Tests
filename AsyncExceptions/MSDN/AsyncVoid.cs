
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
        private async void ThrowExceptionAsync()
        {
            throw new InvalidOperationException();
        }
        public void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}

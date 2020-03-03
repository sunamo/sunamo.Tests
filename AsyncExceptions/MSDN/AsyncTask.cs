using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncTask
    {
        private async Task ThrowExceptionAsync()
        {
            await Task.Delay(1);
            // Stop working whole app
            throw new InvalidOperationException();
        }
        public async void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (Exception ex)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}
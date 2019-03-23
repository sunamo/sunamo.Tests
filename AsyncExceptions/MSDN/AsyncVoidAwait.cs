
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncVoidAwait
    {
        /// <summary>
        /// To že je metoda async nevadí, vadí await
        /// </summary>
        private async void ThrowExceptionAsync()
        {
            await Task.Delay(1);
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

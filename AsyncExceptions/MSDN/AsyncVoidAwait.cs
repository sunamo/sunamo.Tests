using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunamoExceptions;

namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncVoidAwait
    {
static Type type = typeof(AsyncVoidAwait);
        /// <summary>
        /// To že je metoda async nevadí, vadí await
        /// </summary>
        private async void ThrowExceptionAsync()
        {
            await Task.Delay(1);
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(), "");
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
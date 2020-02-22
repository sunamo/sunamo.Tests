using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExceptions
{
    class S041815236
    {
        /// <summary>
        /// Can return Task or void, be async or anything else, have await... 
        /// But is have ContinueWith() throw exceptions on place of occuring
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async static Task Run(List<string> args)
        {
            await TestTaskAsyncInLambdaAsync().ContinueWith(t =>
            {
                Debug.WriteLine(t.Exception.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            //Debug.ReadKey();
        }

        static async Task<IEnumerable<string>> TestTaskAsyncInLambdaAsync()
        {
            IEnumerable<string> list = null;

            try
            {
                list = await TestTaskAsyncInLambda();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught!");
            }

            Debug.WriteLine("Caller");

            if (list == null)
            {
                return new List<string>();
            }

            return list;
        }

        static async Task<IEnumerable<string>> TestTaskAsyncInLambda()
        {
            var task = new Task<IEnumerable<string>>( () =>
            {
                // 
                //return null;
                //Task.Delay(1500).ConfigureAwait(false);
                throw new AggregateException("This is a test");
            });

            //WPF: If will be here, task never start(Start() method is below) and whole app closes
            //throw new AggregateException("This is a test");

            task.Start();

            await Task.Delay(1500);
            var result = await task;
            
            //throw new AggregateException("This is a test");
            return result;
        }

        //KO
        static async Task<IEnumerable<string>> TestTaskAsync()
        {
            IEnumerable<string> list = null;

            try
            {
                list = await TestTaskAsyncInLambda();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught!");
            }

            Debug.WriteLine("Caller");

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static Task<IEnumerable<string>> TestTask()
        {
            var task = new Task<IEnumerable<string>>(() =>
            {
                throw new AggregateException("This is a test");
            });

            task.Start();

            Task.Delay(1000);

            return task;
        }
    }
}

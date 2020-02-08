using System;
using System.Threading.Tasks;

namespace Async_Await
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Action
            Task.Run(async () => {

                // Async n Await same as Multithreading, But Multithreading cannot pass paramter from one thread to another
                // Async n Await can pass paramter to one thread to another.
                // Async Assign function to Task
                // Task run Function on new thread
                // Await pass the parameter between threads

                AsyncDemo obj = new AsyncDemo();
                int result = await obj.Function1(); 
                result = await obj.Function2(result); 
                result = await obj.Function3(result); 

                Console.WriteLine(result);
                Console.ReadLine();



            }).Wait();
        }
    }

    public class AsyncDemo
    {
        // Runs on Thread T1
        public async Task<int> Function1()
        {
            // Await pass the parameters from one thread to another
            return await Task.Run(() =>
            {

                return 10;

            });
        }

        // Runs on Thread T2
        public async Task<int> Function2(int func1value)
        {
            // Await pass the parameters from one thread to another
            return await Task.Run(() =>
            {

                return func1value + 10;

            });
        }

        // Runs on Thread T3
        public async Task<int> Function3( int func2value)
        {
            // Await pass the parameters from one thread to another
            return await Task.Run(() =>
            {

                return func2value+ 10;

            });
        }
    }
}

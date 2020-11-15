using client.evl.watch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.evl.watch
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.Read();

        }

        private static async void Test()
        {
            var client = new client.evl.watch.Client();

            Console.WriteLine($"Checking if API is Online... {DateTimeOffset.Now}\n");


            var online = await client.IsApiOnline();

            if ( !online )
            {
                Console.WriteLine("No heartbeats! Closing...\n");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine($"API Online! {DateTimeOffset.Now}\n");

            try
            {
                Console.WriteLine("──────────────────────────────────────────");

                Console.WriteLine($"Testing /v1/user/register route! {DateTimeOffset.Now}\n");


                var register = await client.Register(new User()
                {
                    Email = "info@1223222333.it",
                    Password = "1234",
                    Username = "1111"
                });

                Console.WriteLine($"Response Time: {register.ResponseDateTime}\nResponse Message: {register.Data}\n");

            }
            catch ( ApiException ex)
            {
                Console.WriteLine($"Error: {ex.Data.ErrorMessage}\nResponseID: {ex.ResponseID}\nErrorCode: {ex.Data.ErrorCode}\nResponse Time: {ex.ResponseDateTime}\n");
            }
            catch (Exception ex )
            {
                Console.WriteLine($"Unhandled Exception: {ex.Message}\n");
            }

            Console.WriteLine("──────────────────────────────────────────");

        }
    }
}

using System.Configuration;
using System.Security.Cryptography;

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] _) 
        {
            string s = ConfigurationManager.AppSettings["CoreAppSettings"] ?? "Not Found";
            Console.WriteLine($"CoreAppSettings: {s}");
            Console.WriteLine(typeof(Program).Assembly.GetName().Name); 
            /* 
            string DBConnectionString;
            try
            {
                DBConnectionString = ConfigValidation.ValidateAndGetConnectionString(); 
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine($"Configuration Error: {e.Message}");
                throw; 
            }
            Console.WriteLine($"DB Connection String: {DBConnectionString}");*/
            //Console.WriteLine("Hello, World!");
        }
    }   
}

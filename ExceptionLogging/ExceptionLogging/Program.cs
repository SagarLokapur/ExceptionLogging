using System;
using System.IO;
using Utility;

namespace ExceptionLogging
{
    class Program
    {

        static void Main(string[] args)
        {
            ILog log = Logging.GetInstance;
            try
            {
                //This is the example taken to throw the DevideByZero Exception
                float result = Devide(20, 0);

                //This is the example taken to throw the FileNotFoundException Exception
                string allText = File.ReadAllText("Test.txt");
            }
            catch (FileNotFoundException ex)
            {
                log.WriteErrorToFile(ex.Message);
                log.WriteErrorToFile(ex.StackTrace);
            }
            catch (Exception ex)
            {
                log.WriteErrorToFile(ex.Message);
                log.WriteErrorToFile(ex.StackTrace);
            }

        }
        private static float Devide(int num1, int num2)
        {
            ILog log = Logging.GetInstance;
            try
            {
                return num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                log.WriteErrorToFile(ex.Message);
                log.WriteErrorToFile(ex.StackTrace);
                return 0;
            }
            catch (Exception ex)
            {
                log.WriteErrorToFile(ex.Message);
                log.WriteErrorToFile(ex.StackTrace);
                return 0;
            }
        }
    }
}

using System;
using System.IO;

namespace Utility
{
    //Created a Singleton class to restrict multiple objects Creation
    public sealed class Logging : ILog
    {
        private static Logging logging = null;
        public static readonly object obj = new object();
        public static Logging GetInstance
        {
            get
            {
                lock (obj)
                {
                    if (logging == null)
                    {
                        logging = new Logging();
                    }
                }
                return logging;
            }
        }
        private Logging()
        {

        }
        public void WriteErrorToDB(string info)
        {
            //Writing to DB Implimentation is not done
        }
        public void WriteErrorToFile(string info)
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs.txt");
            if (File.Exists(destPath))
            {
                File.AppendAllText(destPath, $"{Environment.NewLine}{DateTime.Now.ToString()} : {info}");
            }
            else
            {
                File.WriteAllText(destPath, $"{DateTime.Now.ToString()} : {info}");
            }

        }
    }
}

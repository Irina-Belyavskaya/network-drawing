using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT
{
    public class Log
    {
        private Log() { }

        private static Log _instance;

        public static Log GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Log();
            }
            return _instance;
        }

        public void WriteInLog (string message, string userName)
        {
            using (StreamWriter f = new StreamWriter(userName + "-log.txt", true))
            {
                f.WriteLine(message);
            }
        }
    }
}

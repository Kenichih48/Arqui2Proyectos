using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Proyecto1
{
    public class LoggerT
    {
        private static LoggerT? instance;

        public static string filename;

        private static int req;

        private LoggerT()
        {
            // Initialization code, if needed
            
        }

        // Public static method to get the single instance of the class
        public static LoggerT GetInstance()
        {
                // Lazy initialization: create the instance if it doesn't exist yet
                if (instance == null)
                {
                    instance = new LoggerT();
                }
                return instance;
            
        }
        public static void Start()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "results");
            DateTime now = DateTime.Now;
            int lengthToKeep = dir.Length - 49;
            string result = dir.Substring(0, lengthToKeep);
            filename = result + "\\Proyecto1\\results\\" + now.Hour.ToString() +"-"+ now.Minute.ToString() + "-" + now.Second.ToString() + ".log";

            using (FileStream fs = File.Create(filename))


            Console.WriteLine(filename);
            req = 0;
        }

        public static void Write2File(string msg)
        {
            try
            {
                // Abre el archivo en modo de escritura, con la opción de agregar al final
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    // Escribe el texto en el archivo
                    writer.WriteLine(msg);
                }

                Console.WriteLine("Texto agregado exitosamente al archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public static void LogReadReq(int idcache,int addr)
        {
            //Append message in file.
            string message = "["+req.ToString()+ "] " +" Read Req in cache #"+idcache.ToString()+" to address " + addr.ToString();
            req += 1;
            Write2File(message);
        }

        



    }
}

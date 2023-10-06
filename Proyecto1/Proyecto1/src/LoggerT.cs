using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Proyecto1
{
    public class LoggerT
    {
        private static LoggerT? instance;

        public static string filename;
        public static string directory;

        private static int req;

        private static int ReadReq;
        private static int WriteReq;
        private static int InvReq;
        private static int MemWReq;
        private static int MemRReq;

        private static bool begin;

        private LoggerT()
        {
            // Initialization code, if needed
            begin = false;
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
            begin = true;
            ReadReq = 0;
            WriteReq = 0;
            InvReq = 0;
            req = 0;

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "results");
            DateTime now = DateTime.Now;
            string[] partes = dir.Split(new string[] { "\\" }, StringSplitOptions.None);
            int nuevaLongitud = partes.Length - 5;
            Array.Resize(ref partes, nuevaLongitud);
            string result = string.Join("\\", partes);
            directory = result + "\\Proyecto1\\results\\" + now.Hour.ToString() + "-" + now.Minute.ToString() + "-" + now.Second.ToString();
            filename = directory + ".log";

            using (FileStream fs = File.Create(filename))


            
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

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public static void LogReadReq(int idcache,int addr)
        {
            if (begin)
            {
                //Append message in file.
                string message = "[" + req.ToString() + "] " + "  Read Req in cache #" + idcache.ToString() + " to address " + addr.ToString();
                req += 1;
                ReadReq += 1;
                Write2File(message);
            }
            
        }

        public static void LogWriteReq(int idcache,int addr)
        {
            if (begin)
            {
                //Append message in file.
                string message = "[" + req.ToString() + "] " + " Write Req in cache #" + idcache.ToString() + " to address " + addr.ToString();
                req += 1;
                WriteReq += 1;
                Write2File(message);
            }
            
        }

        public static void LogInvReq(int idcache, int addr)
        {
            if (begin)
            {
                //Append message in file.
                string message = "[" + req.ToString() + "] " + " Invalidation in cache #" + idcache.ToString() + " to address " + addr.ToString();
                req += 1;
                InvReq += 1;
                Write2File(message);
            }
            
        }


        public static void LogMemReq(int addr)
        {
            if (begin)
            {
                //Append message in file.
                string message = "[" + req.ToString() + "] " + " Memory Write Req to address " + addr.ToString();
                req += 1;
                MemWReq += 1;
                Write2File(message);
            }

        }

        public static void LogMemRReq(int addr)
        {
            if (begin)
            {
                //Append message in file.
                string message = "[" + req.ToString() + "] " + " Memory Read Req to address " + addr.ToString();
                req += 1;
                MemRReq += 1;
                Write2File(message);
            }

        }

        public static void FinishLog()
        {
            if(begin)
            {
                string ReadReport = "# of Read Requests: " + ReadReq.ToString();
                string WriteReport = "# of Write Requests: " + WriteReq.ToString();
                string InvReport = "# of Invalid Requests: " + InvReq.ToString();
                string MemWReport = "# of Memory Write Requests: " + MemWReq.ToString();
                string MemRReport = "# of Memory Read Requests: " + MemRReq.ToString();

                Write2File(ReadReport);
                Write2File(WriteReport);
                Write2File(InvReport);
                Write2File(MemWReport);
                Write2File(MemRReport);
                begin = false;
            }
            
        }

        public static void GenerateChart()
        {
            Chart chart = new Chart();
            chart.Size = new Size(400, 300); // Tamaño del gráfico

            // Configurar el área del gráfico
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Agregar datos a la serie de barras
            Series series = new Series();
            series.Points.AddXY("Read Req.", ReadReq);
            series.Points.AddXY("Write Req.", WriteReq);
            series.Points.AddXY("Inv", InvReq);
            series.Points.AddXY("Memory Write", MemWReq);
            series.Points.AddXY("Memory Read", MemRReq);
            chart.Series.Add(series);

            // Guardar la gráfica como una imagen\
            

            chart.SaveImage(directory + ".png", ChartImageFormat.Png);
            

            // Dispose del objeto Chart
            chart.Dispose();

           
        }

        



    }
}

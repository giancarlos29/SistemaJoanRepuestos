using System;
using System.IO;


namespace CapaDatos
{
    public static class loggeator
    {
        public static void EscribeEnArchivo(string contenido)
        {
            using (StreamWriter w = File.AppendText("C:\\SistemaRepuestosJoan\\Logs\\Logs.txt"))
            {
                Log(contenido, w);
            }

            using (StreamReader r = File.OpenText("C:\\SistemaRepuestosJoan\\Logs\\Logs.txt"))
            {
                DumpLog(r);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}


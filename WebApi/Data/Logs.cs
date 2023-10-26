using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace WebApi.Data
{
    public class Logs
    {
        public void GenraLogs()
        {

            //estado result = new estado();
            bool result = estado.valestado;
            string error = estado.valerror;

            //String path = "C:\\Users\\Raul\\Desktop\\MSCLOUDEXPERTS\\Logs\\Logs.txt";
            string path = ConfigurationManager.AppSettings["RutaLogs"];
            try
            {
                if (!File.Exists(path))
                {
                    // Create the file, or overwrite if the file exists.    
                    using (FileStream fs = File.Create(path))
                    {


                        if (result)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes("Intento  registrado Exitosamente");
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                        }
                        else
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes("Error al momento de registrar al Intento");
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                        }

                    
                    }

                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }

                else
                {

                    if (result)
                    {
                        File.AppendAllText(path, "Proceso ejecutado Exitosamente: " + DateTime.Now.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(path, "Error al momento de ejecutar el Proceso:  " +  error  + DateTime.Now.ToString() + Environment.NewLine);
                    }

            
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



    }
}
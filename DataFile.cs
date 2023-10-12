using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMathLab2
{
    internal class DataFile
    {
        public static void PrintFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                String line = sr.ReadLine();
                while (line != null)
                {

                    Console.WriteLine(line);

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
        
        public static string[] OutPutFile(string filename)
        {
            string[] result = null;
            try
            {
                StreamReader sr = new StreamReader(filename);
                List<string> rows = new List<string>();

                string line = sr.ReadLine();
                while (line != null)
                {
                    rows.Add(line);
                    line = sr.ReadLine();
                }

                result = new string[rows.Count];
                rows.CopyTo(result);

                sr.Close();
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
           
        }

    }
}

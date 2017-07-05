using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateKey
{
    public class Dossier
    {
        private string FilePath { get; set; }
        public FileStream file { get; set; }
        public StreamWriter fileWrite { get; set; }
        DateTime time;
        public Dossier()
        {
           
        }

        #region Write to file all random key in hex format 
        public bool writeToFile(string[] hexDecimals, int countDay,string [] randomKey)
        {
            bool state = true;
            try
            {
                EditFilePath();
               this.file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
               this.fileWrite = new StreamWriter(file);
               this.time = DateTime.Today;
               
                for (int i = 0; i < countDay; i++)
                {
                    fileWrite.WriteLine(time.ToShortDateString() + "  " + (i + 1) + ".Key: " + hexDecimals[i]);
                    time = time.AddDays(1);
                }
               
            }
            catch (Exception ex)
            {
                ex.ToString();
                state = false;
                 
            }
            finally
            {
                fileWrite.Flush();
                fileWrite.Close();
                fileWrite.Close();
                if (state == false)
                {
                    if (File.Exists(this.FilePath))
                        File.Delete(this.FilePath);
                }
               
            }
            return state;
        }
        #endregion

        private void EditFilePath()
        {
            //get document path in pc
            CultureInfo info = CultureInfo.CurrentUICulture;
            string path;
            //if (info.Name == "en-US")
            //    path = @"C:/Documents";
            //else if (info.Name == "tr-TR")
            //    path = @"C:/Belgelerim";
            //else
                path = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            
            //if dont have EncryKey folder, its creates a EncryKey 
            if (!Directory.Exists(path + @"\EncKey"))
                Directory.CreateDirectory(path + @"\EncKey");
            //created date of file 
            time = DateTime.Now;
            //set document path and name
            this.FilePath = path + @"\EncKey\EncKey_" + time.ToShortDateString() + "_" + time.ToLongTimeString().ToString().Replace(":", "") + ".txt";

        }

        public string getFilePath()
        {
            return this.FilePath;
        }

    }
}

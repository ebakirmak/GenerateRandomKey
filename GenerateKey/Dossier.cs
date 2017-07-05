using System;
using System.Collections.Generic;
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
            this.FilePath = "";

        }

        #region Write to file all random key in hex format 
        public bool writeToFile(string[] hexDecimals, int countDay,string [] randomKey)
        {
            bool state = true;
            try
            {
               this.file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
               this.fileWrite = new StreamWriter(file);
               this.time = DateTime.Today;
               
                for (int i = 0; i < countDay; i++)
                {
                    fileWrite.WriteLine(time.ToShortDateString() + "  " + (i + 1) + ".Key: " + hexDecimals[i] + "   Random Key: " + randomKey[i]);
                    time = time.AddDays(1);
                }
                object m = null;
                string s = m.ToString();
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

        #region Set FilePath value
        public bool setFilePath (string filePath)
        {
            
            try
            {
                if (filePath.Length > 0)
                {
                    this.FilePath = filePath;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region Folder Browse Dialog
        public string ChooseLocation()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
        
            if (fbd.ShowDialog() == DialogResult.OK) { 
           this.FilePath = fbd.SelectedPath+"\\Keys.txt";
                return FilePath;
            }
            else
            {
                return "-1";
            }
         
        }
        #endregion
    }
}

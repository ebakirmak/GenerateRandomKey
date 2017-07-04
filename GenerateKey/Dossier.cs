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

        public Dossier()
        {        
            this.FilePath = "";
        }

        #region Write to file all random key in hex format 
        public void writeToFile(string[] hexDecimals, int countDay,string [] randomKey)
        {

        
            FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            DateTime today = DateTime.Today;

            for (int i = 0; i < countDay; i++)
            {
                sw.WriteLine(today.ToShortDateString() + "  " + (i + 1) + ".Key: " + hexDecimals[i] + "   Random Key: " + randomKey[i]);
                today = today.AddDays(1);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
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
           this.FilePath = fbd.SelectedPath+"\\HexKeys.txt";
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

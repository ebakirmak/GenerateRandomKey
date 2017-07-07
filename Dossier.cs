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
        private string fileName { get; set; }                        
        public FileStream file { get; set; }                         
        public StreamWriter fileWrite { get; set; }                  
        DateTime time;                                               
        public Dossier()                            
        {
           
        }

        #region Write to file all random key in hex format 
        public bool WriteToFile(string[] hexDecimals, int countDay,string [] randomKey,DateTime startTime)
        {
            bool state = true;
            try                                                                                                      //Dosya yazmada sorun yaşanabilir bu yüzden try catch yapısını kullanıyoruz.
            {
                EditFilePath();                                                                                     
                this.file = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);                        //FileStream sınıfının cons. parametreleri ile oluşturduğumuz file nesnesinin özelliklerini belirliyoruz.
                this.fileWrite = new StreamWriter(file);                                                            //oluşturduğumuz file nesenesinin streamwriter ile yazdıyoruz (reel olarak oluşturmuş oluyoruz.).
                time = startTime;                                                                                  //

                for (int i = 0; i < countDay; i++)
                {
                    fileWrite.WriteLine(time.ToShortDateString() + "\t" + hexDecimals[i]/* +"\t"+ randomKey[i]*/);      //yarattığımız dosyanın(.txt'nin) İÇİNE istenilen textleri yazıyoruz
                    time = time.AddDays(1);                                                                         //Günün herseferinde 1 artması için AddDays fonksiyonunu kullanıyoruz
                }
               
            }
            catch (Exception ex)
            {
                ex.ToString();
                state = false;                                                                                     //Bir hata meydana gelirse bu hatayı kullanıcıya bildirmek için Catch içinde bir bool değişkeni tutuyoruz.
                 
            }
            finally
            {
                fileWrite.Flush();
                fileWrite.Close();
                fileWrite.Close();
                if (state == false)                                                                                 // Eğer dosyaya yazma sırasında bir hata oluşmuşsa(state == false)
                {
                    if (File.Exists(this.fileName))                                                                 //Ve bu dosya oluşturulmuşsa                                             
                        File.Delete(this.fileName);                                                                 //Bu hatalı oluşan dosyayı sil!
                }
               
            }
            return state;
        }
        #endregion

        #region File Path Edit
        private void EditFilePath ()                                                                           //Key.txt'yi içine atacağımız klasörü oluşturuyoruz(eğer yoksa) ve fileName'i tanımlıyoruz  
        {
           string path;
            path = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");       //!!Bu kod sayesinde belgerimin yolunu değişkene atıyoruz.
            
            
            if (!Directory.Exists(path + @"\EncKey"))                                                        //Eğer bu yolda EncKey adında bir dosya yoksa !
                Directory.CreateDirectory(path + @"\EncKey");                                                //Bu yolda EncKey adlı dosya oluştur
             
            time = DateTime.Now;                                                                             //Şuanın tarihini al.(Dosya isminde kullanılacağı için)
           
            this.fileName = path + @"\EncKey\EncKey_" + time.ToShortDateString() + "_" + time.ToLongTimeString().ToString().Replace(":", "") + ".txt";   //Dosya ismini istenilen biçimde oluşturuoyuz.

        }
        #endregion

        #region Get File Name               
        public string getFilePath()                                                                                 //Dosyanın adını döndüren fonksiyon
        {
            return this.fileName;
        }
        #endregion

    }
}

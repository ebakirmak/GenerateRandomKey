using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateKey
{
    public partial class frmKeyGenerate : Form
    {
        public frmKeyGenerate()                                                                
        {
            InitializeComponent();                                                              
            dosya = new Dossier();
            controllerList = new List<Control>();
            
        }
        private string[] randomKey;                                                              //Decimal cinsinden sayıların tutulacağı dizi. 
        private string []  hexDecimals;                                                          //Hex cinsinden sayıların tutulacağı dizi.
        public Dossier dosya { get; set; }                                                       //Dosyalama işlemleri için oluşturulan sınıfın nesnesi.
        private bool state = false;                                                              //Durum değişkeni.
        private DateTime dateStart;                                                              //Başlangıç ve bitiş tarihleri.
        private DateTime dateEnd;
        List<Control> controllerList;                                                            //Form içindeki kontrollerın(Form elemanlarının) tutulduğu liste.
                                                                     
        

        #region Event: Button(Generate) - Click
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblLink.Text = "";
            lblError.Text = "";

            int dayCount = 0;                                                                     //Oluşturulacak keylerin gün sayısı
            int KeyLength = 0;                                                                    //Oluşturulacak Keylerin bit uzunluğu

            dateStart = dtpStart.Value.Date;                                                      //Date Time Picker'daki tarih başlangıcını dateStart nesnesine atıyoruz            
            dateEnd = dtpEnd.Value.Date;                                                          //Tarih bitişini dateEnd nesnesine atıyoruz         


            dayCount = ControlKeyCount(dateStart, dateEnd);                                       //Fonksiyon ile seçilen tarihler aradaki gün farkını değişkene atıyoruz.

            randomKey = new string[dayCount];                                                     //Decimal cinsinden tutulacak olan random key dizisi. 
            hexDecimals = new string[dayCount];                                                   //Hex cinsine dönüştürülen keylerin tutulacağı dizi. 

                   
            KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);                         //Keylength'deki seçilen ifadeden (örn:128 bit) boşluktan sonrasını atıp int cinsine çevirek değişkene atıyoruz.
            randomKey = GenerateRandomKey(KeyLength, dayCount);                                   //Üretilen random keyleri randomKey Dizisine atıyoruz.
            if (dosya.WriteToFile(hexDecimals, dayCount, randomKey,dateStart) == true)            //Dosyaya yazma fonksiyonunu doğruysa zaten o fonksiyon çalıştığı için dosyaya yazacaktır. aşağıda birdaha yazma fonsiyonunu çağırarak yazdırmamıza gerek yok!
                state = true;
                     
 
                if (state == true)
                {
                    lblError.ForeColor = Color.Black;                                             //Ekranda görünecek olan textin rengini belirliyoruz.            
                    lblError.Text = "Processing. Please wait...";                                
                    Thread threadWait = new Thread(new ThreadStart(Wait));                        //Sistemi 1sn bekletiyoruz thread kullanarak (Hızlı çalıştığından Processing... yazısını görebilmek için.)
                    threadWait.Start();
                    threadWait.Join();
                    lblError.ForeColor = Color.Green;                                   
                    lblError.Text = "Encryption Keys are generated successfully.";

                                                                                                  //LabelLinkte Dosya yolunu DEĞİL Klasörün yolu gözükeceği için ve dosy.getFilePath bize DOSYANIN yolunu verdiği için Dosya yolunun son kısmını silmemiz gerekiyor(..34.txt kısmını). Bunun için aşağıdaki adımları izliyoruz.
                    int splitPosition = dosya.getFilePath().LastIndexOf("EncKey");                //Dosya yolu olan .../EncKey/EncKey_21... deki İLK EncKey'den sonrasının index numarasını atıyoruz.
                    string a;                                                                     //Belirlediğimiz index numarasından sonraki kısmı(2.EncKeyden sonrası) atayacağımız değişken.(EncKey_212323.....)
                    if (splitPosition != -1)                                                      //Kontrol: Öyle bir pozisyon yok değilse.
                    {
                        a = dosya.getFilePath().Substring(splitPosition);                         //Substring Kullanarak aldığımız index numarasından sonraki kısmı a değişkenine atıyoruz(EncKey_2312312...).
                        lblLink.Text = dosya.getFilePath().Replace(a, "");                        //2.EncKey ve sonrasını silerek("" ile yer değiştirerek) LabelLinke Klasörün yolunu vermiş oluyoruz
                        state = false;

                    }
                    else                                                                         //Öyle bir pozisyon(-1) varsa hata mesajı döndürüyoruz.
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Error. Keys are not generated !";
                    }

                }
            }
        #endregion

        #region Generate Random Key

        private string[] GenerateRandomKey(int keyLength,int countDay)                           //key uzunluğu ve gün sayısını (param.) alıyoruz.
        {
            Random random = new Random();                                           
            string[] randomKeys = new string[countDay];                                          //Decimal cinsinden random keylerin saklanacağı dizi.

            for (int i = 0; i < countDay; i++)                                                   //Gün sayısı kadar.
            {
                string currentKey = "";                                                          //string cinsinden tanımlıyoruz.
                string currentHex = ""; 
                for (int j = 0; j < keyLength / 8; j++)
                {
                    int rInt = random.Next(0, 255);                                              //0-255 arasında random sayı üretiyoruz.
                    currentKey += rInt+"-";                                             
                    if(rInt<16)
                        currentHex += "0"+rInt.ToString("X");                                    //ürettiğimiz random sayıyı ToString fonk.unu kullanarak hex tipine dönüştürerek currentHex değişkenine atıyoruz.
                    else
                        currentHex += rInt.ToString("X");                           
                }
                randomKeys[i] = currentKey;                                                      //Decimal cinsinden üretilen random keyleri diziye atıyoruz.
                hexDecimals[i] = currentHex;                                                     //Hex cinsine dönüştürülmüş keyleri diziye atıyoruz. 
               
            }
            return randomKeys;                                                                   //randomKey'lerin tutulduğu Diziyi dödürüyoruz.
          
        }
        #endregion

        #region Change Combobox Object
        private void rdoAES_CheckedChanged(object sender, EventArgs e)              //Radio Butonların Check'leri değiştiğinde Combo Boxların içindeki itemları değiştiren fonk. 
        {  if (rdoAES.Checked == true)
            {
                cmbKeyLength.Items.Clear();
                cmbKeyLength.Items.Add("128 Bit");
                cmbKeyLength.Items.Add("192 Bit");
                cmbKeyLength.Items.Add("256 Bit");
               
            }
            else if (rdoBlowFish.Checked == true)
            {
                cmbKeyLength.Items.Clear();
                for (int i = 32; i <= 448; i += 8)
                {
                    cmbKeyLength.Items.Add(i + " Bit");
                }
               
            }
            cmbKeyLength.Text = cmbKeyLength.Items[0].ToString();
        }
        #endregion

        #region Clear Labels Text
        public void ClearText()                                                               // İstenen labellerin Textlerini temizleyen fonksiyon.
        {
            lblError.Text = "";
            lblLink.Text = "";
        }
        #endregion

        #region Wait One Second
        private void Wait()                                                                      //İşlemin yapıldığı yazısını görmek için programın beklemesini sağlayan fonksiyon.
        {
            Thread.Sleep(1000);                                                                  //Programın 1sn beklemesini sağlayan thread fonksiyonu
        }
        #endregion

        #region Get All Controls on Form                                                        
        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)                  //Bütün form elemanlarını(controls) Listeye atıp döndüren fonksiyon. (Form Load Eventinin içinde kullanıyoruz)
        {
            List<Control> controls = new List<Control>();                                           

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }
            controls.Add(parent);
            return controls;
        }
        #endregion

        #region Get Assembly Infos And Wright To Text
        private void GetAssemblyInfos()                                                         //Assembly info bilgilerini alıp istenen textlere(about) yazdıran fonk.
        {
            Assembly asm = Assembly.GetExecutingAssembly();                          //Assembly sınıfından yürütülen assembly özelliklerini asm objesine atıyoruz.
            object[] obj = asm.GetCustomAttributes(false);                          //asm objesinin attribute'larını değiştireceğimiz için Custom attribute'sız(<-false) halini obj tipindeki diziye atıyoruz.
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(AssemblyCopyrightAttribute))                 //o objesinden tipi AssemblyCopyrightAttribute olanı getir               
                {
                    AssemblyCopyrightAttribute ac = (AssemblyCopyrightAttribute)o;     // Oluşturulan ac nesnesine ata

                    lblCopyright.Text = ac.Copyright;                                  //Copyright textinin içine yazdır.                   
                }

                else if (o.GetType() == typeof(AssemblyProductAttribute))              
                {
                    AssemblyProductAttribute ap = (AssemblyProductAttribute)o;
                    lblProductName.Text = ap.Product;
                }

                else if (o.GetType() == typeof(AssemblyFileVersionAttribute))
                {
                    AssemblyFileVersionAttribute av = (AssemblyFileVersionAttribute)o;
                    lblVersion.Text = "Version " + av.Version;
                }

            }

        }
        #endregion

        #region Key Count and set Key Count Control
        public int ControlKeyCount(DateTime startDate, DateTime endDate)     //başlangıç ve bitiş tarihlerini alıp arasındaki farkı gün cinsinden döndürüyoruz.
        {
            TimeSpan timeDifference = new TimeSpan();                        //Tarih farklarını atayabilmek için Timespandan nesne oluşturuyoruz.
            timeDifference = endDate - startDate;                            //Nesneye farkı atıyoruz
            return timeDifference.Days + 1;                                  //Başlangıç ve bitiş günlerininde dahil olması için zamanı gün cinsine çevirip 1 ekliyoruz.
        }
        #endregion




        #region Event: Form - Load
        private void frmKeyGenerate_Load(object sender, EventArgs e)
        {
            rdoAES.Checked = true;                                                      //Default olarak AES Radio Butonunu işretle.
            GetAssemblyInfos();                                                         //Abouttaki assembly infolarını yazdır.
                  
            dtpStart.MinDate = DateTime.Today;                                          //Başlangıç tarihini minimum bugun olarak göster. Öncesini Date Tİme Picker'da gösterme
            dtpEnd.MaxDate = DateTime.Today.AddDays(29);                                //Bitiş tarihi başlangıç tarihinden max. 30 gün fazla olabilir. Daha fazlasını DTP'da gösterme
            dtpEnd.MinDate = DateTime.Today;

            
            controllerList = GetSelfAndChildrenRecursive(this).ToList();                //Formdaki kontrollerin fonksiyonla hepsini önceden oluşturduğumuz controllerList listesinde atıyoruz.
            foreach (var control in controllerList)
            {
                if (control.GetType() == typeof(DateTimePicker))                        //Form kontrollerinin içinden Date Tİme Picker tipinde olan varsa,
                {

                    DateTimePicker dtp = (DateTimePicker)control;                       //control'ü DTP tipindeki nesneye dönüştürüp ona ata,
                    dtp.ValueChanged += Dtp_ValueChanged;                               //DTP'deki value her değiştiğinde (Event)Dtp_ValueChanged fonksiyonunu çalıştır.
                   
                }
                else if(control.GetType()==typeof(RadioButton))
                {
                    RadioButton rdo = (RadioButton)control;
                    rdo.CheckedChanged += Rdo_CheckedChanged;
                }

                else if(control.GetType()==typeof(ComboBox))
                {
                    ComboBox cmb = (ComboBox)control;
                    cmb.SelectedValueChanged += Cmb_SelectedValueChanged;
                }
                else if (control.GetType() == typeof(TabControl))
                {
                    TabControl tbp = (TabControl)control;
                    tbp.Click += Tbp_Click;
                }
            }


        }
        #endregion

        #region Event: Label Link - Link Clicked
        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)      //Label linkteki yolu açmamızı sağlayan fonk.
        {
            System.Diagnostics.Process.Start(lblLink.Text);                                  //Sistemde process başlatıyoruz ismini(path) vererek. 
            lblLink.LinkVisited = true;                                                      // Prosesi verdiğimiz isimle çağırıp LinkVisited fonk.unu kullanarak verdiğimiz linkteki pencerenin açılmasını sağlıyoruz
        }
        #endregion

        #region Event: Date Time Picker (dtpStart) - Value Changed                                          
        private void dtpStart_ValueChanged(object sender, EventArgs e)      //Tarih başlangıcına göre bitişini enfazla 30 gün olacak şekilde belirleyen ve DateTimePicker'da diğer tarihleri göstertmeyen fonk.
        {
            DateTime time = dtpStart.Value;
            time = time.AddDays(29);
            dtpEnd.MaxDate = time;                                       
            dtpEnd.MinDate = dtpStart.Value;
        }
        #endregion

        #region Event: Radio Button - Chacked Changed                        (Clear Text)
        private void Rdo_CheckedChanged(object sender, EventArgs e)
        {
            ClearText();                 
        }
        #endregion

        #region Event: ComboBox Selected - Value Changed                     (Clear Text)
        private void Cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearText();
        }
        #endregion

        #region Event: Date Time Pickers (all) - Value Changed               (Clear Text)
        private void Dtp_ValueChanged(object sender, EventArgs e)
        {
            ClearText();
        }
        #endregion

        #region Event: Tabs - Click                                          (Clear Text)
        private void Tbp_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        #endregion








    }
}

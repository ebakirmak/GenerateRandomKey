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
            control = new Controls();
        }
        private string[] randomKey;                                                              //Decimal cinsinden sayıların tutulacağı dizi.
        private string []  hexDecimals;                                                          //Hex cinsinden sayıların tutulacağı dizi.
        public Dossier dosya { get; set; }                                                       //Dosyalama işlemleri için oluşturulan sınıfın nesnesi.
        private bool state = false;                                                               //Durum değişkeni.
        private DateTime dateStart;                                                              //Başlangıç ve bitiş tarihleri.
        private DateTime dateEnd;
        List<Control> controllerList;                                                            //Form içindeki kontrollerın tutulduğu liste.
        public Controls control;                                                                 //Control Fonksiyonlarının tutulduğu sınıfın nesnesi
        
        private void Wait()                                                                      //İşlemin yapıldığı yazısını görmek için programın beklemesini sağlayan fonksiyon.
        {
            Thread.Sleep(1000);                                                                   //Programın 1sn beklemesini sağlayan thread fonksiyonu
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblLink.Text = "";
            lblError.Text = "";

            int dayCount = 0;                                                                      //Oluşturulacak keylerin gün sayısı
            int KeyLength = 0;                                                                     //Oluşturulacak Keylerin bit uzunluğu

            dateStart = dtpStart.Value.Date;                                                      //Date Time Picker'daki tarih başlangıcını dateStart nesnesine atıyoruz            
            dateEnd = dtpEnd.Value.Date;                                                          //Tarih bitişini dateEnd nesnesine atıyoruz         


            dayCount = control.ControlKeyCount(dateStart, dateEnd);                              //Fonksiyon ile seçilen tarihler aradaki gün farkını değişkene atıyoruz.

            randomKey = new string[dayCount];                                                    //Decimal cinsinden tutulacak olan random key dizisi. 
            hexDecimals = new string[dayCount];                                                  //Hex cinsine dönüştürülen keylerin tutulacağı dizi. 

                   
            KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);                        //Keylength'deki seçilen ifadeden (örn:128 bit) boşluktan sonrasını atıp int cinsine çevirek değişkene atıyoruz.
            randomKey = GenerateRandomKey(KeyLength, dayCount);                                  //
            if (dosya.WriteToFile(hexDecimals, dayCount, randomKey,dateStart) == true)
                state = true;
                     
 
                if (state == true)
                {
                    lblError.ForeColor = Color.Black;
                    lblError.Text = "Processing. Please wait...";
                    Thread threadWait = new Thread(new ThreadStart(Wait));
                    threadWait.Start();
                    threadWait.Join();
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Encryption Keys are generated successfully.";
                    int splitPosition = dosya.getFilePath().LastIndexOf("EncKey_");
                    string a;
                    if (splitPosition != -1)
                    {
                        a = dosya.getFilePath().Substring(splitPosition);
                        lblLink.Text = dosya.getFilePath().Replace(a, "");
                        state = false;

                    }
                    else
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Error. Keys are not generated !";
                    }

                }
            }
           
 
        #region Generate Random Key
        
        private string[] GenerateRandomKey(int keyLength,int countDay)              //key uzunluğu ve gün sayısını alıyoruz.
        {
            Random random = new Random();                                           
            string[] randomKeys = new string[countDay];                             //Decimal cinsinden random keylerin saklanacağı dizi.

            for (int i = 0; i < countDay; i++)                                      //Gün sayısı kadar .
            {
                string currentKey = "";                                            //string cinsinden tanımlıyoruz.
                string currentHex = "";
                for (int j = 0; j < keyLength / 8; j++)
                {
                    int rInt = random.Next(0, 255);                                 //0-255 arasında random sayı üretiyoruz.
                    currentKey += rInt+"-";                                             
                    if(rInt<16)
                        currentHex += "0"+rInt.ToString("X");                       //ürettiğimiz random sayıyı hex cinsine çevirip Stringe tipine dönüştürerek currentHex değişkenine atıyoruz.
                    else
                        currentHex += rInt.ToString("X");                           
                }
                randomKeys[i] = currentKey;
                hexDecimals[i] = currentHex;
               
            }
            return randomKeys;
          
        }
        #endregion

           

        #region Change combobox object
        private void rdoAES_CheckedChanged(object sender, EventArgs e)
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

        #region Clear Label Text
        public void ClearText()
        {
            lblError.Text = "";
            lblLink.Text = "";
        }
        #endregion


        private void frmKeyGenerate_Load(object sender, EventArgs e)
        {
            rdoAES.Checked = true;
        
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() ==
                    typeof(System.Reflection.AssemblyCopyrightAttribute))
                {
                    AssemblyCopyrightAttribute ac =
            (AssemblyCopyrightAttribute)o;
                    lblCopyright.Text = ac.Copyright;
                }

                else if (o.GetType() == typeof(AssemblyProductAttribute))
                {
                    AssemblyProductAttribute ap = (AssemblyProductAttribute)o;
                    lblProductName.Text = ap.Product;
                }

                else if(o.GetType()==typeof(AssemblyFileVersionAttribute))
                {
                    AssemblyFileVersionAttribute av = (AssemblyFileVersionAttribute)o;
                    lblVersion.Text = "Version " + av.Version;
                }
                
            }

            dtpStart.MinDate = DateTime.Today;
            dtpEnd.MaxDate = DateTime.Today.AddDays(29);
            dtpEnd.MinDate = DateTime.Today;

            //get Form Controllers 
            controllerList = GetSelfAndChildrenRecursive(this).ToList();
            foreach (var control in controllerList)
            {
                if (control.GetType() == typeof(DateTimePicker))
                {

                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.ValueChanged += Dtp_ValueChanged;
                   
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

        private void Tbp_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void Cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearText();
        }

        private void Dtp_ValueChanged(object sender, EventArgs e)
        {
            ClearText();
        }

        private void Rdo_CheckedChanged(object sender, EventArgs e)
        {
            ClearText();                 
        }
     
        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }
            controls.Add(parent);
            return controls;
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
            lblLink.LinkVisited = true;
        }
      
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dtpStart.Value;
            time = time.AddDays(29);
            dtpEnd.MaxDate = time;
            dtpEnd.MinDate = dtpStart.Value;
        }

       
    }
}

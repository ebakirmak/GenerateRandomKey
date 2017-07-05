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
        }
        private string []  hexDecimals;
        private string[] randomKey;
        public Dossier dosya { get; set; }
        private bool state = false;
        private DateTime dateStart;
        private DateTime dateEnd;
        private void Wait()
        {
            Thread.Sleep(1000);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblLink.Text = "";
            lblError.Text = "";

            int CountDay = 0;
            int KeyLength = 0;

            dateStart = dtpStart.Value.Date;
            dateEnd = dtpEnd.Value.Date;

            if (ControlCalendar(dateStart, dateEnd) == 1)
            {
                CountDay = ControlKeyCount(dateStart, dateEnd);

                hexDecimals = new string[CountDay];
                randomKey = new string[CountDay];
                if (rdoAES.Checked == true)
                {
                    if (AESKeyLength(cmbKeyLength.Text) == true && CountDay != 0)
                    {
                        KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                        randomKey = GenerateRandomKey(KeyLength, CountDay);
                        if (dosya.writeToFile(hexDecimals, CountDay, randomKey) == true)
                            state = true;
                    }
                }
                else if (rdoBlowFish.Checked == true)
                {
                    if (BlowFishKeyLength(cmbKeyLength.Text) == true && CountDay != 0)
                    {
                        KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                        randomKey = GenerateRandomKey(KeyLength, CountDay);
                        if (dosya.writeToFile(hexDecimals, CountDay, randomKey) == true)
                            state = true;
                    }
                }
                else
                {
                    // lblError.Text = "Wrong or missing input." + Environment.NewLine + "Please Check informations";
                    /* if (txtLocation.Text == "")
                        lblError.Text = "Please Choose Location";*/
                }

                if (state == true)
                {
                    lblError.ForeColor = Color.Black;
                    lblError.Text = "Keys are generating. Please wait...";
                    Thread threadWait = new Thread(new ThreadStart(Wait));
                    threadWait.Start();
                    threadWait.Join();
                    lblError.ForeColor = Color.Green;
                    lblError.Text =CountDay + " daily keys are successfully generated.";
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
            else if (ControlCalendar(dateStart, dateEnd) == -1)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Start date can not be bigger than end date.";
            }
            else if (ControlCalendar(dateStart, dateEnd) == -2)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Day count can not more than 30.";
            }
            else if (ControlCalendar(dateStart, dateEnd) == -3)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Date can not select before today.";

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Diffferent Error.";
            }




            }
        

        #region Control Key Count and set Key Count
        private int ControlKeyCount(DateTime start, DateTime end)
        {
            TimeSpan different = new TimeSpan();
            different = end - start;
            return different.Days+1;
        }
        #endregion

        #region Control AES Key Length
        private bool AESKeyLength (String KeyLength)
        {
            try
            {
                int len = Convert.ToInt32(KeyLength.Split(' ')[0]);
                if (len == 128 || len == 192 || len == 256)
                    return true;
                else
                {
                    lblError.Text = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                    //MessageBox.Show("AES Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                //MessageBox.Show("AES Key is Wrong");
                ex.ToString();
                return false;
            }
            
        }
        #endregion

        #region Control BlowFish Key Length
        private bool BlowFishKeyLength(String KeyLength)
        {
            try
            {
                int len = Convert.ToInt32(KeyLength.Split(' ')[0]);
                if (len >= 32 && len <= 448 && len % 8 == 0)
                    return true;
                else {
                    lblError.Text = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                    // MessageBox.Show("BlowFish Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                //MessageBox.Show("BlowFish Key is Wrong");
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region Generate Random Key
        private string[] GenerateRandomKey(int keyLength,int countDay)
        {
            Random random = new Random();
            string[] randomKeys = new string[countDay];


            for (int i = 0; i < countDay; i++)
            {
                string currentKey = "";
                string currentHex = "";
                for (int j = 0; j < keyLength / 8; j++)
                {
                    int rInt = random.Next(0, 255);
                    currentKey += rInt+"-";
                    currentHex += rInt.ToString("X");
                }
                randomKeys[i] = currentKey;
                hexDecimals[i] = currentHex;
               
            }
            return randomKeys;
          
        }
        #endregion

        #region Convert String to Hex
        /* private string[] ConvertToHex(string [] randomKeys, int countDay)
         {
             string[] hex = new string[countDay];
             for (int i = 0; i < countDay; i++)
             {
                 byte[] bytes = Encoding.Default.GetBytes(randomKeys[i]);
                 var hexString = BitConverter.ToString(bytes);
                 hexString = hexString.Replace("-", "");
                 hex[i] = hexString;
             }

             return hex;
         }*/
        #endregion      

        #region Clear combobox object
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

        private int ControlCalendar(DateTime dateStart, DateTime dateEnd)
        {

            if (!ControlBeginOfDate(dateStart, dateEnd))
                return -3;
            else if (!ControlDate(dateStart, dateEnd))
                return -1;
            else if (!ControlDayCount(dateStart, dateEnd))
                return -2; 
            else
                return 1;
            

        }

        private bool ControlDayCount(DateTime dateStart, DateTime dateEnd)
        {
            TimeSpan diff = new TimeSpan();
            diff = dateEnd - dateStart;
            if (diff.Days + 1 > 30)
                return false;
            else
                return true;
              
        }

        private bool ControlDate(DateTime dateStart, DateTime dateEnd)
        {

            if (dateEnd >= dateStart)
                return true;
            else
                return false;
        }

        private bool ControlBeginOfDate(DateTime start,DateTime end)
        {
            if (start < DateTime.Today || end<DateTime.Today)
                return false;
            else
                return true;
        }

        private void txtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmKeyGenerate_Load(object sender, EventArgs e)
        {
            rdoAES.Checked = true;
            //lblVersion.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
            //lblProductName.Text = Application.ProductName;
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
            dtpEnd.MaxDate = DateTime.Today.AddDays(30);
            dtpEnd.MinDate = DateTime.Today;
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblAlgorithm_Click(object sender, EventArgs e)
        {

        }

        private void tabGenerator_Click(object sender, EventArgs e)
        {

        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
            lblLink.LinkVisited = true;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dtpStart.Value;
            time=time.AddDays(30);
            dtpEnd.MaxDate = time;
            dtpEnd.MinDate = dtpStart.Value;
        }
    }
}

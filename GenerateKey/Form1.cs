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
        private string []  hexDecimals;
        private string[] randomKey;
        public Dossier dosya { get; set; }
        private bool state = false;
        private DateTime dateStart;
        private DateTime dateEnd;
        List<Control> controllerList;
        public Controls control;
        
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

            if (control.ControlCalendar(dateStart, dateEnd)== 1)
            {
                CountDay = control.ControlKeyCount(dateStart, dateEnd);

                hexDecimals = new string[CountDay];
                randomKey = new string[CountDay];
                if (rdoAES.Checked == true)
                {
                    if (control.AESKeyLength(cmbKeyLength.Text,lblError.Text) == true && CountDay != 0)
                    {
                        KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                        randomKey = GenerateRandomKey(KeyLength, CountDay);
                        if (dosya.writeToFile(hexDecimals, CountDay, randomKey,dateStart) == true)
                            state = true;
                    }
                }
                else if (rdoBlowFish.Checked == true)
                {
                    if (control.BlowFishKeyLength(cmbKeyLength.Text, lblError.Text) == true && CountDay != 0)
                    {
                        KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                        randomKey = GenerateRandomKey(KeyLength, CountDay);
                        if (dosya.writeToFile(hexDecimals, CountDay, randomKey,dateStart) == true)
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
            else if (control.ControlCalendar(dateStart, dateEnd) == -1)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Start date can not be bigger than end date.";
            }
            else if (control.ControlCalendar(dateStart, dateEnd) == -2)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Day count can not more than 30.";
            }
            else if (control.ControlCalendar(dateStart, dateEnd) == -3)
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
                    if(rInt<16)
                        currentHex += "0"+rInt.ToString("X");
                    else
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

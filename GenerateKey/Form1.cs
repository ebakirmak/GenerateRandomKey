using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateKey
{
    public partial class frmKeyGenerate : Form
    {
        public frmKeyGenerate()
        {
            InitializeComponent();
        }
        private string []  hexDecimals;
        private string[] randomKey;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int CountDay = 0;
            int KeyLength = 0;
            CountDay = ControlKeyCount(cmbCountDay.Text.ToString());
            hexDecimals = new string[CountDay];
            randomKey = new string[CountDay];
            if (rdoAES.Checked == true && cmbCountDay.Text != "")
            {

               
                if (AESKeyLength(cmbKeyLength.Text) == true &&CountDay!=0)
                {
                    KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                    randomKey = GenerateRandomKey(KeyLength, CountDay);
                   
                    writeToFile(hexDecimals, CountDay);
                    MessageBox.Show("AES Key Generate Successful");

                }

            }
            else if (rdoBlowFish.Checked == true  && cmbCountDay.Text!="")
            {
                if (BlowFishKeyLength(cmbKeyLength.Text) == true && CountDay != 0)
                {
                    KeyLength = Convert.ToInt32(cmbKeyLength.Text.Split(' ')[0]);
                    randomKey = GenerateRandomKey(KeyLength, CountDay);
                    writeToFile(hexDecimals, CountDay);
                    MessageBox.Show("BlowFish Key Successful");
                }
           
            }
            else
            {
                if (cmbCountDay.Text != "")
                     MessageBox.Show("Please Select a algorithm");
                else if(cmbCountDay.Text == "")
                    MessageBox.Show("Please Select Key Count");

            }          
   
        }

        #region Control Key Count and set Key Count
        private int ControlKeyCount(String Count)
        {
            int count = 0;
            if (Count == "Weekly")
                count = 7;
            else if (Count == "Monthly")
                count = 30;
            else
            { count = 0; MessageBox.Show("Please Select Key Count"); }

            return count;
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
                    MessageBox.Show("AES Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AES Key is Wrong");
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
                    MessageBox.Show("BlowFish Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BlowFish Key is Wrong");
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

        public void writeToFile(string[] strKeys, int countDay)
        {

            string filePath = @"Keys.txt";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            DateTime today = DateTime.Today;

            for (int i = 0; i < countDay; i++)
            {
                sw.WriteLine(today.ToShortDateString() + "  " + (i + 1) + ".Key: " + hexDecimals[i]+"   Random Key: "+randomKey[i]);
                today = today.AddDays(1);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void cmbKeyLength_Click(object sender, EventArgs e)
        {
            if (rdoAES.Checked==true)
            {
                cmbKeyLength.Items.Clear();
                cmbKeyLength.Items.Add("128 Bit");
                cmbKeyLength.Items.Add("192 Bit");
                cmbKeyLength.Items.Add("256 Bit");
            }
            else if (rdoBlowFish.Checked == true)
            {
                cmbKeyLength.Items.Clear();
                for (int i = 32; i <= 448; i+=8)
                {
                    cmbKeyLength.Items.Add(i + " Bit");
                }
            }
            else
            {
                cmbKeyLength.Items.Clear();
                cmbKeyLength.Items.Add("Select a Algorithm");
            }
        }

        private void rdoAES_CheckedChanged(object sender, EventArgs e)
        {
            cmbKeyLength.Text = "";
        }
    }
}

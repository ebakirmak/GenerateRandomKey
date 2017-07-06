using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateKey
{
    public class Controls
    {
        #region Day Count Control
        public bool ControlDayCount(DateTime dateStart, DateTime dateEnd)
        {
            TimeSpan diff = new TimeSpan();
            diff = dateEnd - dateStart;
            if (diff.Days + 1 > 30)
                return false;
            else
                return true;

        }
        #endregion

        #region Calendar Control
        public int ControlCalendar(DateTime dateStart, DateTime dateEnd)
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
        #endregion

        #region Begin of Date Control
        public bool ControlBeginOfDate(DateTime start, DateTime end)
        {
            if (start < DateTime.Today || end < DateTime.Today)
                return false;
            else
                return true;
        }
        #endregion

        #region Date Control
        public bool ControlDate(DateTime dateStart, DateTime dateEnd)
        {

            if (dateEnd >= dateStart)
                return true;
            else
                return false;
        }
        #endregion

        #region Key Count and set Key Count Control
        public int ControlKeyCount(DateTime start, DateTime end)
        {
            TimeSpan different = new TimeSpan();
            different = end - start;
            return different.Days + 1;
        }
        #endregion

        #region AES Key Length Control
        public bool AESKeyLength(String KeyLength, String message)
        {
            try
            {
                int len = Convert.ToInt32(KeyLength.Split(' ')[0]);
                if (len == 128 || len == 192 || len == 256)
                    return true;
                else
                {
                    message = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                    //MessageBox.Show("AES Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                //MessageBox.Show("AES Key is Wrong");
                ex.ToString();
                return false;
            }

        }
        #endregion

        #region BlowFish Key Length Control
        public bool BlowFishKeyLength(String KeyLength, String message)
        {
            try
            {
                int len = Convert.ToInt32(KeyLength.Split(' ')[0]);
                if (len >= 32 && len <= 448 && len % 8 == 0)
                    return true;
                else
                {
                    message = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                    // MessageBox.Show("BlowFish Key is Wrong");
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = "Wrong or missing input" + Environment.NewLine + "Please Check informations";
                //MessageBox.Show("BlowFish Key is Wrong");
                ex.ToString();
                return false;
            }
        }
        #endregion

    }
}

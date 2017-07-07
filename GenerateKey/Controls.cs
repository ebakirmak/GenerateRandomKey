using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateKey
{
    public class Controls
    {
       
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
        public int ControlKeyCount(DateTime startDate, DateTime endDate)   //başlangıç ve bitiş tarihlerini alıp arasındaki farkı gün cinsinden döndürüyoruz.
        {
            TimeSpan timeDifference = new TimeSpan();                       //Tarih farklarını atayabilmek için Timespandan nesne oluşturuyoruz.
            timeDifference = endDate - startDate;                           //Nesneye farkı atıyoruz
            return timeDifference.Days + 1;                                 //Başlangıç ve bitiş günlerininde dahil olması için zamanı gün cinsine çevirip 1 ekliyoruz.
        }
        #endregion

     

    }
}

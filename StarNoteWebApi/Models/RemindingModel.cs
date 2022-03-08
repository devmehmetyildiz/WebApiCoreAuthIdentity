using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class RemindingModel
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int anakayıtid;
        public int Anakayıtid
        {
            get { return anakayıtid; }
            set { anakayıtid = value; }
        }

        private string anaKayıt;
        public string AnaKayıt
        {
            get { return anaKayıt; }
            set { anaKayıt = value; }
        }


        private string anaKayıtdetay;
        public string AnaKayıtdetay
        {
            get { return anaKayıtdetay; }
            set { anaKayıtdetay = value; }
        }

        private string hatırlatmatipi;
        public string Hatırlatmatipi
        {
            get { return hatırlatmatipi; }
            set { hatırlatmatipi = value; }
        }

        private string hatırlatmamesajı;
        public string Hatırlatmamesajı
        {
            get { return hatırlatmamesajı; }
            set { hatırlatmamesajı = value; }
        }

        private string hatırlatmadurumu;
        public string Hatırlatmadurumu
        {
            get { return hatırlatmadurumu; }
            set { hatırlatmadurumu = value; }
        }

    }
}
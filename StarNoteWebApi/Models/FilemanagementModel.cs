using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class FilemanagementModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int mainid;
        public int Mainid
        {
            get { return mainid; }
            set { mainid = value; }
        }


        private string türadı;
        public string Türadı
        {
            get { return türadı; }
            set { türadı = value; }
        }

        private string türdetay;
        public string Türdetay
        {
            get { return türdetay; }
            set { türdetay = value; }
        }

        private string kayıtdetay;
        public string Kayıtdetay
        {
            get { return kayıtdetay; }
            set { kayıtdetay = value; }
        }

        private string firmadı;
        public string Firmadı
        {
            get { return firmadı; }
            set { firmadı = value; }
        }

        private string klasörno;
        public string Klasörno
        {
            get { return klasörno; }
            set { klasörno = value; }
        }

        private string müşteriadı;
        public string Müşteriadı
        {
            get { return müşteriadı; }
            set { müşteriadı = value; }
        }

        private string dosyaadı;
        public string Dosyaadı
        {
            get { return dosyaadı; }
            set { dosyaadı = value; }
        }
        
    }
}
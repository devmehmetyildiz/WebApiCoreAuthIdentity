using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class CostumerModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string isim;
        public string İsim
        {
            get { return isim; }
            set { isim = value; }
        }

        private string tckimlik;
        public string Tckimlik
        {
            get { return tckimlik; }
            set { tckimlik = value; }
        }

        private string telefon;
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }


        private string eposta;
        public string Eposta
        {
            get { return eposta; }
            set { eposta = value; }
        }

        private string şehir;
        public string Şehir
        {
            get { return şehir; }
            set { şehir = value; }
        }

        private string ilçe;
        public string İlçe
        {
            get { return ilçe; }
            set { ilçe = value; }
        }


        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
    }
}
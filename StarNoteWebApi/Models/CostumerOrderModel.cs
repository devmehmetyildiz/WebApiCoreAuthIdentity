using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class CostumerOrderModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string siparişno;
        public string Siparişno
        {
            get { return siparişno; }
            set { siparişno = value; }
        }

        private string kayıtdetay;
        public string Kayıtdetay
        {
            get { return kayıtdetay; }
            set { kayıtdetay = value; }
        }

        private string kayıtdetay1;
        public string Kayıtdetay1
        {
            get { return kayıtdetay1; }
            set { kayıtdetay1 = value; }
        }

        private string kayıtdetay2;
        public string Kayıtdetay2
        {
            get { return kayıtdetay2; }
            set { kayıtdetay2 = value; }
        }

        private string tür;
        public string Tür
        {
            get { return tür; }
            set { tür = value; }

        }

        private string türdetay;
        public string Türdetay
        {
            get { return türdetay; }
            set { türdetay = value; }
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


        private string kayıttarihi;
        public string Kayıttarihi
        {
            get { return kayıttarihi; }
            set { kayıttarihi = value; }
        }

        private string randevutarihi;
        public string Randevutarihi
        {
            get { return randevutarihi; }
            set { randevutarihi = value; }
        }

        private string satıselemanı;
        public string Satıselemanı
        {
            get { return satıselemanı; }
            set { satıselemanı = value; }
        }
        
        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; }
        }

        private double önödeme;
        public double Önödeme
        {
            get { return önödeme; }
            set { önödeme = value; }
        }

        private double beklenentutar;
        public double Beklenentutar
        {
            get { return beklenentutar; }
            set { beklenentutar = value; }
        }

        private string kdv;
        public string Kdv
        {
            get { return kdv; }
            set { kdv = value; }
        }

        private string vergidairesi;
        public string Vergidairesi
        {
            get { return vergidairesi; }
            set { vergidairesi = value; }
        }

        private string vergino;
        public string Vergino
        {
            get { return vergino; }
            set { vergino = value; }
        }

        private string firmaadı;
        public string Firmaadı
        {
            get { return firmaadı; }
            set { firmaadı = value; }
        }

        private string firmaadresi;
        public string Firmaadresi
        {
            get { return firmaadresi; }
            set { firmaadresi = value; }
        }

        private string satışyöntemi;
        public string Satışyöntemi
        {
            get { return satışyöntemi; }
            set { satışyöntemi = value; }
        }

        private string ödemeyöntemi;
        public string Ödemeyöntemi
        {
            get { return ödemeyöntemi; }
            set { ödemeyöntemi = value; }
        }

        private string durum;
        public string Durum
        {
            get { return durum; }
            set { durum = value; }
        }

        private string acıklama;
        public string Acıklama
        {
            get { return acıklama; }
            set { acıklama = value; }
        }

        private string kullanıcı;
        public string Kullanıcı
        {
            get { return kullanıcı; }
            set { kullanıcı = value; }
        }

        private int savetype;
        public int Savetype
        {
            get { return savetype; }
            set { savetype = value; }
        }


        private string talimatadliye;
        public string Talimatadliye
        {
            get { return talimatadliye; }
            set { talimatadliye = value; }
        }

        private string talimatmahkeme;
        public string Talimatmahkeme
        {
            get { return talimatmahkeme; }
            set { talimatmahkeme = value; }
        }

        private string talimatkararno;
        public string Talimatkararno
        {
            get { return talimatkararno; }
            set { talimatkararno = value; }
        }

    }
}
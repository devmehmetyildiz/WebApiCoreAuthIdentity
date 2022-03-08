using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class MainModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string joborder;
        public string Joborder
        {
            get { return joborder; }
            set { joborder = value; }
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
            set { tckimlik = value;}
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
            set { eposta = value;  }
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

        private string ürün;
        public string Ürün
        {
            get { return ürün; }
            set { ürün = value; }
        }

        private string ürün2;
        public string Ürün2
        {
            get { return ürün2; }
            set { ürün2 = value; }
        }

        private string ürün2detay;
        public string Ürün2detay
        {
            get { return ürün2detay; }
            set { ürün2detay = value; }
        }

        private int miktar;
        public int Miktar
        {
            get { return miktar; }
            set { miktar = value; }
        }

        private string birim;
        public string Birim
        {
            get { return birim; }
            set { birim = value; }
        }

        private double ücret;
        public double Ücret
        {
            get { return ücret; }
            set { ücret = value; }
        }
        
        private string kdvoran;
        public string Kdvoran
        {
            get { return kdvoran; }
            set { kdvoran = value; }
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

        private string metod;
        public string Metod
        {
            get { return metod; }
            set { metod = value; }
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

        private string tavsiyeedilentutar;
        public string Tavsiyeedilentutar
        {
            get { return tavsiyeedilentutar; }
            set { tavsiyeedilentutar = value; }
        }

        private string önerilentutar;
        public string Önerilentutar
        {
            get { return önerilentutar; }
            set { önerilentutar = value; }
        }

        private string önerilenbirim;
        public string Önerilenbirim
        {
            get { return önerilenbirim; }
            set { önerilenbirim = value; }
        }

        private int kelimesayı;
        public int Kelimesayı
        {
            get { return kelimesayı; }
            set { kelimesayı = value; }
        }

        private int satırsayı;
        public int Satırsayı
        {
            get { return satırsayı; }
            set { satırsayı = value; }
        }

        private int karaktersayı;
        public int Karaktersayı
        {
            get { return karaktersayı; }
            set { karaktersayı = value; }
        }

        private string beklenentutar;
        public string Beklenentutar
        {
            get { return beklenentutar; }
            set { beklenentutar = value; }
        }


    }
}
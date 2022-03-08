using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class JobOrderModel
    {

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private int üstid;
        public int Üstid
        {
            get { return üstid; }
            set { üstid = value; }

        }

        private string joborder;
        public string Joborder
        {
            get { return joborder; }
            set { joborder = value; }
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
        
        private double tavsiyeedilentutar;
        public double Tavsiyeedilentutar
        {
            get { return tavsiyeedilentutar; }
            set { tavsiyeedilentutar = value; }
        }

        private double hesaplanantutar;
        public double Hesaplanantutar
        {
            get { return hesaplanantutar; }
            set { hesaplanantutar = value; }
        }

        private int hesaplananadet;
        public int Hesaplananadet
        {
            get { return hesaplananadet; }
            set { hesaplananadet = value; }
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

    }
}
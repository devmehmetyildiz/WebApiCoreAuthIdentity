using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.Models
{
    public class StokModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string stokkod;
        public string Stokkod
        {
            get { return stokkod; }
            set { stokkod = value; }
        }

        private string stokadı;
        public string Stokadı
        {
            get { return stokadı; }
            set { stokadı = value; }
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

        private double alışfiyat;
        public double Alışfiyat
        {
            get { return alışfiyat; }
            set { alışfiyat = value; }
        }


        private double satışfiyat;
        public double Satışfiyat
        {
            get { return satışfiyat; }
            set { satışfiyat = value; }
        }

        private string kdv;
        public string Kdv
        {
            get { return kdv; }
            set { kdv = value; }
        }


        private double iskonto;
        public double İskonto
        {
            get { return iskonto; }
            set { iskonto = value; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class UsersModel
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

        private string soyisim;
        public string Soyisim
        {
            get { return soyisim; }
            set { soyisim = value; }
        }


        private string kullanıcıadi;
        public string Kullanıcıadi
        {
            get { return kullanıcıadi; }
            set { kullanıcıadi = value; }
        }

        private string şifre;
        public string Şifre
        {
            get { return şifre; }
            set { şifre = value; }
        }

        private string mailadres;
        public string Mailadres
        {
            get { return mailadres; }
            set { mailadres = value; }
        }


        private string yetki;
        public string Yetki
        {
            get { return yetki; }
            set { yetki = value; }
        }

        private bool isactive;
        public bool Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        private string kayıttarihi;
        public string Kayıttarihi
        {
            get { return kayıttarihi; }
            set { kayıttarihi = value; }
        }


    }
}
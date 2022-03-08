using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.Models
{
    public class CompanyModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        private string companyname;
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }


        private string companyadress;
        public string Companyadress
        {
            get { return companyadress; }
            set { companyadress = value; }
        }


        private string taxno;
        public string Taxno
        {
            get { return taxno; }
            set { taxno = value; }
        }

        private string taxname;
        public string Taxname
        {
            get { return taxname; }
            set { taxname = value; }
        }



    }
}
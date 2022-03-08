using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.Models
{
    public class RemindingpropertyModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string properyname;
        public string Propertyname
        {
            get { return properyname; }
            set { properyname = value; }
        }

        private int propertyid;
        public int Propertyid
        {
            get { return propertyid; }
            set { propertyid = value; }
        }
    }
}
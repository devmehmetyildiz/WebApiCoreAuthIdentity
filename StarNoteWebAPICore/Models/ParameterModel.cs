using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.Models
{
    public class ParameterModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string parameter;
        public string Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }
    }
}
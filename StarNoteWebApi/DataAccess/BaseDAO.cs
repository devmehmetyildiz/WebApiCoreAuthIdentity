using StarNoteWebApi.EntitiyDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public class BaseDAO 
    {
        public StarNoteEntity objcontext  = new StarNoteEntity();
        public static string Satınalma = "GIDER";
        public static string Satış = "GELIR";
        public static int Type = 0;
        public static int TypeDetail = 1;
        public static int Salesman = 2;
        public static int Product = 3;
    }
}
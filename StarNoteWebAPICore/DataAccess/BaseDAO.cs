using Microsoft.EntityFrameworkCore;
using StarNoteWebAPICore.EntityDB;
using StarNoteWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebAPICore.DataAccess
{
    public class BaseDAO 
    {
        protected DbContext _context;
        public StarNoteEntity objcontext { get { return _context as StarNoteEntity; } }
        public static string Satınalma = "GIDER";
        public static string Satış = "GELIR";
        public static int Type = 0;
        public static int TypeDetail = 1;
        public static int Salesman = 2;
        public static int Product = 3;

        public BaseDAO() 
        {

        }
    }
}
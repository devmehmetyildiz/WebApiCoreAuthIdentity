using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarNoteWebApi.DataAccess
{
    public static class DAOBase
    {
        public static IDAO GetDAO()
        {
            return new DAOFactory();
        }
    }
}
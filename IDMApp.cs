using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM
{
    static class    IDMApp
    {
        static DataBase db;
        public static DataBase DB
            {
            get
            {
                if (db == null)
                    db = new DataBase();
                return db;
            }
}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace pastane_siparis_uygulamasi
{
    class baglan
    {
        public static string sqlconnection = ConfigurationManager.ConnectionStrings["pastane_siparis_uygulamasi.Properties.Settings.sepet_tablosuConnectionString"].ConnectionString;
    }
}

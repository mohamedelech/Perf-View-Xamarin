using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perf_View_Xamarin
{
   public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime  Date { get; set; }

        public Agenda()
        {
        }
    }

   

}

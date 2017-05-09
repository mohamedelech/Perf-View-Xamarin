using System;
using SQLite;

namespace Perf_View_Xamarin
{
    public class Performance
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Date { get; set; }
        public String Movement { get; set; }
        public String Reps { get; set; }
        public String Weight { get; set; }
        public String Photo { get; set; }
        public String Adresse { get; set; }

        public Performance()
        {
        }

        public Performance(int id, String date, String movement, String reps, String weight, String photo, String adresse)
        {
            this.ID = id;
            this.Date = date;
            this.Movement = movement;
            this.Reps = reps;
            this.Weight = weight;
            this.Photo = photo;
            this.Adresse = adresse;
        }

        public Performance(int id, String date, String movement, String reps, String weight)
        {
            this.ID = id;
            this.Date = date;
            this.Movement = movement;
            this.Reps = reps;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return Date + "\n" + Weight + " Kg      " + Reps + " Reps";
        }
    }
}

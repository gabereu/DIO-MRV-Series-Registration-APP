using System;
using Series;

namespace Classes
{
    public class Serie : BaseClass
    {
        private EGenre Genre {get; set;}
        public string Title {get; private set;}
        private string Description {get; set;}
        private int Year {get; set;}

        public bool Removed {get; private set;}

        public Serie(int id, EGenre genre, string title, string description, int year)
        {
            Id = id;
            Title = title;
            Description = description;
            Year = year;
            Removed = false;
        }

        public override string ToString()
        {
            string toString = "";
            toString += "Genre: " + this.Genre + Environment.NewLine;
            toString += "Title: " + this.Title + Environment.NewLine;
            toString += "Description: " + this.Description + Environment.NewLine;
            toString += "Year: " + this.Year + Environment.NewLine;
            toString += "Removed: " + this.Removed + Environment.NewLine;

            return toString;
        }

        public void Remove(){
            this.Removed = true;
        }

    }
}
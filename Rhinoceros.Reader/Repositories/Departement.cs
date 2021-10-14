using System;
namespace Rhinoceros.Reader.Repositories
{
    public class Departement
    {
        public string code { get; set; }
        public string name { get; set; }
        public int population { get; set; }

        public Departement(string code, string name, int population)
        {
            this.code = code;
            this.name = name;
            this.population = population;

        }

        public Departement()
        {
        }
    }
}

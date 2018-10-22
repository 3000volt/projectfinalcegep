using System;
using System.Collections.Generic;

namespace testactualisation.Appdata
{
    public partial class Famillecompetence
    {
        public Famillecompetence()
        {
            Competences = new HashSet<Competences>();
        }

        public string NomFamille { get; set; }
        public int Idfamille { get; set; }

        public ICollection<Competences> Competences { get; set; }
    }
}

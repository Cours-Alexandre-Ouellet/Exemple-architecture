using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal class Profil
    {
        [ClePrimaire]
        public int Identifiant { get; set; }

        public string Prenom { get; set; }

        public string DateNaissance { get; set; }

        public string Ville { get; set; }

        public override string ToString()
        {
            return $"Identifiant : {Identifiant}\nPrenom : {Prenom}\nDate naissance : {DateNaissance}\nVille : {Ville}";
        }
    }
}

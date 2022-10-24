using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_Vue_Vue_Modele
{
    internal class Profil : ModeleAbstrait
    {
        public string Prenom { get; set; }

        public string DateNaissance { get; set; }

        public string Ville { get; set; }

        public override string ToString()
        {
            return $"Prenom : {Prenom}\nDate naissance : {DateNaissance}\nVille : {Ville}";
        }
    }
}

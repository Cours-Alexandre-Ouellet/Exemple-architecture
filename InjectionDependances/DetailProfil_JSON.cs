using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionDependances
{
    internal class DetailProfil_JSON : IVue
    {
        public string Rendre(object contexte)
        {
            Profil profil = contexte as Profil;
            if(profil is not null)
            {
                return $"{{\n\t\"prenom\" : \"{profil.Prenom}\",\n" +
                    $"\t\"date_naissance\" : \"{profil.DateNaissance}\",\n" +
                    $"\t\"ville\" : \"{profil.Ville}\"\n}}";
            }

            return $"<p>Pas de profil trouvé</p>";
        }
    }
}

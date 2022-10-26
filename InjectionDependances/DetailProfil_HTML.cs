using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionDependances
{
    internal class DetailProfil_HTML : IVue
    {
        public string Rendre(object contexte)
        {
            Profil profil = contexte as Profil;
            if (profil is not null)
            {
                return $"<h1>{profil.Prenom}</h1>\n" +
                    $"<p>Age : {CalculerAge(profil.DateNaissance)}</p>\n" +
                    $"<p>Ville : {profil.Ville}</p>";
            }

            return $"<p>Pas de profil trouvé</p>";
        }

        private int CalculerAge(string ddn)
        {
            DateTime dtNaissance = DateTime.Parse(ddn);
            DateTime dtMaintenant = DateTime.Now;

            TimeSpan age = dtMaintenant - dtNaissance;
            return (int) Math.Floor(age.TotalDays / 365.25);
        }
    }
}

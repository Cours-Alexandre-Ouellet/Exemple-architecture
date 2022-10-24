using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_Vue_Vue_Modele
{
    internal class VisualiserProfilVue : VueAbstraite
    {
        private readonly Profil modele;

        public VisualiserProfilVue(Profil profil) : base(profil)
        {
            modele = profil;
        }

        public override void Afficher()
        {
            bool continuer = true;

            AfficherProfil();
            while(continuer)
            {
                Console.WriteLine("Quel champ modifier (1) Prenom, (2) Date de naissance, (3) Ville ? (0) Quitter");
                if(int.TryParse(Console.ReadLine(), out int saisie))
                {
                    switch(saisie)
                    {
                        case 0:
                            continuer = false;
                            break;
                        case 1:
                            SaisirString("Quel est le prenom", "Prenom");
                            break;
                        case 2:
                            SaisirString("Quelle est la date de naissance", "DateNaissance");
                            break;
                        case 3:
                            SaisirString("Quelle est la ville", "Ville");
                            break;
                    }
                }
            }
        }

        private void SaisirString(string message, string propriete)
        {
            Console.WriteLine(message);
            string valeur=  Console.ReadLine();
            SaisirDonnee(propriete, valeur);
        }

        public override void MettreAJour()
        {
            AfficherProfil();
        }

        private void AfficherProfil()
        {
            Console.WriteLine(modele.ToString());
        }
    }
}

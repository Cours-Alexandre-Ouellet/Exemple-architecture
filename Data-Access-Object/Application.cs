using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal class Application
    {


        public static void Main(string[] args)
        {
            DAOProfil daoProfil = new DAOProfil();
            if(daoProfil.Selectionner(1) is not Profil profilModifie)
            {
                Console.WriteLine("Pas de profil trouvé avec l'id 1");
            }
            else
            {
                Console.WriteLine(profilModifie.ToString()+"\n");
                profilModifie.Ville = "Quebec";
                daoProfil.Sauvegarder(profilModifie);

                if(daoProfil.Selectionner(3) is not Profil profilSupprime)
                {
                    Console.WriteLine("Pas de profil trouvé avec l'id 3");
                }
                else
                {
                    daoProfil.Supprimer(profilSupprime);
                }
            }

            Profil[] profils = daoProfil.SelectionnerTout();
            foreach(Profil profil in profils)
            {
                Console.WriteLine(profil.ToString() + "\n");
            }
        }
    }
}

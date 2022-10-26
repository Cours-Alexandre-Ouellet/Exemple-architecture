using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal class DAOProfil : DAO<Profil>
    {
        TableBDEmulee<Profil> tableProfil;

        public StatutBD DernierStatut { get; private set; }

        public DAOProfil()
        {
            tableProfil = new TableBDEmulee<Profil>(new List<Profil>(
                new Profil[] {
                    new Profil{Identifiant = 1, Prenom = "Pierre", DateNaissance = "1990-10-15", Ville="Arthabaska"},
                    new Profil{Identifiant = 2, Prenom="Julie", DateNaissance = "1997-04-09", Ville="Warwick"},
                    new Profil{Identifiant = 3, Prenom="Anne", DateNaissance = "1994-08-07", Ville="St-Norbert"}
                }));
        }

        public override void Sauvegarder(Profil element)
        {
            if(Selectionner(element.Identifiant) is not null)
            {
                DernierStatut = tableProfil.Update(element);
            }
            else
            {
                DernierStatut = tableProfil.InsertInto(element);
            }
        }

        public override Profil? Selectionner(int identifiant)
        {
            return tableProfil.SelectById(identifiant);
        }

        public override Profil[] SelectionnerTout()
        {
            return tableProfil.SelectAll();
        }

        public override void Supprimer(Profil element)
        {
            DernierStatut = tableProfil.Delete(element);
        }
    }
}

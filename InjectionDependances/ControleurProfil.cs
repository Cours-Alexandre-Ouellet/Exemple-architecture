﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InjectionDependances
{
    class ControleurProfil : ControleurAbstrait
    {
        private readonly List<Profil> profils;

        [Injecter("fabriqueVue", typeof(FabriqueVue))]
        private ControleurProfil(FabriqueVue fabriqueVue) : base(fabriqueVue)
        {
            profils = new List<Profil>(
                new Profil[] {
                    new Profil{Prenom = "Pierre", DateNaissance = "1990-10-15", Ville="Arthabaska"},
                    new Profil{Prenom="Julie", DateNaissance = "1997-04-09", Ville="Warwick"},
                    new Profil{Prenom="Anne", DateNaissance = "1994-08-07", Ville="St-Norbert"}
                });
        }

        public void AfficherProfil(int idProfil)
        {
            try
            {
                Profil profil = profils[idProfil];
                Rendre("DetailProfil", profil);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}

﻿using System;

namespace Modele_Vue_Controleur
{
    class Application
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                throw new Exception("Paramètre d'application illégal.");
            }

            ControleurProfil controleurProfil = new(args[0]);
            controleurProfil.AfficherProfil(1);
        }
    }
}

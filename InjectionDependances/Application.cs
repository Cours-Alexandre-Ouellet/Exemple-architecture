using System;

namespace InjectionDependances
{
    class Application
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                throw new Exception("Paramètre d'application illégal.");
            }

            FabriqueControleur fabrique = new(args[0]);
            ControleurProfil controleur = fabrique.Fabriquer<ControleurProfil>();
            controleur.AfficherProfil(1);
        }
    }
}

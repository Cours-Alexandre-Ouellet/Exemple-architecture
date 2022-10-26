using System;
using System.Reflection;

namespace InjectionDependances
{
    class ControleurAbstrait
    {
        private readonly FabriqueVue fabriqueVue;

        protected ControleurAbstrait(FabriqueVue fabriqueVue)
        {
            this.fabriqueVue = fabriqueVue;
        }

        protected void Rendre(string nomModele, object contexte)
        {
            try
            {
                Console.WriteLine(fabriqueVue.Fabriquer(nomModele).Rendre(contexte));
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}

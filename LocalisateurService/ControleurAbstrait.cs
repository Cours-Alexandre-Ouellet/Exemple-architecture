using System;
using System.Reflection;

namespace LocalisateurService
{
    class ControleurAbstrait
    {
        private readonly string sortie;

        protected ControleurAbstrait(string sortie)
        {
            this.sortie = sortie;
        }

        protected void Rendre(string nomVue, object contexte) 
        {
            IVue vue = CreerVue(nomVue);
            Rendre(vue, contexte);
        }

        protected void Rendre(IVue vue, object contexte)
        {
            try
            {
                Console.WriteLine(vue.Rendre(contexte));
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        protected IVue CreerVue(string nomVue)
        {
            return Activator.CreateInstance(
                Assembly.GetExecutingAssembly().GetName().Name, 
                $"{nomVue}_{sortie}").Unwrap() as IVue;

            return null;
        }
    }
}

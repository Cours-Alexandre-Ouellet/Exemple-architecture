using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading.Tasks;

namespace InjectionDependances
{
    internal abstract class FabriqueVue
    {
        public abstract IVue Fabriquer(string nomVue);

        protected IVue FabriquerInterne(string nomVue, string sortie)
        {
            if(Assembly.GetExecutingAssembly().GetName().Name is string nomAsembly)
            {

                if(Activator.CreateInstance(nomAsembly, $"InjectionDependances.{nomVue}_{sortie}") is ObjectHandle gestionInstanceVue)
                {
                    if(gestionInstanceVue.Unwrap() is IVue vue)
                    {
                        return vue;
                    }
                }
            }
            throw new Exception($"Pas possible de creer la vue {nomVue} pour la sortie {sortie}.");
        }
    }
}

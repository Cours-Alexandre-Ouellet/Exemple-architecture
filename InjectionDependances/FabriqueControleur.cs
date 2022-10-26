using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace InjectionDependances
{
    internal class FabriqueControleur
    {
        private readonly string sortie;

        public FabriqueControleur(string sortie)
        {
            this.sortie = sortie;
        }

        public T Fabriquer<T>(Dictionary<string, object> parametres = null) where T : ControleurAbstrait
        {
            
            if(parametres is null)
            {
                parametres = new();
            }

            if(typeof(T).GetTypeInfo().DeclaredConstructors.First() is ConstructorInfo cnstr)
            {
                IEnumerable<Injecter> injections = cnstr.GetCustomAttributes<Injecter>();
                if(injections is null)
                {
                    injections = new Injecter[0];
                }
                
                ParameterInfo[] infoParametres = cnstr.GetParameters();
                int nombreParametres = infoParametres.Length;
                object[] valeursParametres = new object[nombreParametres];
                for(int i = 0; i < nombreParametres; i++)
                {
                    ParameterInfo p = infoParametres[i];
                    if(injections.Select(a => a.NomParametre == p.Name && a.Type == p.ParameterType).First())
                    {
                        valeursParametres[i] = GetParametre(p.ParameterType);
                    }
                    else if(parametres.TryGetValue(p.Name, out object valeurParametre))
                    {
                        valeursParametres[i] = valeurParametre;
                    }
                    else
                    {
                        valeursParametres[i] = null;
                    }
                }

                return cnstr.Invoke(valeursParametres) as T;
                
            }

            return null;
        }

        private object GetParametre(Type type)
        {
            switch(type.Name)
            {
                case "FabriqueVue":
                    switch(sortie)
                    {
                        case "HTML":
                            return new FabriqueVueHTML();
                        case "JSON":
                            return new FabriqueVueJSON();
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalisateurService
{
    internal class GestionnaireService
    {
        private readonly List<IService> services;

        private static GestionnaireService? instance;
        public static GestionnaireService Instance
        {
            get
            {
                if(instance is null)
                {
                    instance = new GestionnaireService();
                }
                return instance;
            }
        }

        private GestionnaireService()
        {
            services = new List<IService>();
        }

        public T? GetService<T>() where T : class, IService, new()
        {
            IService? service = services.Find(s => typeof(T).Equals(s.GetType()));
            
            if(service is null)
            {
                service = new T();
                services.Add(service);
            }

            return service as T;
        }
    }


}

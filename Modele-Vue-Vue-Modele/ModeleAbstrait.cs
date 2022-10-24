using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Modele_Vue_Vue_Modele
{
    internal abstract class ModeleAbstrait
    {
        public virtual event Action<string, object, bool> OnChangementModele;
        
        public void MettreAJour(string nomPropriete, object valeur, bool propagation = true)
        {
            PropertyInfo propriete = 
                GetType().GetProperties().Where(p => p.Name == nomPropriete).FirstOrDefault();

            if(propriete is not null)
            {
                propriete.SetValue(this, valeur);
            }

            if(propagation)
            {
                OnChangementModele?.Invoke(nomPropriete, valeur, false);
            }
        }
    }
}

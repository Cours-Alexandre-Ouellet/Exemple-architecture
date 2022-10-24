using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_Vue_Vue_Modele
{
    internal abstract class VueAbstraite
    {
        public virtual event Action<string, object, bool> OnChangementVue;
        private readonly ResolveurDependences resolveurDependences;

        protected VueAbstraite(ModeleAbstrait modele)
        {
            resolveurDependences = new(this, modele);
        }

        public abstract void Afficher();

        public abstract void MettreAJour();

        public void SaisirDonnee(string propriete, object valeur)
        {
            OnChangementVue?.Invoke(propriete, valeur, true);
        }
    }
}

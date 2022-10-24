using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_Vue_Vue_Modele
{
    internal class ResolveurDependences
    {
        public event Action<string, object, bool> OnChangementVue;

        private readonly VueAbstraite vue;
        private readonly ModeleAbstrait modele;

        public ResolveurDependences(VueAbstraite vue, ModeleAbstrait modele)
        {
            this.vue = vue;
            this.modele = modele;

            modele.OnChangementModele += ChangementModele;
            vue.OnChangementVue += ChangementVue;
        }

        protected void ChangementModele(string propriete, object valeur, bool propagation)
        {
            MettreAJourVue(propriete, valeur, propagation);
        }

        public void MettreAJourModele(string propriete, object valeur, bool propagation)
        {
            modele.MettreAJour(propriete, valeur, propagation);
        }

        protected void ChangementVue(string propriete, object valeur, bool propagation)
        {
            MettreAJourModele(propriete, valeur, propagation);
        }

        public void MettreAJourVue(string propriete, object valeur, bool propagation)
        {
            vue.MettreAJour();   
        }
    }
}

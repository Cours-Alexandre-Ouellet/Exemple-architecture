/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Composant indiquant que la personne pratique une religion
    /// </summary>
    internal class PratiquantReligion : IComposant
    {
        public bool PermetMultiple => false;                    // Une seule religion par personne

        /// <summary>
        /// Nom de la religion.
        /// </summary>
        public string NomReligion { get; set; }

        /// <summary>
        /// À quelle fréquence est-ce que la religion est pratiquée
        /// </summary>
        public string FrequencePratique { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PratiquantReligion()
        {
            NomReligion = "";
            FrequencePratique = "";
        }
    }
}

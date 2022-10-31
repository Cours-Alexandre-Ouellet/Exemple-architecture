/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Composant indiquant que la personne étudie dans un programme
    /// </summary>
    internal class Etude : IComposant
    {
        /// <inheritdoc/>
        public bool PermetMultiple => true;                 // On peut compléter plusieurs programme

        /// <summary>
        /// Nom de l'école où la personne est inscrite
        /// </summary>
        public string NomEcole { get; set; }

        /// <summary>
        /// Nom du programme suivi par la personne
        /// </summary>
        public string NomProgramme { get; set; }

        /// <summary>
        /// Nombre de crédits complétés au sein du programme
        /// </summary>
        public float CreditsCompletes { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Etude()
        {
            NomEcole = "";
            NomProgramme = "";
            CreditsCompletes = 0.0f;
        }
    }
}

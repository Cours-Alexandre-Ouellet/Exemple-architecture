/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Contient les donnees d'une résidence principale d'une personne
    /// </summary>
    internal class ResidencePrincipal : IComposant
    {
        /// <inheritdoc/>
        public bool PermetMultiple => false;                    // Une seule résidence principale

        /// <summary>
        /// Le numéro civique de l'adresse
        /// </summary>
        public string NumeroCivique { get; set; }

        /// <summary>
        /// Le numéro de suite, d'appartement ou de bureau
        /// </summary>
        public string Suite { get; set; }

        /// <summary>
        /// Le nom de la rue
        /// </summary>
        public string Rue { get; set; }
        
        /// <summary>
        /// Le code postal de l'adresse
        /// </summary>
        public string CodePostal { get; set; }

        /// <summary>
        /// La ville de l'adresse
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// Constructeur par défaut. Initialise une adresse vide
        /// </summary>
        public ResidencePrincipal()
        {
            NumeroCivique = "";
            Suite = "";
            Rue = "";
            CodePostal = "";
            Ville = "";
        }
    }
}

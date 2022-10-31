/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

using System;

namespace Composants
{
    /// <summary>
    /// Composant de maladies qu'une personne peut avoir.
    /// </summary>
    internal class Maladie : IComposant
    {
        /// <inheritdoc/>
        public bool PermetMultiple => true;         // Peut avoir plusieurs maladies en même temps

        /// <summary>
        /// Nom de la maladie
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Liste des symptômes de la maladie
        /// </summary>
        public string[] Symptomes { get; set; }

        /// <inheritdoc/>
        public Maladie ()
        {
            Nom = "";
            Symptomes = Array.Empty<string>();
        }
    }
}

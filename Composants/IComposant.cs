/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Définit un composant pouvant être ajouté à une personne
    /// </summary>
    public interface IComposant
    {
        /// <summary>
        /// Implémentation à plusieurs reprise du même composant permise
        /// </summary>
        public abstract bool PermetMultiple { get; }


    }
}

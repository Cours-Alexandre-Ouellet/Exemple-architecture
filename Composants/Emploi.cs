/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Composant représentant un emploi
    /// </summary>
    internal class Emploi : IComposant
    {
        /// <inheritdoc/>
        public bool PermetMultiple => true;             // On peut occuper plusieurs emplois

        /// <summary>
        /// Nom de l'employeur
        /// </summary>
        public string NomEmployeur { get; set; }

        /// <summary>
        /// Titre du poste
        /// </summary>
        public string TitreEmploi { get; set; }

        /// <summary>
        /// Salaire par heure travaillée
        /// </summary>
        public float SalaireHoraire { get; set; }

        /// <summary>
        /// Nombre d'heures faites par semaine
        /// </summary>
        public float HeuresSemaine { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Emploi()
        {
            NomEmployeur = "";
            TitreEmploi = "";
            SalaireHoraire = 0.0f;
            HeuresSemaine = 0.0f;
        }

        /// <summary>
        /// Calcule le salaire hebdomadaire de la personne
        /// </summary>
        /// <returns></returns>
        public float GetSalaireHebdomadaire ()
        {
            return SalaireHoraire * HeuresSemaine;
        }
    }
}

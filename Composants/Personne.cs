/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

namespace Composants
{
    /// <summary>
    /// Représente un être humain dans le système
    /// </summary>
    public class Personne : ConteneurComposant
    {
        /// <summary>
        /// Nom de la personne
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Crée une nouvelle personne 
        /// </summary>
        /// <param name="nom">Le nom de la personne</param>
        public Personne(string nom) : base()
        {
            Nom = nom;
        }

        /// <summary>
        /// Calcule le salaire hebdomadaire.
        /// </summary>
        /// <returns>Le salaire hebdomadaire cumulatif de tous les emplois.</returns>
        public float GetSalaireHebdomadaire()
        {
            Emploi[] emplois = GetComposants<Emploi>();
            float salaireHebdomadaire = 0.0f;

            foreach(Emploi emploi in emplois)
            {
                salaireHebdomadaire += emploi.GetSalaireHebdomadaire();
            }

            return salaireHebdomadaire;
        }

        /// <summary>
        /// Calcule le nombre de crédits complétés, tous programmes d'étude confondus.
        /// </summary>
        /// <returns>Le nombre de crédits complétés.</returns>
        public float GetCreditsCompletes()
        {
            Etude[] etudes = GetComposants<Etude>();
            float creditsCompletes = 0.0f;

            foreach(Etude etude in etudes)
            {
                creditsCompletes += etude.CreditsCompletes;
            }

            return creditsCompletes;
        }

        /// <summary>
        /// Indique la religion et la fréquence de pratique de la personne.
        /// </summary>
        /// <returns>Une chaîne nommant la religion pratiquée et la fréquence de pratique.</returns>
        public string GetPratiqueReligieuse()
        {
            if(GetComposant<PratiquantReligion>() is PratiquantReligion pratique)
            {
                return $"Pratique du { pratique.NomReligion } de facon { pratique.FrequencePratique }";
            }

            return "Pas d'information sur la pratique religieuse.";
        }
    }
}

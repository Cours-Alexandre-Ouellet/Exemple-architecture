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
    /// Classe illustrant le fonctionnement du patron composants
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Point d'entrée du programme.
        /// </summary>
        /// <param name="args">Arguments passés au programme.</param>
        public static void Main(string[] args)
        {
            Executer();
        }

        /// <summary>
        /// Execute une simulation d'exécution
        /// </summary>
        public static void Executer()
        {
            // Création de la perosnne et de ses composants
            Personne personne = new("Paul");

            if(personne.AjouterComposant<ResidencePrincipal>() is ResidencePrincipal residence && residence is not null)
            {
                residence.NumeroCivique = "666";
                residence.Rue = "Blvd des Bois-mous";
                residence.Ville = "Victoriavillage";
                residence.CodePostal = "G6P 7H5";
            }
            if(personne.AjouterComposant<Emploi>() is Emploi emploi1 && emploi1 is not null)
            {
                emploi1.TitreEmploi = "Caissier";
                emploi1.NomEmployeur = "Dépanneur du coin";
                emploi1.SalaireHoraire = 17.75f;
                emploi1.HeuresSemaine = 20.0f;
            }
            if(personne.AjouterComposant<Emploi>() is Emploi emploi2 && emploi2 is not null)
            {
                emploi2.TitreEmploi = "Livreur";
                emploi2.NomEmployeur = "Au bon poulet";
                emploi2.SalaireHoraire = 16.80f;
                emploi2.HeuresSemaine = 15.0f;
            }
            if(personne.AjouterComposant<PratiquantReligion>() is PratiquantReligion religion && religion is not null)
            {
                religion.NomReligion = "Pastafarisme";
                religion.FrequencePratique = "Occasionnelle";
            }

            // Utilisation de composant
            Console.WriteLine(personne.GetSalaireHebdomadaire());
            Console.WriteLine(personne.GetCreditsCompletes());

            // Exemple ne fonctionnant pas de composant
            try
            {
                if(personne.AjouterComposant<PratiquantReligion>() is PratiquantReligion religion2 && religion2 is not null)
                {
                    religion2.NomReligion = "Satanisme";
                    religion2.FrequencePratique = "Quotidienne";
                }
            } catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Console.WriteLine(personne.GetPratiqueReligieuse());
        }
    }
}
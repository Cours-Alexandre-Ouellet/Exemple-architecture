/**
 * Alexandre Ouellet
 * Octobre 2022
 * 
 * Exemple de l'architecture de composants
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Composants
{
    /// <summary>
    /// Conteneur de composants. Permet l'ajout, l'accès et le retrait de composantes.
    /// </summary>
    public abstract class ConteneurComposant
    {
        private readonly List<IComposant> composants;           // Liste interne de composants

        /// <summary>
        /// Crée un nouveau conteneur vide
        /// </summary>
        protected ConteneurComposant()
        {
            composants = new();
        }

        /// <summary>
        /// Crée un nouveau composant du type spécifié.
        /// </summary>
        /// <typeparam name="T">Le type du composant à ajouter.</typeparam>
        /// <returns>Le nouveau composant créé.</returns>
        public T? AjouterComposant<T>() where T : class, IComposant, new()
        {
            T composant = new();

            // 2 cas : on peut avoir des répétitions du composant OU le composant n'est pas déjà ajouté
            if(composant.PermetMultiple || !composants.Any(c => c is T))
            {
                composants.Add(composant);
                return composant;
            }
            else
            {
                throw new ArgumentException($"Impossible d'ajouter le composant {typeof(T)} à plusieurs reprises.");
            }
        }

        /// <summary>
        /// Retourne le composant du type indiqué. Si plusieurs composants du même type existe, 
        /// alors on retourne le premier.
        /// </summary>
        /// <typeparam name="T">Le type du composant à récupérer.</typeparam>
        /// <returns>Le composant du type indiqué ou null si aucun composant de ce type n'a été ajouté à l'objet.</returns>
        public T? GetComposant<T>() where T : class, IComposant
        {
            if(composants.Where(c => c is T).ToArray() is IComposant[] composantsType && composantsType.Length > 0)
            {
                return composantsType[0] as T;
            }

            return null;
        }

        /// <summary>
        /// Retourne tous les composant du type indiqué. 
        /// </summary>
        /// <typeparam name="T">Le type du composant à récupérer.</typeparam>
        /// <returns>Tous les composants du type indiqué ou un tableau vide si aucun composant de ce type n'a été ajouté à l'objet.</returns>
        public T[] GetComposants<T>() where T : class, IComposant
        {
            if(composants.Where(c => c is T).ToArray() is IComposant[] composantsType)
            {
                return Array.ConvertAll(composantsType, e => (T) e) ?? Array.Empty<T>();
            }

            return Array.Empty<T>();
        }

        /// <summary>
        /// Retire un composant spécifique du conteneur.
        /// </summary>
        /// <typeparam name="T">Le type du composant à retirer.</typeparam>
        /// <param name="composant">Le composant à retirer</param>
        /// <returns>True si le composant a été retiré, false s'il n'est pas possible de le retirer.</returns>
        public bool SupprimerComposant<T>(T composant) where T : class, IComposant
        {
            return composants.Remove(composant);
        }

        /// <summary>
        /// Retire tous les composants d'un type du conteneur.
        /// </summary>
        /// <typeparam name="T">Le type des composants à retirer.</typeparam>
        public void SupprimerToutComposants<T>() where T : class, IComposant
        {
            composants.RemoveAll(c => c is T);
        }
    }
}

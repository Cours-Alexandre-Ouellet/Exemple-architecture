namespace Modele_Vue_Vue_Modele
{
    public class Application
    {
        public static void Main(string[] args)
        {
            VisualiserProfilVue gestionnaire = new(
                new Profil { Prenom = "Pierre", DateNaissance = "1990-10-15", Ville = "Arthabaska" });
            gestionnaire.Afficher();
        }
    }
}
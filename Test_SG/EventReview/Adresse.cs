namespace EventReview
{
    public class Adresse
    {
        private int NumeroDeRue { get; set; }
        private string NomDeLaRue { get; set; }
        private string Ville { get; set; }
        private int CodePostal { get; set; }
        private string Pays { get; set; }

        public Adresse(int numeroDeRue, string nomDeLaRue, int codePostal, string pays)
        {
            NumeroDeRue = numeroDeRue;
            NomDeLaRue = nomDeLaRue;
            CodePostal = codePostal;
            Pays = pays;
        }

        public string  GetAdresse()
        {
            return $"{NumeroDeRue} {NomDeLaRue} {Ville} {CodePostal}";
        }


    }
}
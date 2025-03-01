using System.IO;
using Xunit;
using PSI_Rendu1;

namespace PSI_Rendu1
{
    public class Tests
    {
        [Fact]
        public void CreerGraphe_Vide_AucunNoeud()
        {
            var graphe = new Graphe(0);
            Xunit.Assert.Empty(graphe.Noeuds);
            Xunit.Assert.Empty(graphe.Liens);
        }

        [Fact]
        public void AjouterLien_CreationNoeudsEtLiens()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);

            Xunit.Assert.Contains(1, graphe.Noeuds.Keys);
            Xunit.Assert.Contains(2, graphe.Noeuds.Keys);
            Xunit.Assert.Single(graphe.Liens);
            Xunit.Assert.Contains(2, graphe.ListeAdjacence[1]);
            Xunit.Assert.Contains(1, graphe.ListeAdjacence[2]);
        }

        [Fact]
        public void MatriceAdjacence_EstCorrecte_ApresAjoutLien()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 3);

            Xunit.Assert.Equal(1, graphe.MatriceAdjacence[1, 3]);
            Xunit.Assert.Equal(1, graphe.MatriceAdjacence[3, 1]);
            Xunit.Assert.Equal(0, graphe.MatriceAdjacence[1, 2]); /// Aucun lien entre 1 et 2
        }

        [Fact]
        public void ParcoursBFS_VisiteTousLesNoeuds()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 5);

            var visiteBFS = graphe.ParcoursBFS(1);
            Xunit.Assert.Equal(5, visiteBFS.Count);
        }

        [Fact]
        public void ParcoursDFS_VisiteTousLesNoeuds()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 5);

            var visiteDFS = graphe.ParcoursDFS(1);
            Xunit.Assert.Equal(5, visiteDFS.Count);
        }

        [Fact]
        public void EstConnexeBFS_GrapheConnexe_True()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 5);

            Xunit.Assert.True(graphe.EstConnexeBFS());
        }

        [Fact]
        public void EstConnexeDFS_GrapheConnexe_True()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 5);

            Xunit.Assert.True(graphe.EstConnexeDFS());
        }

        [Fact]
        public void EstConnexe_GrapheNonConnexe_False()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(3, 4);

            Xunit.Assert.False(graphe.EstConnexeBFS());
            Xunit.Assert.False(graphe.EstConnexeDFS());
        }

        [Fact]
        public void ChargerDepuisFichier_CreeGrapheCorrectement()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[] { "1 2", "2 3", "3 4", "4 5" });

            var graphe = new Graphe(5);
            graphe.ChargerDepuisFichier(tempFile);

            Xunit.Assert.Equal(5, graphe.Noeuds.Count);
            Xunit.Assert.Equal(4, graphe.Liens.Count);
            Xunit.Assert.True(graphe.EstConnexeBFS());

            File.Delete(tempFile);
        }

        [Fact]
        public void VisualiserGraphe_GenereFichierImage()
        {
            var graphe = new Graphe(5);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 5);

            string imagePath = "test_graph.png";
            graphe.VisualiserGraphe(imagePath);

            Xunit.Assert.True(File.Exists(imagePath));

            File.Delete(imagePath);
        }
    }
}



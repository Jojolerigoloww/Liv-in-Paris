using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSI_Rendu1;
using System.Collections.Generic;
using System.IO;

namespace Test_PSI
{
    [TestClass]
    public class GrapheTests
    {
        private Graphe graphe;

        [TestInitialize]
        public void Initialize()
        {
            graphe = new Graphe();

            graphe.AjouterNoeud(1, "Chatelet", 2.3522, 48.8566, "1", 0);
            graphe.AjouterNoeud(2, "Bastille", 2.3693, 48.8531, "1", 0);
            graphe.AjouterNoeud(3, "Nation", 2.3958, 48.8484, "1", 0);
            graphe.AjouterNoeud(4, "Gare de Lyon", 2.3739, 48.8448, "14", 2.5);
            graphe.AjouterNoeud(5, "Gare de Lyon", 2.3739, 48.8448, "1", 2.5);

            graphe.AjouterLien(1, 2, 3.5f);
            graphe.AjouterLien(2, 3, 4.0f);
            graphe.AjouterLien(2, 5, 2.0f);
            graphe.AjouterLien(5, 4, 2.5f);
        }

        [TestMethod]
        public void TestAjouterNoeud()
        {
            graphe.AjouterNoeud(6, "Bercy", 2.3794, 48.8399, "14", 0);

            Assert.IsTrue(graphe.Noeuds.ContainsKey(6));
            Assert.AreEqual("Bercy", graphe.Noeuds[6].Libelle);
            Assert.AreEqual(2.3794, graphe.Noeuds[6].Longitude);
            Assert.AreEqual(48.8399, graphe.Noeuds[6].Latitude);
            Assert.AreEqual("14", graphe.Noeuds[6].IdLigne);
        }

        [TestMethod]
        public void TestAjouterLien()
        {
            graphe.AjouterLien(3, 4, 5.0f);

            Assert.IsTrue(graphe.Liens.Exists(l =>
                (l.Noeud1.Sommet == 3 && l.Noeud2.Sommet == 4) ||
                (l.Noeud1.Sommet == 4 && l.Noeud2.Sommet == 3)));

            var lien = graphe.Liens.Find(l =>
                (l.Noeud1.Sommet == 3 && l.Noeud2.Sommet == 4) ||
                (l.Noeud1.Sommet == 4 && l.Noeud2.Sommet == 3));

            Assert.IsNotNull(lien);
            Assert.AreEqual(5.0f, lien.Poids);
        }

        [TestMethod]
        public void TestAlgoDjikstra_DirectPath()
        {
            var (path, time, steps) = graphe.AlgoDjikstra("Chatelet", "Bastille");

            // Assert
            Assert.AreEqual(2, path.Count);
            Assert.AreEqual("Chatelet", path[0]);
            Assert.AreEqual("Bastille", path[1]);
            Assert.AreEqual(3.5, time);
            Assert.AreEqual(1, steps.Count);
        }

        [TestMethod]
        public void TestAlgoDjikstra_MultistepPath()
        {
            var (path, time, steps) = graphe.AlgoDjikstra("Chatelet", "Nation");

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual("Chatelet", path[0]);
            Assert.AreEqual("Bastille", path[1]);
            Assert.AreEqual("Nation", path[2]);
            Assert.AreEqual(7.5, time);
            Assert.AreEqual(2, steps.Count);
        }

        [TestMethod]
        public void TestAlgoDjikstra_WithLineChange()
        {
            var (path, time, steps) = graphe.AlgoDjikstra("Chatelet", "Gare de Lyon");

            Assert.AreEqual(4, path.Count);
            Assert.AreEqual("Chatelet", path[0]);
            Assert.AreEqual("Bastille", path[1]);
            Assert.AreEqual("Gare de Lyon", path[2]);
            Assert.AreEqual("Gare de Lyon", path[3]);

            Assert.AreEqual(8.0, time);
            Assert.AreEqual(3, steps.Count);
        }

        [TestMethod]
        public void TestAlgoBellmanFord()
        {
            var (path, time, steps) = graphe.AlgoBellmanFord("Chatelet", "Nation");

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual("Chatelet", path[0]);
            Assert.AreEqual("Bastille", path[1]);
            Assert.AreEqual("Nation", path[2]);
            Assert.AreEqual(7.5, time);
            Assert.AreEqual(2, steps.Count);
        }

        [TestMethod]
        public void TestAlgoFloydWarshall()
        {
            var allPaths = graphe.AlgoFloydWarshall();

            var pathInfo = allPaths[(1, 3)];
            Assert.AreEqual(7.5, pathInfo.Item1);

            var path = pathInfo.Item2;
            Assert.AreEqual(3, path.Count);
            Assert.AreEqual(1, path[0]);
            Assert.AreEqual(2, path[1]);
            Assert.AreEqual(3, path[2]);
        }

        [TestMethod]
        public void TestTrouverChemin()
        {
            var (path, time, steps) = graphe.TrouverChemin("Chatelet", "Gare de Lyon");

            Assert.IsTrue(path.Count >= 3);
            Assert.AreEqual("Chatelet", path[0]);
            Assert.AreEqual("Gare de Lyon", path[path.Count - 1]);

            Assert.AreEqual(8.0, time);
        }

        [TestMethod]
        public void TestStationNotFound()
        {
            var (path, time, steps) = graphe.AlgoDjikstra("Chatelet", "InvalidStation");

            Assert.AreEqual(0, path.Count);
            Assert.AreEqual(0, time);
            Assert.AreEqual(0, steps.Count);
        }

        [TestMethod]
        public void TestCSVLoading()
        {
            var tempGraphe = new Graphe();
            string tempNodesFile = Path.GetTempFileName();
            string tempEdgesFile = Path.GetTempFileName();

            try
            {
                File.WriteAllText(tempNodesFile,
                    "sommet;ligne;libelle;longitude;latitude;adresse;ville;cp;tempsChangement\n" +
                    "1;1;Chatelet;2.3522;48.8566;Place du Chatelet;Paris;75001;0\n" +
                    "2;1;Bastille;2.3693;48.8531;Place de la Bastille;Paris;75004;0\n");

                File.WriteAllText(tempEdgesFile,
                    "sommet1;ligne1;sommet2;ligne2;temps\n" +
                    "1;1;2;;3.5\n");

                tempGraphe.ChargerNoeudsDepuisCSV(tempNodesFile);
                tempGraphe.ChargerArcsDepuisCSV(tempEdgesFile);

                Assert.AreEqual(2, tempGraphe.Noeuds.Count);
                Assert.AreEqual(1, tempGraphe.Liens.Count);
                Assert.AreEqual("Chatelet", tempGraphe.Noeuds[1].Libelle);
                Assert.AreEqual("Bastille", tempGraphe.Noeuds[2].Libelle);
            }
            finally
            {
                File.Delete(tempNodesFile);
                File.Delete(tempEdgesFile);
            }
        }
    }
}
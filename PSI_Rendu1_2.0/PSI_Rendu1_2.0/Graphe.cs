using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Globalization;
using System.Diagnostics;


[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Test-PSI")]

namespace PSI_Rendu1
{
    public class Graphe
    {
        public Dictionary<int, Noeud> Noeuds { get; private set; } = new Dictionary<int, Noeud>();
        public List<Lien> Liens { get; private set; } = new List<Lien>();
        private Dictionary<int, Dictionary<int, float>> ListeAdjacence = new Dictionary<int, Dictionary<int, float>>();
        private Dictionary<string, SKColor> CouleursLignes = new Dictionary<string, SKColor>
    {
        { "1", new SKColor(255, 206, 0) },
        { "2", new SKColor(0, 24, 168) },
        { "3", new SKColor(149, 121, 0) },
        { "3bis", new SKColor(137, 199, 226) },
        { "4", new SKColor(187, 76, 158) },
        { "5", new SKColor(223, 131, 38) },
        { "6", new SKColor(118, 156, 0) },
        { "7", new SKColor(229, 149, 168) },
        { "7bis", new SKColor(138, 201, 178) },
        { "8", new SKColor(224, 182, 134) },
        { "9", new SKColor(202, 202, 0) },
        { "10", new SKColor(223, 198, 84) },
        { "11", new SKColor(138, 73, 26) },
        { "12", new SKColor(55, 120, 43) },
        { "13", new SKColor(139, 205, 238) },
        { "14", new SKColor(110, 20, 104) },
        { "default", SKColors.Gray }
    };

        /// Obtient la couleur correspondant à l'ID de ligne
        private SKColor ObtenirCouleurLigne(string idLigne)
        {
            if (idLigne != null && CouleursLignes.ContainsKey(idLigne))
            {
                return CouleursLignes[idLigne];
            }
            return CouleursLignes["default"];
        }

        /// Fonction qui permet de créer un lien qui relie 2 sommets avec un poids propre à ce lien
        public void AjouterLien(int sommet1, int sommet2, float poids)
        {
            if (!Noeuds.ContainsKey(sommet1) || !Noeuds.ContainsKey(sommet2)) return;

            Liens.Add(new Lien(Noeuds[sommet1], Noeuds[sommet2], poids));

            if (!ListeAdjacence.ContainsKey(sommet1))
                ListeAdjacence[sommet1] = new Dictionary<int, float>();
            if (!ListeAdjacence.ContainsKey(sommet2))
                ListeAdjacence[sommet2] = new Dictionary<int, float>();

            ListeAdjacence[sommet1][sommet2] = poids;
            ListeAdjacence[sommet2][sommet1] = poids;
        }

        /// Fonction qui permet de créer un Noeud avec toutes les caractéristiques qui le définisse
        public void AjouterNoeud(int sommet, string libelle, double longitude, double latitude, string idLigne, double tempsChangement)
        {
            if (!Noeuds.ContainsKey(sommet))
            {
                Noeuds[sommet] = new Noeud
                (
                    sommet,
                    libelle,
                    longitude,
                    latitude,
                    idLigne,
                    tempsChangement
                );
            }
        }

        /// Fonction qui permet de décrire la liste des noeuds du graphe
        public void DecrireNoeuds()
        {
            Console.WriteLine("Noeuds du graphe :");
            foreach (var noeud in this.Noeuds.Values)
            {
                Console.WriteLine(noeud.Decrire());
            }
        }

        /// Fonction qui permet de décrire la liste des liens du graphe
        public void DecrireLiens()
        {
            Console.WriteLine("Liens du graphe :");
            foreach (var lien in this.Liens)
            {
                Console.WriteLine(lien.Decrire());
            }
        }

        /// Fonction qui permet d'extraire les données du csv et de créer des noeuds avec celles ci
        public void ChargerNoeudsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] Valeurs = line.Split(';');
                    if (Valeurs.Length >= 8)
                    {
                        int sommet = int.Parse(Valeurs[0].Trim());
                        string libelle = Valeurs[2].Trim();
                        double longitude = double.Parse(Valeurs[3].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        double latitude = double.Parse(Valeurs[4].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        string idLigne = Valeurs[1].Trim();
                        double tempsChangement = 0; // Valeur par défaut
                        if (Valeurs.Length > 7 && double.TryParse(Valeurs[8].Trim(), out double temp))
                        {
                            tempsChangement = temp;
                        }

                        AjouterNoeud(sommet, libelle, longitude, latitude, idLigne, tempsChangement);
                    }
                }
            }
        }

        /// Fonction qui permet d'extraire les données du csv et de créer des liens avec celles ci
        public void ChargerArcsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                bool premiereLigne = true;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (premiereLigne)
                    {
                        premiereLigne = false;
                        continue;
                    }

                    string[] Valeurs = line.Split(';');
                    if (Valeurs.Length >= 4)
                    {
                        if (Valeurs[2] == null || Valeurs[2].Length == 0)
                        {
                            continue;
                        }
                        else if (Valeurs[3] == null || Valeurs[3].Length == 0)
                        {
                            int sommet1 = int.Parse(Valeurs[0].Trim());
                            int sommet2 = int.Parse(Valeurs[2].Trim());
                            float poids = float.Parse(Valeurs[4].Trim());
                            AjouterLien(sommet1, sommet2, poids);
                        }
                        else if (Valeurs[2] != null && Valeurs[3] != null && Valeurs[0] != null)
                        {
                            int sommet1 = int.Parse(Valeurs[0].Trim());
                            int sommet2 = int.Parse(Valeurs[2].Trim());
                            int sommet3 = int.Parse(Valeurs[3].Trim());
                            float poids = float.Parse(Valeurs[4].Trim());
                            AjouterLien(sommet1, sommet2, poids);
                            AjouterLien(sommet1, sommet3, poids);
                        }  
                    }
                }
            }
        }

        /// Algorithme de plus court chemin permettant de renvoyer le parcours le plus rapide entre deux stations en utilisant l'algorithme de Djikstra
        public (List<string>, double, List<(string, string, double)>) AlgoDjikstra(string stationDepart, string stationArrivee)
        {
            var distances = new Dictionary<int, double>();
            var predecesseurs = new Dictionary<int, int>();
            var visite = new HashSet<int>();
            var filePriorite = new SortedSet<(double, int)>();
            var sommetsDepart = Noeuds.Values.Where(n => n.Libelle == stationDepart).Select(n => n.Sommet).ToList();
            var sommetsArrivee = Noeuds.Values.Where(n => n.Libelle == stationArrivee).Select(n => n.Sommet).ToList();

            if (!sommetsDepart.Any() || !sommetsArrivee.Any())
            {
                Console.WriteLine("Station de départ ou d'arrivée introuvable.");
                return (new List<string>(), 0, new List<(string, string, double)>());
            }

            foreach (var noeud in Noeuds.Keys)
            {
                distances[noeud] = double.PositiveInfinity;
                predecesseurs[noeud] = -1;
            }

            foreach (var sommet in sommetsDepart)
            {
                distances[sommet] = 0;
                filePriorite.Add((0, sommet));
            }

            while (filePriorite.Count > 0)
            {
                var (distanceActuelle, sommetActuel) = filePriorite.Min;
                filePriorite.Remove(filePriorite.Min);

                if (visite.Contains(sommetActuel)) continue;
                visite.Add(sommetActuel);

                if (sommetsArrivee.Contains(sommetActuel)) break;
                if (!ListeAdjacence.ContainsKey(sommetActuel)) continue;

                foreach (var kvp in ListeAdjacence[sommetActuel])
                {
                    int voisin = kvp.Key;
                    float poids = kvp.Value; 

                    double nouvelleDistance = distanceActuelle + poids;
                    if (nouvelleDistance < distances[voisin])
                    {
                        filePriorite.Remove((distances[voisin], voisin));
                        distances[voisin] = nouvelleDistance;
                        predecesseurs[voisin] = sommetActuel;
                        filePriorite.Add((nouvelleDistance, voisin));
                    }
                }

                foreach (var autreSommet in Noeuds.Values.Where(n => n.Libelle == Noeuds[sommetActuel].Libelle).Select(n => n.Sommet))
                {
                    if (autreSommet != sommetActuel)
                    {
                        double tempsChangement = Noeuds[sommetActuel].TempsChangement;
                        double nouvelleDistance = distanceActuelle + tempsChangement;
                        if (nouvelleDistance < distances[autreSommet])
                        {
                            filePriorite.Remove((distances[autreSommet], autreSommet));
                            distances[autreSommet] = nouvelleDistance;
                            predecesseurs[autreSommet] = sommetActuel;
                            filePriorite.Add((nouvelleDistance, autreSommet));
                        }
                    }
                }
            }

            var chemin = new List<string>();
            var etapes = new List<(string, string, double)>();
            int sommetFinal = sommetsArrivee.OrderBy(s => distances[s]).First();
            double tempsTotal = distances[sommetFinal];

            var sommets = new List<int>();
            int sommetCourant = sommetFinal;
            while (sommetCourant != -1)
            {
                sommets.Add(sommetCourant);
                sommetCourant = predecesseurs[sommetCourant];
            }
            sommets.Reverse();

            for (int i = 0; i < sommets.Count; i++)
            {
                chemin.Add(Noeuds[sommets[i]].Libelle);

                if (i > 0)
                {
                    string stationPrecedente = Noeuds[sommets[i - 1]].Libelle;
                    string stationActuelle = Noeuds[sommets[i]].Libelle;
                    double tempsEtape;

                    if (stationPrecedente == stationActuelle)
                    {
                        tempsEtape = Noeuds[sommets[i - 1]].TempsChangement;
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                    else
                    {
                        tempsEtape = ListeAdjacence[sommets[i - 1]][sommets[i]];
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                }
            }

            return (chemin, tempsTotal, etapes);
        }

        /// Algorithme de plus court chemin permettant de renvoyer le parcours le plus rapide entre deux stations en utilisant l'algorithme de Bellman Ford
        public (List<string>, double, List<(string, string, double)>) AlgoBellmanFord(string stationDepart, string stationArrivee)
        {
            var distances = new Dictionary<int, double>();
            var predecesseurs = new Dictionary<int, int>();
            var sommetsDepart = Noeuds.Values.Where(n => n.Libelle == stationDepart).Select(n => n.Sommet).ToList();
            var sommetsArrivee = Noeuds.Values.Where(n => n.Libelle == stationArrivee).Select(n => n.Sommet).ToList();

            if (!sommetsDepart.Any() || !sommetsArrivee.Any())
            {
                Console.WriteLine("Station de départ ou d'arrivée introuvable.");
                return (new List<string>(), 0, new List<(string, string, double)>());
            }

            foreach (var noeud in Noeuds.Keys)
            {
                distances[noeud] = double.PositiveInfinity;
                predecesseurs[noeud] = -1;
            }

            foreach (var sommet in sommetsDepart)
            {
                distances[sommet] = 0;
            }

            int nombreSommets = Noeuds.Count;
            for (int i = 0; i < nombreSommets - 1; i++)
            {
                bool changement = false;

                foreach (var sommet in ListeAdjacence.Keys)
                {
                    if (distances[sommet] == double.PositiveInfinity) continue;

                    foreach (var kvp in ListeAdjacence[sommet])
                    {
                        int voisin = kvp.Key;
                        float poids = kvp.Value;

                        double nouvelleDistance = distances[sommet] + poids;
                        if (nouvelleDistance < distances[voisin])
                        {
                            distances[voisin] = nouvelleDistance;
                            predecesseurs[voisin] = sommet;
                            changement = true;
                        }
                    }

                    foreach (var autreSommet in Noeuds.Values.Where(n => n.Libelle == Noeuds[sommet].Libelle).Select(n => n.Sommet))
                    {
                        if (autreSommet != sommet)
                        {
                            double tempsChangement = Noeuds[sommet].TempsChangement;
                            double nouvelleDistance = distances[sommet] + tempsChangement;
                            if (nouvelleDistance < distances[autreSommet])
                            {
                                distances[autreSommet] = nouvelleDistance;
                                predecesseurs[autreSommet] = sommet;
                                changement = true;
                            }
                        }
                    }
                }

                if (!changement) break;
            }

            bool cycleNegatif = false;
            foreach (var sommet in ListeAdjacence.Keys)
            {
                foreach (var kvp in ListeAdjacence[sommet])
                {
                    int voisin = kvp.Key;
                    float poids = kvp.Value;

                    if (distances[sommet] != double.PositiveInfinity &&
                        distances[sommet] + poids < distances[voisin])
                    {
                        cycleNegatif = true;
                        break;
                    }
                }
                if (cycleNegatif) break;
            }

            if (cycleNegatif)
            {
                Console.WriteLine("Le graphe contient un cycle négatif.");
                return (new List<string>(), 0, new List<(string, string, double)>());
            }

            int sommetFinal = sommetsArrivee.OrderBy(s => distances[s]).First();
            double tempsTotal = distances[sommetFinal];

            var chemin = new List<string>();
            var etapes = new List<(string, string, double)>();
            var sommets = new List<int>();

            int sommetCourant = sommetFinal;
            while (sommetCourant != -1)
            {
                sommets.Add(sommetCourant);
                sommetCourant = predecesseurs[sommetCourant];
            }
            sommets.Reverse();

            for (int i = 0; i < sommets.Count; i++)
            {
                chemin.Add(Noeuds[sommets[i]].Libelle);

                if (i > 0)
                {
                    string stationPrecedente = Noeuds[sommets[i - 1]].Libelle;
                    string stationActuelle = Noeuds[sommets[i]].Libelle;
                    double tempsEtape;

                    if (stationPrecedente == stationActuelle)
                    {
                        tempsEtape = Noeuds[sommets[i - 1]].TempsChangement;
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                    else
                    {
                        tempsEtape = ListeAdjacence[sommets[i - 1]][sommets[i]];
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                }
            }

            return (chemin, tempsTotal, etapes);
        }

        /// Algo de plus court chemin sur la base de l'algo de Floyd Warshall
        public Dictionary<(int, int), (double, List<int>)> AlgoFloydWarshall()
        {
            var distances = new Dictionary<(int, int), double>();
            var chemins = new Dictionary<(int, int), List<int>>();
            var sommets = Noeuds.Keys.ToList();
            int n = sommets.Count;

            foreach (var i in sommets)
            {
                foreach (var j in sommets)
                {
                    if (i == j)
                    {
                        distances[(i, j)] = 0;
                        chemins[(i, j)] = new List<int> { i };
                    }
                    else
                    {
                        distances[(i, j)] = double.PositiveInfinity;
                        chemins[(i, j)] = new List<int>();
                    }
                }
            }

            foreach (var sommet in sommets)
            {
                if (ListeAdjacence.ContainsKey(sommet))
                {
                    foreach (var kvp in ListeAdjacence[sommet])
                    {
                        int voisin = kvp.Key;
                        float poids = kvp.Value;

                        distances[(sommet, voisin)] = poids;
                        chemins[(sommet, voisin)] = new List<int> { sommet, voisin };
                    }
                }
            }

            foreach (var sommet1 in sommets)
            {
                foreach (var sommet2 in sommets)
                {
                    if (sommet1 != sommet2 &&
                        Noeuds.ContainsKey(sommet1) &&
                        Noeuds.ContainsKey(sommet2) &&
                        Noeuds[sommet1].Libelle == Noeuds[sommet2].Libelle)
                    {
                        double tempsChangement = Noeuds[sommet1].TempsChangement;
                        if (tempsChangement < distances[(sommet1, sommet2)])
                        {
                            distances[(sommet1, sommet2)] = tempsChangement;
                            chemins[(sommet1, sommet2)] = new List<int> { sommet1, sommet2 };
                        }
                    }
                }
            }

            foreach (var k in sommets)
            {
                foreach (var i in sommets)
                {
                    foreach (var j in sommets)
                    {
                        if (distances[(i, k)] + distances[(k, j)] < distances[(i, j)])
                        {
                            distances[(i, j)] = distances[(i, k)] + distances[(k, j)];

                            var nouveauChemin = new List<int>();
                            nouveauChemin.AddRange(chemins[(i, k)].Take(chemins[(i, k)].Count - 1));
                            nouveauChemin.AddRange(chemins[(k, j)]);
                            chemins[(i, j)] = nouveauChemin;
                        }
                    }
                }
            }

            var resultat = new Dictionary<(int, int), (double, List<int>)>();
            foreach (var key in distances.Keys)
            {
                resultat[key] = (distances[key], chemins[key]);
            }
            return resultat;
        }

        /// Fonction qui permet de trouver le chemin à partir des données obtenues grâce à l'algo de Floyd Warshall
        public (List<string>, double, List<(string, string, double)>) TrouverChemin(string stationDepart, string stationArrivee)
        {
            var sommetsDepart = Noeuds.Values.Where(n => n.Libelle == stationDepart).Select(n => n.Sommet).ToList();
            var sommetsArrivee = Noeuds.Values.Where(n => n.Libelle == stationArrivee).Select(n => n.Sommet).ToList();

            if (!sommetsDepart.Any() || !sommetsArrivee.Any())
            {
                Console.WriteLine("Station de départ ou d'arrivée introuvable.");
                return (new List<string>(), 0, new List<(string, string, double)>());
            }

            var tousChemins = AlgoFloydWarshall();

            double meilleurTemps = double.PositiveInfinity;
            List<int> meilleurChemin = null;

            foreach (var depart in sommetsDepart)
            {
                foreach (var arrivee in sommetsArrivee)
                {
                    if (tousChemins.ContainsKey((depart, arrivee)))
                    {
                        var (temps, chemin) = tousChemins[(depart, arrivee)];
                        if (temps < meilleurTemps)
                        {
                            meilleurTemps = temps;
                            meilleurChemin = chemin;
                        }
                    }
                }
            }

            if (meilleurChemin == null)
            {
                Console.WriteLine("Aucun chemin trouvé entre ces stations.");
                return (new List<string>(), 0, new List<(string, string, double)>());
            }

            var stations = new List<string>();
            var etapes = new List<(string, string, double)>();

            for (int i = 0; i < meilleurChemin.Count; i++)
            {
                int sommet = meilleurChemin[i];
                stations.Add(Noeuds[sommet].Libelle);

                if (i > 0)
                {
                    int sommetPrecedent = meilleurChemin[i - 1];
                    string stationPrecedente = Noeuds[sommetPrecedent].Libelle;
                    string stationActuelle = Noeuds[sommet].Libelle;
                    double tempsEtape;

                    if (stationPrecedente == stationActuelle)
                    {
                        tempsEtape = Noeuds[sommetPrecedent].TempsChangement;
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                    else
                    {
                        tempsEtape = ListeAdjacence[sommetPrecedent][sommet];
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                }
            }

            return (stations, meilleurTemps, etapes);
        }

        /// Fonction qui permet de comparer le temps d'exécution des trois algos de plus court chemin
        public void ComparerAlgorithmes(string depart, string arrivee)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var dijkstraResult = AlgoDjikstra(depart, arrivee);
            stopwatch.Stop();
            long dijkstraTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Temps d'exécution de Dijkstra : {dijkstraTime} ms");

            stopwatch.Restart();
            var bellmanfordResult = AlgoBellmanFord(depart, arrivee);
            stopwatch.Stop();
            long bellmanfordTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Temps d'exécution de Bellman-Ford : {bellmanfordTime} ms");

            stopwatch.Restart();
            var floydwarshallResult = TrouverChemin(depart, arrivee);
            stopwatch.Stop();
            long floydwarshallTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Temps d'exécution de Floyd-Warshall : {floydwarshallTime} ms");
        }


        ///Fonction VisualiserGraphe qui permet de créer le graphe grâce à SkiaSharp
        public void VisualiserGraphe(string filePath)
        {
            int largeur = 800;
            int hauteur = 800;
            using (SKBitmap bitmap = new SKBitmap(largeur, hauteur))
            using (SKCanvas canvas = new SKCanvas(bitmap))
            using (SKPaint paintNoeud = new SKPaint { Style = SKPaintStyle.Fill })
            using (SKPaint paintLien = new SKPaint { Style = SKPaintStyle.Stroke, StrokeWidth = 3 })
            using (SKPaint paintTexte = new SKPaint { Color = SKColors.Black, TextSize = 12 })
            using (SKPaint paintFond = new SKPaint { Color = SKColors.White.WithAlpha(200), Style = SKPaintStyle.Fill })
            using (SKPaint paintPoids = new SKPaint { Color = SKColors.DarkGray, TextSize = 10 })
            {
                canvas.Clear(SKColors.White);

                /// Trouver les limites des coordonnées pour la mise à l'échelle
                double minLat = Noeuds.Values.Min(n => n.Latitude);
                double maxLat = Noeuds.Values.Max(n => n.Latitude);
                double minLon = Noeuds.Values.Min(n => n.Longitude);
                double maxLon = Noeuds.Values.Max(n => n.Longitude);

                /// Ajouter une marge
                double marge = 0.05;
                double latRange = maxLat - minLat;
                double lonRange = maxLon - minLon;
                minLat -= latRange * marge;
                maxLat += latRange * marge;
                minLon -= lonRange * marge;
                maxLon += lonRange * marge;

                /// Calculer les positions de chaque nœud
                Dictionary<int, SKPoint> positions = new Dictionary<int, SKPoint>();
                foreach (var noeud in Noeuds.Values)
                {
                    /// Conversion des coordonnées géographiques en pixels
                    float x = (float)((noeud.Longitude - minLon) / (maxLon - minLon) * largeur);
                    /// Inversion de l'axe Y pour placer le nord en haut
                    float y = (float)((1 - (noeud.Latitude - minLat) / (maxLat - minLat)) * hauteur);
                    positions[noeud.Sommet] = new SKPoint(x, y);
                }

                /// Dessiner les liens
                foreach (var lien in Liens)
                {
                    SKPoint point1 = positions[lien.Noeud1.Sommet];
                    SKPoint point2 = positions[lien.Noeud2.Sommet];

                    /// Utiliser la couleur correspondant à la ligne
                    string idLigne = lien.Noeud1.IdLigne;

                    if (CouleursLignes.ContainsKey(idLigne))
                    {
                        paintLien.Color = CouleursLignes[idLigne];
                    }
                    else
                    {
                        paintLien.Color = SKColors.Gray;
                    }

                    canvas.DrawLine(point1, point2, paintLien);

                    /// Afficher le poids au milieu de l'arc
                    /*if (lien.Poids > 0)
                    {
                        float midX = (point1.X + point2.X) / 2;
                        float midY = (point1.Y + point2.Y) / 2;
                        string poidsText = lien.Poids.ToString();

                        using (SKPaint circlePaint = new SKPaint { Color = SKColors.White, Style = SKPaintStyle.Fill })
                        {
                            canvas.DrawCircle(midX, midY, 8, circlePaint);
                        }

                        SKRect textBounds = new SKRect();
                        paintPoids.MeasureText(poidsText, ref textBounds);
                        canvas.DrawText(poidsText, midX - textBounds.Width / 2, midY + textBounds.Height / 2, paintPoids);
                    }*/
                }

                /// Dessiner les nœuds et le nom des stations
                foreach (var noeud in Noeuds.Values)
                {
                    SKPoint position = positions[noeud.Sommet];

                    string idLigne = noeud.IdLigne;
                    if (CouleursLignes.ContainsKey(idLigne))
                    {
                        paintNoeud.Color = CouleursLignes[idLigne];
                    }
                    else
                    {
                        paintNoeud.Color = SKColors.Black;
                    }

                    canvas.DrawCircle(position, 3, paintNoeud);

                    string libelle = noeud.Libelle;
                    SKRect textBounds = new SKRect();
                    paintTexte.MeasureText(libelle, ref textBounds);

                    float textX = position.X + 7;
                    float textY = position.Y + 5;

                    /// Dessiner le texte (en commentaire car peu lisible avec les libellés)
                    /*SKRect fondRect = new SKRect(
                        textX - 2,
                        textY - textBounds.Height - 2,
                        textX + textBounds.Width + 2,
                        textY + 2
                    );
                    canvas.DrawRect(fondRect, paintFond);

                    canvas.DrawText(libelle, textX, textY, paintTexte);
                    canvas.DrawText("L" + idLigne, textX, textY + textBounds.Height + 5, paintPoids);*/
                }

                /// Sauvegarder l'image
                using (SKFileWStream fs = new SKFileWStream(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }
        }

        public void VisualiserChemin(string stationDepart, string stationArrivee, string cheminFichier)
        {
            var (itineraire, tempsTotal, etapes) = AlgoDjikstra(stationDepart, stationArrivee);
            /// On peut aussi utiliser AlgoBellmanFord à la place de AlgoDjikstra mais Djikstra plus rapide d'après la fonction ComparerAlgorithme

            if (itineraire.Count == 0)
            {
                Console.WriteLine("Aucun chemin trouvé entre ces stations.");
                return;
            }

            var styleTexteStation = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 16,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center
            };

            int largeurImage = 1200;
            float maxTextWidth = itineraire.Max(nom => styleTexteStation.MeasureText(nom));
            int hauteurImage = (int)(maxTextWidth + 150);
            int margeHorizontale = 100;
            int margeVerticale = 100;

            int largeurDisponible = largeurImage - (2 * margeHorizontale);
            int hauteurDisponible = hauteurImage - (2 * margeVerticale);

            float espacementHorizontal = largeurDisponible / (float)(itineraire.Count - 1);

            using (var surface = SKSurface.Create(new SKImageInfo(largeurImage, hauteurImage)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                var styleLigne = new SKPaint
                {
                    Color = SKColors.DarkGray,
                    StrokeWidth = 3,
                    IsAntialias = true,
                    Style = SKPaintStyle.Stroke
                };

                var styleNoeud = new SKPaint
                {
                    Color = SKColors.DodgerBlue,
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill
                };

                var styleChangementLigne = new SKPaint
                {
                    Color = SKColors.Orange,
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill
                };            

                var styleTextePoids = new SKPaint
                {
                    Color = SKColors.Red,
                    TextSize = 14,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center
                };

                var styleTexteTotal = new SKPaint
                {
                    Color = SKColors.DarkBlue,
                    TextSize = 18,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center,
                    FakeBoldText = true
                };

                float posY = hauteurImage / 2;

                /// Tracer le chemin et les nœuds
                for (int i = 0; i < itineraire.Count; i++)
                {
                    float posX = margeHorizontale + (i * espacementHorizontal);

                    if (i > 0)
                    {
                        float posXPrecedent = margeHorizontale + ((i - 1) * espacementHorizontal);
                        canvas.DrawLine(posXPrecedent, posY, posX, posY, styleLigne);

                        float posXMilieu = (posXPrecedent + posX) / 2;
                        double temps = etapes[i - 1].Item3; // Temps pour cette étape
                        canvas.DrawText($"{temps:F1} min", posXMilieu, posY - 15, styleTextePoids);
                    }

                    bool estChangementLigne = (i > 0 && itineraire[i] == itineraire[i - 1]);

                    float rayonNoeud = estChangementLigne ? 12 : 10;
                    canvas.DrawCircle(posX, posY, rayonNoeud, estChangementLigne ? styleChangementLigne : styleNoeud);

                    canvas.Save();

                    string texte = itineraire[i];

                    // Mesurer la largeur du texte (en horizontal, avant rotation)
                    float textWidth = styleTexteStation.MeasureText(texte);

                    // Position du cercle (station)
                    float rotationX = posX;
                    float rotationY = posY;

                    // Translation jusqu’au cercle
                    canvas.Translate(rotationX, rotationY);

                    // Rotation antihoraire (texte vertical, haut vers bas)
                    canvas.RotateDegrees(-90);

                    // Décalage pour que le texte soit centré sur le cercle
                    // Le texte est maintenant horizontal mais orienté verticalement à l’écran
                    canvas.Translate(-textWidth / 2, 35);  // 35 pixels = espace entre cercle et début du texte

                    // Dessin du texte
                    canvas.DrawText(texte, -20, -30, styleTexteStation);

                    canvas.Restore();

                }
                canvas.DrawText($"Temps total : {tempsTotal:F1} minutes", largeurImage / 2, 30, styleTexteTotal);

                /// Légende
                float posXLegende = largeurImage - 300;
                float posYLegende = 40;

                // Légende pour "Station"
                canvas.DrawCircle(posXLegende, posYLegende, 10, styleNoeud);
                canvas.DrawText("Station", posXLegende + 40, posYLegende + 5, styleTexteStation);

                // Légende pour "Changement de ligne"
                canvas.DrawCircle(posXLegende, posYLegende + 30, 12, styleChangementLigne);
                canvas.DrawText("Changement de ligne", posXLegende + 90, posYLegende + 35, styleTexteStation);

                /// Sauvegarder l'image
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite(cheminFichier))
                {
                    data.SaveTo(stream);
                }

                Console.WriteLine($"Visualisation du chemin sauvegardée sous : {cheminFichier}");
            }
        }
    }
}


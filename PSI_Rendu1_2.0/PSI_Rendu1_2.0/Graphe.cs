using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Globalization;


[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Test-PSI")]

namespace PSI_Rendu1
{
    internal class Graphe
    {
        public Dictionary<int, Noeud> Noeuds { get; private set; } = new Dictionary<int, Noeud>();
        public List<Lien> Liens { get; private set; } = new List<Lien>();
        private Dictionary<int, Dictionary<int, float>> ListeAdjacence = new Dictionary<int, Dictionary<int, float>>();
        private Dictionary<string, SKColor> CouleursLignes = new Dictionary<string, SKColor>
    {
        { "1", new SKColor(255, 206, 0) },     // Jaune
        { "2", new SKColor(0, 24, 168) },      // Bleu foncé
        { "3", new SKColor(149, 121, 0) },     // Olive
        { "3bis", new SKColor(137, 199, 226) },// Bleu ciel
        { "4", new SKColor(187, 76, 158) },    // Magenta
        { "5", new SKColor(223, 131, 38) },    // Orange
        { "6", new SKColor(118, 156, 0) },     // Vert lime
        { "7", new SKColor(229, 149, 168) },   // Rose
        { "7bis", new SKColor(138, 201, 178) },// Turquoise
        { "8", new SKColor(224, 182, 134) },   // Beige
        { "9", new SKColor(202, 202, 0) },     // Jaune-vert
        { "10", new SKColor(223, 198, 84) },   // Jaune doré
        { "11", new SKColor(138, 73, 26) },    // Marron
        { "12", new SKColor(55, 120, 43) },    // Vert foncé
        { "13", new SKColor(139, 205, 238) },  // Bleu clair
        { "14", new SKColor(110, 20, 104) },   // Violet
        // Couleur par défaut
        { "default", SKColors.Gray }
    };

        // Obtient la couleur correspondant à l'ID de ligne
        private SKColor ObtenirCouleurLigne(string idLigne)
        {
            if (idLigne != null && CouleursLignes.ContainsKey(idLigne))
            {
                return CouleursLignes[idLigne];
            }
            return CouleursLignes["default"];
        }

        public void AjouterLien(int sommet1, int sommet2, float poids)
        {
            if (!Noeuds.ContainsKey(sommet1) || !Noeuds.ContainsKey(sommet2)) return;

            // Ajouter le lien
            Liens.Add(new Lien(Noeuds[sommet1], Noeuds[sommet2], poids));

            // Modifier la structure de la liste d'adjacence pour inclure les poids
            // On utilise maintenant un dictionnaire de dictionnaires: sommet -> (voisin -> poids)
            if (!ListeAdjacence.ContainsKey(sommet1))
                ListeAdjacence[sommet1] = new Dictionary<int, float>();
            if (!ListeAdjacence.ContainsKey(sommet2))
                ListeAdjacence[sommet2] = new Dictionary<int, float>();

            // Ajouter les arêtes avec leur poids dans les deux directions (graphe non orienté)
            ListeAdjacence[sommet1][sommet2] = poids;
            ListeAdjacence[sommet2][sommet1] = poids;
        }

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

        /*public void AnalyserGraphe()
        {
            int ordre = Noeuds.Count;
            int taille = Liens.Count;
            bool estOriente = false; /// Par défaut d'après le fichier donné en annexe
            bool estPondere = false; /// De même
            bool estConnexeBFS = EstConnexeBFS();
            bool estConnexeDFS = EstConnexeDFS();

            Console.WriteLine($"Ordre du graphe: {ordre}");
            Console.WriteLine($"Taille du graphe: {taille}");
            Console.WriteLine($"Graphe orienté: {estOriente}");
            Console.WriteLine($"Graphe pondéré: {estPondere}");
            Console.WriteLine($"Graphe connexe (BFS): {estConnexeBFS}");
            Console.WriteLine($"Graphe connexe (DFS): {estConnexeDFS}");
        }*/


        /*public void ChargerArcsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(';');
                    if (tokens.Length >= 2)
                    {
                        T sommet1 = (T)Convert.ChangeType(tokens[0].Trim(), typeof(T));
                        T sommet2 = (T)Convert.ChangeType(tokens[1].Trim(), typeof(T));
                        AjouterLien(sommet1, sommet2);
                    }
                }
            }
        }

        public HashSet<T> ParcoursBFS(T sommetDepart)
        {
            HashSet<T> visites = new HashSet<T>();
            Queue<T> file = new Queue<T>();

            file.Enqueue(sommetDepart);

            while (file.Count > 0)
            {
                T sommet = file.Dequeue();
                if (!visites.Contains(sommet))
                {
                    visites.Add(sommet);
                    if (ListeAdjacence.ContainsKey(sommet))
                    {
                        foreach (T voisin in ListeAdjacence[sommet])
                        {
                            if (!visites.Contains(voisin))
                            {
                                file.Enqueue(voisin);
                            }
                        }
                    }
                }
            }
            return visites;
        }

        public bool EstConnexeBFS()
        {
            if (Noeuds.Count == 0) return false;

            T premierSommet = Noeuds.Keys.First();
            HashSet<T> visites = ParcoursBFS(premierSommet);

            return visites.Count == Noeuds.Count;
        }

        public HashSet<T> ParcoursDFS(T sommetDepart)
        {
            HashSet<T> visites = new HashSet<T>();
            Stack<T> pile = new Stack<T>();

            pile.Push(sommetDepart);

            while (pile.Count > 0)
            {
                T sommet = pile.Pop();
                if (!visites.Contains(sommet))
                {
                    visites.Add(sommet);
                    if (ListeAdjacence.ContainsKey(sommet))
                    {
                        foreach (T voisin in ListeAdjacence[sommet])
                        {
                            if (!visites.Contains(voisin))
                            {
                                pile.Push(voisin);
                            }
                        }
                    }
                }
            }
            return visites;
        }

        public bool EstConnexeDFS()
        {
            if (Noeuds.Count == 0) return false;

            T premierSommet = Noeuds.Keys.First();
            HashSet<T> visites = ParcoursDFS(premierSommet);

            return visites.Count == Noeuds.Count;
        }*/


        public void DecrireNoeuds()
        {
            Console.WriteLine("Noeuds du graphe :");
            foreach (var noeud in this.Noeuds.Values)
            {
                Console.WriteLine(noeud.Decrire());
            }
        }

        public void DecrireLiens()
        {
            Console.WriteLine("Liens du graphe :");
            foreach (var lien in this.Liens)
            {
                Console.WriteLine(lien.Decrire());
            }
        }




        public void ChargerNoeudsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine(); // Ignorer l'en-tête
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(';');
                    if (tokens.Length >= 8)
                    {
                        int sommet = int.Parse(tokens[0].Trim());
                        string libelle = tokens[2].Trim();
                        double longitude = double.Parse(tokens[3].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        double latitude = double.Parse(tokens[4].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        string idLigne = tokens[1].Trim();
                        double tempsChangement = 0; // Valeur par défaut
                        if (tokens.Length > 8 && double.TryParse(tokens[8].Trim(), out double temp))
                        {
                            tempsChangement = temp;
                        }

                        AjouterNoeud(sommet, libelle, longitude, latitude, idLigne, tempsChangement);
                    }
                }
            }
        }

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

                    string[] tokens = line.Split(';');
                    if (tokens.Length >= 4)
                    {
                        if (tokens[2] == null || tokens[2].Length == 0)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet3 = int.Parse(tokens[3].Trim());
                            //AjouterLien(sommet1, sommet3);
                        }
                        else if (tokens[3] == null || tokens[3].Length == 0)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet2 = int.Parse(tokens[2].Trim());
                            float poids = float.Parse(tokens[4].Trim());
                            AjouterLien(sommet1, sommet2, poids);
                        }
                        else if (tokens[2] != null && tokens[3] != null && tokens[0] != null)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet2 = int.Parse(tokens[2].Trim());
                            int sommet3 = int.Parse(tokens[3].Trim());
                            float poids = float.Parse(tokens[4].Trim());
                            AjouterLien(sommet1, sommet2, poids);
                            AjouterLien(sommet1, sommet3, poids);
                        }  
                    }
                }
            }
        }


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
                    float poids = kvp.Value; // Temps réel entre les stations

                    double nouvelleDistance = distanceActuelle + poids;
                    if (nouvelleDistance < distances[voisin])
                    {
                        filePriorite.Remove((distances[voisin], voisin));
                        distances[voisin] = nouvelleDistance;
                        predecesseurs[voisin] = sommetActuel;
                        filePriorite.Add((nouvelleDistance, voisin));
                    }
                }

                // Gestion du changement de ligne avec prise en compte du temps
                foreach (var autreSommet in Noeuds.Values.Where(n => n.Libelle == Noeuds[sommetActuel].Libelle).Select(n => n.Sommet))
                {
                    if (autreSommet != sommetActuel)
                    {
                        double tempsChangement = Noeuds[sommetActuel].TempsChangement; // Récupération du temps de changement
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
            double tempsTotal = distances[sommetFinal]; // Récupération du temps total

            // Construction du chemin en sens inverse et calcul des durées d'étapes
            var sommets = new List<int>();
            int sommetCourant = sommetFinal;
            while (sommetCourant != -1)
            {
                sommets.Add(sommetCourant);
                sommetCourant = predecesseurs[sommetCourant];
            }
            sommets.Reverse();

            // Construction de la liste des étapes avec les délais
            for (int i = 0; i < sommets.Count; i++)
            {
                chemin.Add(Noeuds[sommets[i]].Libelle);

                if (i > 0)
                {
                    string stationPrecedente = Noeuds[sommets[i - 1]].Libelle;
                    string stationActuelle = Noeuds[sommets[i]].Libelle;
                    double tempsEtape;

                    // Vérifier si c'est un changement de ligne (même nom de station)
                    if (stationPrecedente == stationActuelle)
                    {
                        tempsEtape = Noeuds[sommets[i - 1]].TempsChangement;
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                    else
                    {
                        // Récupérer le poids réel (temps) entre les deux stations
                        tempsEtape = ListeAdjacence[sommets[i - 1]][sommets[i]];
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                }
            }

            return (chemin, tempsTotal, etapes);
        }


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

            // Initialisation
            foreach (var noeud in Noeuds.Keys)
            {
                distances[noeud] = double.PositiveInfinity;
                predecesseurs[noeud] = -1;
            }

            foreach (var sommet in sommetsDepart)
            {
                distances[sommet] = 0;
            }

            // Relaxation des arêtes V-1 fois (V étant le nombre de sommets)
            int nombreSommets = Noeuds.Count;
            for (int i = 0; i < nombreSommets - 1; i++)
            {
                bool changement = false;

                // Parcourir toutes les arêtes (connections entre stations)
                foreach (var sommet in ListeAdjacence.Keys)
                {
                    if (distances[sommet] == double.PositiveInfinity) continue;

                    // Parcourir les voisins avec leurs poids
                    foreach (var kvp in ListeAdjacence[sommet])
                    {
                        int voisin = kvp.Key;
                        float poids = kvp.Value; // Temps réel entre les stations

                        double nouvelleDistance = distances[sommet] + poids;
                        if (nouvelleDistance < distances[voisin])
                        {
                            distances[voisin] = nouvelleDistance;
                            predecesseurs[voisin] = sommet;
                            changement = true;
                        }
                    }

                    // Gestion du changement de ligne
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

                // Si aucun changement dans cette itération, on peut s'arrêter
                if (!changement) break;
            }

            // Vérification des cycles négatifs (optionnel, peut être omis si on sait qu'il n'y en a pas)
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

            // Trouver le sommet d'arrivée avec la distance minimale
            int sommetFinal = sommetsArrivee.OrderBy(s => distances[s]).First();
            double tempsTotal = distances[sommetFinal];

            // Reconstitution du chemin
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

            // Construction de la liste des étapes avec les délais
            for (int i = 0; i < sommets.Count; i++)
            {
                chemin.Add(Noeuds[sommets[i]].Libelle);

                if (i > 0)
                {
                    string stationPrecedente = Noeuds[sommets[i - 1]].Libelle;
                    string stationActuelle = Noeuds[sommets[i]].Libelle;
                    double tempsEtape;

                    // Vérifier si c'est un changement de ligne (même nom de station)
                    if (stationPrecedente == stationActuelle)
                    {
                        tempsEtape = Noeuds[sommets[i - 1]].TempsChangement;
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                    else
                    {
                        // Récupérer le poids réel (temps) entre les deux stations
                        tempsEtape = ListeAdjacence[sommets[i - 1]][sommets[i]];
                        etapes.Add((stationPrecedente, stationActuelle, tempsEtape));
                    }
                }
            }

            return (chemin, tempsTotal, etapes);
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
                // Effacer le canvas avec un fond blanc
                canvas.Clear(SKColors.White);

                // Trouver les limites des coordonnées pour la mise à l'échelle
                double minLat = Noeuds.Values.Min(n => n.Latitude);
                double maxLat = Noeuds.Values.Max(n => n.Latitude);
                double minLon = Noeuds.Values.Min(n => n.Longitude);
                double maxLon = Noeuds.Values.Max(n => n.Longitude);

                // Ajouter une marge
                double marge = 0.05;
                double latRange = maxLat - minLat;
                double lonRange = maxLon - minLon;
                minLat -= latRange * marge;
                maxLat += latRange * marge;
                minLon -= lonRange * marge;
                maxLon += lonRange * marge;

                // Calculer les positions de chaque nœud
                Dictionary<int, SKPoint> positions = new Dictionary<int, SKPoint>();
                foreach (var noeud in Noeuds.Values)
                {
                    // Conversion des coordonnées géographiques en pixels
                    float x = (float)((noeud.Longitude - minLon) / (maxLon - minLon) * largeur);
                    // Inversion de l'axe Y pour placer le nord en haut
                    float y = (float)((1 - (noeud.Latitude - minLat) / (maxLat - minLat)) * hauteur);
                    positions[noeud.Sommet] = new SKPoint(x, y);
                }

                // Dessiner d'abord les liens (pour qu'ils soient sous les nœuds)
                foreach (var lien in Liens)
                {
                    SKPoint point1 = positions[lien.Noeud1.Sommet];
                    SKPoint point2 = positions[lien.Noeud2.Sommet];

                    // Utiliser la couleur correspondant à la ligne du premier nœud
                    // (on suppose que les nœuds connectés sont généralement sur la même ligne)
                    string idLigne = lien.Noeud1.IdLigne;

                    if (CouleursLignes.ContainsKey(idLigne))
                    {
                        paintLien.Color = CouleursLignes[idLigne];
                    }
                    else
                    {
                        paintLien.Color = SKColors.Gray; // Couleur par défaut
                    }

                    canvas.DrawLine(point1, point2, paintLien);

                    // Afficher la pondération au milieu de l'arc
                    if (lien.Poids > 0)
                    {
                        float midX = (point1.X + point2.X) / 2;
                        float midY = (point1.Y + point2.Y) / 2;
                        string poidsText = lien.Poids.ToString();

                        // Cercle blanc derrière le texte pour plus de lisibilité
                        using (SKPaint circlePaint = new SKPaint { Color = SKColors.White, Style = SKPaintStyle.Fill })
                        {
                            canvas.DrawCircle(midX, midY, 8, circlePaint);
                        }

                        // Mesurer les dimensions du texte pour le centrer
                        SKRect textBounds = new SKRect();
                        paintPoids.MeasureText(poidsText, ref textBounds);
                        canvas.DrawText(poidsText, midX - textBounds.Width / 2, midY + textBounds.Height / 2, paintPoids);
                    }
                }

                // Dessiner les nœuds et leurs libellés
                foreach (var noeud in Noeuds.Values)
                {
                    SKPoint position = positions[noeud.Sommet];

                    // Choisir la couleur du nœud en fonction de l'ID de ligne
                    string idLigne = noeud.IdLigne;
                    if (CouleursLignes.ContainsKey(idLigne))
                    {
                        paintNoeud.Color = CouleursLignes[idLigne];
                    }
                    else
                    {
                        paintNoeud.Color = SKColors.Black; // Couleur par défaut
                    }

                    // Dessiner le cercle représentant la station
                    canvas.DrawCircle(position, 3, paintNoeud);

                    // Mesurer les dimensions du texte pour le fond
                    string libelle = noeud.Libelle;
                    SKRect textBounds = new SKRect();
                    paintTexte.MeasureText(libelle, ref textBounds);

                    // Position du texte
                    float textX = position.X + 7;
                    float textY = position.Y + 5;

                    // Dessiner un fond semi-transparent pour le texte
                    /*SKRect fondRect = new SKRect(
                        textX - 2,
                        textY - textBounds.Height - 2,
                        textX + textBounds.Width + 2,
                        textY + 2
                    );
                    canvas.DrawRect(fondRect, paintFond);*/

                    // Dessiner le libellé de la station
                    //canvas.DrawText(libelle, textX, textY, paintTexte);

                    // Option: Afficher l'ID de ligne à côté du nom de la station
                    // canvas.DrawText("L" + idLigne, textX, textY + textBounds.Height + 5, paintPoids);
                }

                // Sauvegarder l'image
                using (SKFileWStream fs = new SKFileWStream(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }
        }

        public void VisualiserChemin(string stationDepart, string stationArrivee, string cheminFichier)
        {
            // Récupérer le chemin optimal et ses informations
            var (itineraire, tempsTotal, etapes) = AlgoDjikstra(stationDepart, stationArrivee);
            // On peut aussi utiliser AlgoBellmanFord à la place de AlgoDjikstra

            if (itineraire.Count == 0)
            {
                Console.WriteLine("Aucun chemin trouvé entre ces stations.");
                return;
            }

            // Paramètres de l'image
            int largeurImage = 1200;
            int hauteurImage = 300;
            int margeHorizontale = 100;
            int margeVerticale = 100;

            // Calcul de l'espace disponible pour le tracé
            int largeurDisponible = largeurImage - (2 * margeHorizontale);
            int hauteurDisponible = hauteurImage - (2 * margeVerticale);

            // Calcul de l'espacement entre les nœuds
            float espacementHorizontal = largeurDisponible / (float)(itineraire.Count - 1);

            // Création de la surface de dessin
            using (var surface = SKSurface.Create(new SKImageInfo(largeurImage, hauteurImage)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                // Définition des styles
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

                var styleTexteStation = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 16,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center
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

                // Position de départ
                float posY = hauteurImage / 2;

                // Tracer le chemin et les nœuds
                for (int i = 0; i < itineraire.Count; i++)
                {
                    float posX = margeHorizontale + (i * espacementHorizontal);

                    // Tracer la ligne entre les nœuds
                    if (i > 0)
                    {
                        float posXPrecedent = margeHorizontale + ((i - 1) * espacementHorizontal);
                        canvas.DrawLine(posXPrecedent, posY, posX, posY, styleLigne);

                        // Afficher le poids (temps) au-dessus de la ligne
                        float posXMilieu = (posXPrecedent + posX) / 2;
                        double temps = etapes[i - 1].Item3; // Temps pour cette étape
                        canvas.DrawText($"{temps:F1} min", posXMilieu, posY - 15, styleTextePoids);
                    }

                    // Déterminer si c'est un changement de ligne
                    bool estChangementLigne = (i > 0 && itineraire[i] == itineraire[i - 1]);

                    // Tracer le nœud
                    float rayonNoeud = estChangementLigne ? 12 : 10;
                    canvas.DrawCircle(posX, posY, rayonNoeud, estChangementLigne ? styleChangementLigne : styleNoeud);

                    // Afficher le nom de la station
                    canvas.DrawText(itineraire[i], posX, posY + 30, styleTexteStation);

                    // Pour les nœuds de changement de ligne, ajouter une indication
                    if (estChangementLigne)
                    {
                        canvas.DrawText("(Changement)", posX, posY + 50, styleTexteStation);
                    }
                }

                // Afficher le temps total en haut de l'image
                canvas.DrawText($"Temps total : {tempsTotal:F1} minutes", largeurImage / 2, 40, styleTexteTotal);

                // Ajouter une légende
                float posXLegende = 30;
                float posYLegende = hauteurImage - 50;

                // Légende pour les stations normales
                canvas.DrawCircle(posXLegende, posYLegende, 10, styleNoeud);
                canvas.DrawText("Station", posXLegende + 50, posYLegende + 5, styleTexteStation);

                // Légende pour les changements de ligne
                canvas.DrawCircle(posXLegende + 150, posYLegende, 12, styleChangementLigne);
                canvas.DrawText("Changement de ligne", posXLegende + 250, posYLegende + 5, styleTexteStation);

                // Sauvegarder l'image
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


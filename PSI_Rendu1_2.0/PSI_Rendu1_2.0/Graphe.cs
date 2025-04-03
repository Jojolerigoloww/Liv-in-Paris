using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using System.Drawing;
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
        public Dictionary<int, List<int>> ListeAdjacence { get; private set; } = new Dictionary<int, List<int>>();
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

        public void AjouterLien(int sommet1, int sommet2)
        {
            if (!Noeuds.ContainsKey(sommet1) || !Noeuds.ContainsKey(sommet2)) return;

            Liens.Add(new Lien(Noeuds[sommet1], Noeuds[sommet2]));

            if (!ListeAdjacence.ContainsKey(sommet1)) ListeAdjacence[sommet1] = new List<int>();
            if (!ListeAdjacence.ContainsKey(sommet2)) ListeAdjacence[sommet2] = new List<int>();

            ListeAdjacence[sommet1].Add(sommet2);
            ListeAdjacence[sommet2].Add(sommet1);
        }

        public void AjouterNoeud(int sommet, string libelle, double longitude, double latitude, string idLigne = "default")
        {
            if (!Noeuds.ContainsKey(sommet))
            {
                Noeuds[sommet] = new Noeud
                (
                    sommet,
                    libelle,
                    longitude,
                    latitude,
                    idLigne
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
                    if (tokens.Length >= 5) // Au moins 6 colonnes pour inclure l'ID de ligne
                    {
                        int sommet = int.Parse(tokens[0].Trim());
                        string libelle = tokens[2].Trim();
                        double longitude = double.Parse(tokens[3].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        double latitude = double.Parse(tokens[4].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        string idLigne = tokens[1].Trim();

                        AjouterNoeud(sommet, libelle, longitude, latitude, idLigne);
                    }
                    else if (tokens.Length >= 4) // Rétrocompatibilité avec l'ancien format sans ID de ligne
                    {
                        int sommet = int.Parse(tokens[0].Trim());
                        string libelle = tokens[2].Trim();
                        double longitude = double.Parse(tokens[3].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);
                        double latitude = double.Parse(tokens[4].Trim().Replace("\uFEFF", ""), CultureInfo.InvariantCulture);

                        AjouterNoeud(sommet, libelle, longitude, latitude, "default");
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
                    if (tokens.Length >= 3)
                    {
                        if (tokens[2] == null || tokens[2].Length == 0)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet3 = int.Parse(tokens[3].Trim());
                            AjouterLien(sommet1, sommet3);
                        }
                        else if (tokens[3] == null || tokens[3].Length == 0)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet2 = int.Parse(tokens[2].Trim());
                            AjouterLien(sommet1, sommet2);
                        }
                        else if (tokens[2] != null && tokens[3] != null && tokens[0] != null)
                        {
                            int sommet1 = int.Parse(tokens[0].Trim());
                            int sommet2 = int.Parse(tokens[2].Trim());
                            int sommet3 = int.Parse(tokens[3].Trim());
                            AjouterLien(sommet1, sommet2);
                            AjouterLien(sommet1, sommet3);
                        }  
                    }
                }
            }
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
                    float x = (float)((noeud.Longitude - minLon) / (maxLon - minLon) * largeur);
                    float y = (float)((1 - (noeud.Latitude - minLat) / (maxLat - minLat)) * hauteur);
                    positions[noeud.Sommet] = new SKPoint(x, y);
                }

                // Dessiner d'abord les liens (pour qu'ils soient sous les nœuds)
                foreach (var lien in Liens)
                {
                    // Utiliser l'ID de ligne pour déterminer la couleur
                    paintLien.Color = ObtenirCouleurLigne(lien.Noeud1.IdLigne);

                    SKPoint point1 = positions[lien.Noeud1.Sommet];
                    SKPoint point2 = positions[lien.Noeud2.Sommet];
                    canvas.DrawLine(point1, point2, paintLien);
                }

                // Dessiner les nœuds et leurs libellés
                foreach (var noeud in Noeuds.Values)
                {
                    SKPoint position = positions[noeud.Sommet];

                    // Utiliser l'ID de ligne pour déterminer la couleur
                    paintNoeud.Color = ObtenirCouleurLigne(noeud.IdLigne);

                    // Dessiner le cercle représentant la station
                    canvas.DrawCircle(position, 5, paintNoeud);

                    // Dessiner un contour noir pour mieux distinguer les stations
                    using (SKPaint paintContour = new SKPaint
                    {
                        Color = SKColors.Black,
                        Style = SKPaintStyle.Stroke,
                        StrokeWidth = 1
                    })
                    {
                        canvas.DrawCircle(position, 5, paintContour);
                    }

                    // Mesurer les dimensions du texte pour le fond
                    string libelle = noeud.Libelle;
                    SKRect textBounds = new SKRect();
                    paintTexte.MeasureText(libelle, ref textBounds);

                    // Position du texte
                    float textX = position.X + 7;
                    float textY = position.Y + 5;

                    // Dessiner un fond semi-transparent pour le texte
                    SKRect fondRect = new SKRect(
                        textX - 2,
                        textY - textBounds.Height - 2,
                        textX + textBounds.Width + 2,
                        textY + 2
                    );
                    canvas.DrawRect(fondRect, paintFond);

                    // Dessiner le libellé de la station
                    canvas.DrawText(libelle, textX, textY, paintTexte);
                }


                // Sauvegarder l'image
                using (SKFileWStream fs = new SKFileWStream(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }
        }
    }
}


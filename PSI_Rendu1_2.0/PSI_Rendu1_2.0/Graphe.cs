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

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Test-PSI")]

namespace PSI_Rendu1
{
    internal class Graphe
    {
        ///Création des attributs : 1 dictionnaire de int et de Noeud, une liste de Lien, un dictionnaire de int et de liste de int (pour savoir avec quels sommets sont reliés chacun), et une matrice de int 
        public Dictionary<int, Noeud> Noeuds { get; private set; } = new Dictionary<int, Noeud>();
        public List<Lien> Liens { get; private set; } = new List<Lien>();
        public Dictionary<int, List<int>> ListeAdjacence { get; private set; } = new Dictionary<int, List<int>>();
        public int[,] MatriceAdjacence;

        ///Constructeur de la classe Graphe 
        public Graphe(int nombreNoeuds)
        {
            MatriceAdjacence = new int[nombreNoeuds + 1, nombreNoeuds + 1];
        }

        ///Fonction AjouterLien qui permet de rajouter de créer des liens et qui remplit les attributs qui évoluent avec le nouveau lien et les nouveaux sommets
        public void AjouterLien(int sommet1, int sommet2)
        {
            if (!Noeuds.ContainsKey(sommet1)) Noeuds[sommet1] = new Noeud(sommet1);
            if (!Noeuds.ContainsKey(sommet2)) Noeuds[sommet2] = new Noeud(sommet2);

            Liens.Add(new Lien(Noeuds[sommet1], Noeuds[sommet2]));

            if (!ListeAdjacence.ContainsKey(sommet1)) ListeAdjacence[sommet1] = new List<int>();
            if (!ListeAdjacence.ContainsKey(sommet2)) ListeAdjacence[sommet2] = new List<int>();

            ListeAdjacence[sommet1].Add(sommet2);
            ListeAdjacence[sommet2].Add(sommet1);

            MatriceAdjacence[sommet1, sommet2] = 1;
            MatriceAdjacence[sommet2, sommet1] = 1;
        }

        ///Fonction AnalyserGraphe qui donne des propriétés du graphe
        public void AnalyserGraphe()
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
        }

        /// Fonction de parcours en largeur
        public HashSet<int> ParcoursBFS(int sommetDepart)
        {
            HashSet<int> visites = new HashSet<int>();
            Queue<int> file = new Queue<int>();

            file.Enqueue(sommetDepart);

            while (file.Count > 0)
            {
                int sommet = file.Dequeue();
                if (!visites.Contains(sommet))
                {
                    visites.Add(sommet);
                    if (ListeAdjacence.ContainsKey(sommet))
                    {
                        foreach (int voisin in ListeAdjacence[sommet])
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

        /// Fonction de parcours en profondeur
        public HashSet<int> ParcoursDFS(int sommetDepart)
        {
            HashSet<int> visites = new HashSet<int>();
            Stack<int> pile = new Stack<int>();

            pile.Push(sommetDepart);

            while (pile.Count > 0)
            {
                int sommet = pile.Pop();
                if (!visites.Contains(sommet))
                {
                    visites.Add(sommet);
                    if (ListeAdjacence.ContainsKey(sommet))
                    {
                        foreach (int voisin in ListeAdjacence[sommet])
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

        /// Vérifie si le graphe est connexe avec BFS
        public bool EstConnexeBFS()
        {
            if (Noeuds.Count == 0) return false;

            int premierSommet = Noeuds.Keys.First(); /// Prend un premier sommet quelconque
            HashSet<int> visites = ParcoursBFS(premierSommet);

            return visites.Count == Noeuds.Count;
        }

        /// Vérifie si le graphe est connexe avec DFS
        public bool EstConnexeDFS()
        {
            if (Noeuds.Count == 0) return false;

            int premierSommet = Noeuds.Keys.First(); /// Prend un premier sommet quelconque
            HashSet<int> visites = ParcoursDFS(premierSommet);

            return visites.Count == Noeuds.Count;
        }

        ///Fonction VisualiserGraphe qui permet de créer le graphe grâce à SkiaSharp
        public void VisualiserGraphe(string filePath)
        {
            int largeur = 800;
            int hauteur = 800;
            int rayon = 300;
            int centreX = largeur / 2;
            int centreY = hauteur / 2;
            int nombreNoeuds = Noeuds.Count;

            using (SKBitmap bitmap = new SKBitmap(largeur, hauteur))
            using (SKCanvas canvas = new SKCanvas(bitmap))
            using (SKPaint paintNoeud = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Fill })
            using (SKPaint paintLien = new SKPaint { Color = SKColors.Gray, Style = SKPaintStyle.Stroke, StrokeWidth = 2 })
            using (SKPaint paintTexte = new SKPaint { Color = SKColors.White, TextSize = 20 })
            {
                canvas.Clear(SKColors.White);
                Dictionary<int, SKPoint> positions = new Dictionary<int, SKPoint>();


                ///Positionnement des sommets du graphe :
                int index = 0;
                foreach (var noeud in Noeuds.Values)
                {
                    double angle = 2 * Math.PI * index / nombreNoeuds;
                    float x = (float)(centreX + rayon * Math.Cos(angle));
                    float y = (float)(centreY + rayon * Math.Sin(angle));
                    positions[noeud.Sommet] = new SKPoint(x, y);
                    index++;
                }

                ///Création des lignes pour relier les sommets qui sont adjacents :
                foreach (var lien in Liens)
                {
                    canvas.DrawLine(positions[lien.Noeud1.Sommet], positions[lien.Noeud2.Sommet], paintLien);
                }

                foreach (var noeud in Noeuds.Values)
                {
                    SKPoint position = positions[noeud.Sommet];
                    canvas.DrawCircle(position, 20, paintNoeud);
                    canvas.DrawText(noeud.Sommet.ToString(), position.X - 10, position.Y + 5, paintTexte);
                }

                using (SKFileWStream fs = new SKFileWStream(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }
        }

        ///Fonction ChargerDepuisFichier qui permet de remplir les attributs avec un fichier de liens
        public void ChargerDepuisFichier(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    if (ligne.StartsWith("%")) continue;
                    string[] tokens = ligne.Split(' ');
                    if (tokens.Length >= 2)
                    {
                        int sommet1 = int.Parse(tokens[0]);
                        int sommet2 = int.Parse(tokens[1]);
                        AjouterLien(sommet1, sommet2);
                    }
                }
            }       
        }
    }
}


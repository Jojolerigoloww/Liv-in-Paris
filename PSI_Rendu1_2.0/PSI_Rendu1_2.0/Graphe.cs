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
    internal class Graphe<T>
    {
        public Dictionary<T, Noeud<T>> Noeuds { get; private set; } = new Dictionary<T, Noeud<T>>();
        public List<Lien<T>> Liens { get; private set; } = new List<Lien<T>>();
        public Dictionary<T, List<T>> ListeAdjacence { get; private set; } = new Dictionary<T, List<T>>();

        public void AjouterLien(T sommet1, T sommet2)
        {
            if (!Noeuds.ContainsKey(sommet1)) Noeuds[sommet1] = new Noeud<T>(sommet1, sommet1.ToString());
            if (!Noeuds.ContainsKey(sommet2)) Noeuds[sommet2] = new Noeud<T>(sommet2, sommet2.ToString());

            Liens.Add(new Lien<T>(Noeuds[sommet1], Noeuds[sommet2]));

            if (!ListeAdjacence.ContainsKey(sommet1)) ListeAdjacence[sommet1] = new List<T>();
            if (!ListeAdjacence.ContainsKey(sommet2)) ListeAdjacence[sommet2] = new List<T>();

            ListeAdjacence[sommet1].Add(sommet2);
            ListeAdjacence[sommet2].Add(sommet1);
        }

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

        public void ChargerNoeudsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                string headerLine = reader.ReadLine(); // Lire la première ligne contenant les intitulés
                if (headerLine == null) return;

                string[] headers = headerLine.Split(';');

                int indexSommet = Array.IndexOf(headers, "ID Station");
                string indexLibelle = Array.IndexOf(headers, "Libelle station");

                if (indexSommet == -1 || indexLibelle == -1)
                {
                    Console.WriteLine("Erreur : Colonnes requises non trouvées dans le fichier.");
                    return;
                }

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(';');
                    if (tokens.Length > Math.Max(indexSommet, indexLibelle))
                    {
                        T noeud = (T)Convert.ChangeType(tokens[indexSommet].Trim(), typeof(T));
                        string libelle = tokens[indexLibelle].Trim();
                        if (!Noeuds.ContainsKey(noeud))
                        {
                            Noeuds[noeud] = new Noeud<T>(noeud, libelle);
                        }
                    }
                }
            }
        }




        public void ChargerArcsDepuisCSV(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(',');
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
        }


        public void DecrireNoeuds()
        {
            Console.WriteLine("Noeuds du graphe :");
            foreach (var noeud in Noeuds.Values)
            {
                Console.WriteLine(noeud.Decrire());
            }
        }

        public void DecrireLiens()
        {
            Console.WriteLine("Liens du graphe :");
            foreach (var lien in Liens)
            {
                Console.WriteLine(lien.Decrire());
            }
        }


        ///Fonction VisualiserGraphe qui permet de créer le graphe grâce à SkiaSharp
        public void VisualiserGraphe(string filePath)
        {
            int largeur = 1600;
            int hauteur = 1600;
            Random rand = new Random();

            using (SKBitmap bitmap = new SKBitmap(largeur, hauteur))
            using (SKCanvas canvas = new SKCanvas(bitmap))
            using (SKPaint paintNoeud = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Fill })
            using (SKPaint paintLien = new SKPaint { Color = SKColors.Gray, Style = SKPaintStyle.Stroke, StrokeWidth = 2 })
            using (SKPaint paintTexte = new SKPaint { Color = SKColors.White, TextSize = 20 })
            {
                canvas.Clear(SKColors.White);

                Dictionary<T, SKPoint> positions = new Dictionary<T, SKPoint>();
                foreach (var noeud in Noeuds.Values)
                {
                    float x = rand.Next(50, largeur - 50);
                    float y = rand.Next(50, hauteur - 50);
                    positions[noeud.Sommet] = new SKPoint(x, y);
                }

                foreach (var lien in Liens)
                {
                    canvas.DrawLine(positions[lien.Noeud1.Sommet], positions[lien.Noeud2.Sommet], paintLien);
                }

                foreach (var noeud in Noeuds.Values)
                {
                    SKPoint position = positions[noeud.Sommet];
                    canvas.DrawCircle(position, 5, paintNoeud);
                    canvas.DrawText(noeud.Sommet.ToString(), position.X + 5, position.Y - 5, paintTexte);
                }

                using (SKFileWStream fs = new SKFileWStream(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }
        }
    }
}


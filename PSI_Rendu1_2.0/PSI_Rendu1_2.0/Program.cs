using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace PSI_Rendu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "soc-karate.mtx";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Erreur : Fichier soc-karate.mtx introuvable.");
                return;
            }

            Graphe graphe = new Graphe(34); /// 34 est le nombre de nœuds dans le graphe "Karate Club"
            graphe.ChargerDepuisFichier(filePath);

            Console.WriteLine("Analyse du graphe :");
            graphe.AnalyserGraphe();

            graphe.VisualiserGraphe("graphe.png");

        }
    }
}

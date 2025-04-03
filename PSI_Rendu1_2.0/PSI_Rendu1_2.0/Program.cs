using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using OfficeOpenXml;

namespace PSI_Rendu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string noeudsFilePath = "MetroParisNoeuds.csv";
            string arcsFilePath = "MetroParisArcs.csv";

            if (!File.Exists(noeudsFilePath) || !File.Exists(arcsFilePath))
            {
                Console.WriteLine("Erreur : Fichiers CSV introuvables.");
                return;
            }

            Graphe graphe = new Graphe();
            graphe.DecrireNoeuds();
            graphe.DecrireLiens();

            graphe.ChargerNoeudsDepuisCSV(noeudsFilePath);
            graphe.ChargerArcsDepuisCSV(arcsFilePath);

            //Console.WriteLine("Analyse du graphe :");
            //graphe.AnalyserGraphe();

            graphe.VisualiserGraphe("graphe.png");
            Console.WriteLine("Le graphe a été généré sous 'graphe.png'.");

            Console.ReadLine();
 
        }
    }
}

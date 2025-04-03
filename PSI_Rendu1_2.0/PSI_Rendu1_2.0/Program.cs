using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using OfficeOpenXml;
using MySql.Data.MySqlClient;

namespace PSI_Rendu1
{
    internal class Program
    {

        static void ConnexionSQL()
        {
            /// CONNECTER LA DATABASE
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;DATABASE=livin;UID=root;PASSWORD=xhz45ZXQ-&";
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur Connexion : " + e.ToString());
                return;
            }

            /// CREER UNE REQUETE
            string requete = "SELECT * FROM utilisateur ORDER BY Nom_User,Prenom_User; ";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;
            MySqlDataReader reader1 = command1.ExecuteReader();

            /// RECUPERER LA OU LES RESULTATS
            string[] valueString = new string[reader1.FieldCount];
            while (reader1.Read())
            {
                string Nom_User = (string)reader1["Nom_User"];
                string Prenom_User = (string)reader1["Prenom_User"];
                Console.WriteLine(Nom_User + " " + Prenom_User);


            }
            /// FERMER LA CONNEXION
            reader1.Close();
            command1.Dispose();


        }

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
            //graphe.DecrireNoeuds();
            //graphe.DecrireLiens();

            graphe.ChargerNoeudsDepuisCSV(noeudsFilePath);
            graphe.ChargerArcsDepuisCSV(arcsFilePath);

            //Console.WriteLine("Analyse du graphe :");
            //graphe.AnalyserGraphe();

            graphe.VisualiserGraphe("graphe.png");
            Console.WriteLine("Le graphe a été généré sous 'graphe.png'.");


            ///Execution de l'algo de plus court chemin
            Console.WriteLine("Entrez la station de départ :");
            string station1 = Console.ReadLine();
            Console.WriteLine("Entrez la station d'arrivée :");
            string station2 = Console.ReadLine();

            var (itineraire, tempsParcours, etapes) = graphe.AlgoBellmanFord(station1, station2);

            Console.WriteLine("Itinéraire complet :");
            foreach (var station in itineraire)
            {
                Console.WriteLine($"- {station}");
            }

            Console.WriteLine("\nDétail des étapes :");
            foreach (var (depart, arrivee, temps) in etapes)
            {
                if (depart == arrivee)
                    Console.WriteLine($"- Changement de ligne à {depart} : {temps} minutes");
                else
                    Console.WriteLine($"- De {depart} à {arrivee} : {temps} minutes");
            }

            Console.WriteLine($"\nTemps total du parcours : {tempsParcours} minutes");
            Console.WriteLine($"Temps total du parcours : {tempsParcours} minutes");
            Console.WriteLine("Chemin le plus court : " + string.Join(" -> ", itineraire));
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Noeud
    {
        public int Sommet { get; private set; }
        public string Libelle { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public string IdLigne { get; private set; }

        public Noeud(int sommet, string libelle, double longitude, double latitude, string idLigne = null)
        {
            Sommet = sommet;
            Libelle = libelle;
            Longitude = longitude;
            Latitude = latitude;
            IdLigne = idLigne;
        }

        public string Decrire()
        {
            return $"Noeud: {Sommet}, Libellé: {Libelle}, Longitude: {Longitude}, Latitude: {Latitude}";
        }
    }
}

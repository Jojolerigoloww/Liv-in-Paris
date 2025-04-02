using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Noeud<T>
    {
        public T Sommet { get; private set; }
        public string Libelle { get; private set; }

        public Noeud(T sommet, string libelle)
        {
            Sommet = sommet;
            Libelle = libelle;
        }

        public string Decrire()
        {
            return $"Noeud: {Sommet}, Libellé: {Libelle}";
        }
    }
}

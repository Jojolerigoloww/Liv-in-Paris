using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Lien<T>
    {
        public Noeud<T> Noeud1 { get; private set; }
        public Noeud<T> Noeud2 { get; private set; }

        public Lien(Noeud<T> noeud1, Noeud<T> noeud2)
        {
            Noeud1 = noeud1;
            Noeud2 = noeud2;
        }

        public string Decrire()
        {
            return $"Lien entre {Noeud1.Sommet} ({Noeud1.Libelle}) et {Noeud2.Sommet} ({Noeud2.Libelle})";
        }
    }
}

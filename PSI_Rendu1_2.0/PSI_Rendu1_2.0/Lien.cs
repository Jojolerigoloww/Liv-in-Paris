using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Lien
    {
        public Noeud Noeud1 { get; private set; }
        public Noeud Noeud2 { get; private set; }

        public Lien(Noeud noeud1, Noeud noeud2)
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

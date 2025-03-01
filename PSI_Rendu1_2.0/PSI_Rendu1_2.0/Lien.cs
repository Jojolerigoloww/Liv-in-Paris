using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Lien
    {

        ///Création des deux attrributs de type Noeud
        public Noeud Noeud1 { get; private set; }
        public Noeud Noeud2 { get; private set; }

        ///Constructeur de la classe Lien
        public Lien(Noeud n1, Noeud n2)
        {
            Noeud1 = n1;
            Noeud2 = n2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_Rendu1
{
    internal class Noeud
    {
        ///Création de l'attribut de type int 
        public int Sommet { get; private set; }

        ///Constructeur de la classe Lien
        public Noeud(int sommet)
        {
            Sommet = sommet;
        }
    }
}

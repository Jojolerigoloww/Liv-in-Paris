using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PSI_Interface
{
    [Serializable]
    [XmlRoot("Utilisateurs")]
    public class ListeUtilisateurs
    {
        [XmlElement("Utilisateur")]
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}

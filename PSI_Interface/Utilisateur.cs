using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PSI_Interface
{
    [Serializable]
    [XmlRoot("Utilisateur")]
    public class Utilisateur
    {
        [XmlElement("ID_User")]
        public string ID_User { get; set; } = null;

        [XmlElement("Nom")]
        public string Nom { get; set; }

        [XmlElement("Prenom")]
        public string Prenom { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("MotDePasse")]
        public string MotDePasse { get; set; }

        [XmlElement("Adresse")]
        public string Adresse { get; set; }

        [XmlElement("Metro")]
        public string Metro { get; set; }

        public static void SerialiserUtilisateur(Utilisateur utilisateur, string cheminFichier)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Utilisateur));
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Create))
            {
                serializer.Serialize(fs, utilisateur);
            }
        }

        public static Utilisateur DeserialiserUtilisateur(string cheminFichier)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Utilisateur));
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Open))
            {
                return (Utilisateur)serializer.Deserialize(fs);
            }
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom} ({Email})";
        }
    }
}

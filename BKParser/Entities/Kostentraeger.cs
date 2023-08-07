using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKParser.Entities
{
    public class Kostentraeger
    {
        public int IK_Nr { get; set; } // IK-Nummer
        public string Name { get; set; }
        public string Adresse_StrasseHausnummer { get; set; } // Adresse Straße/Hausnummer
        public string Adresse_PLZ { get; set; } // Adresse PLZ
        public string Adresse_Ort { get; set; } // Adresse Ort       
        public string Email { get; set; }
        public int IK_Nr_UebergeordneteIK { get; set; } // IK-Nr Übergeordnete IK
        public List<Annahmestelle> Annahmestellen = new List<Annahmestelle>();
        

        public Kostentraeger(
        int ikNr,
        string name,
        string adresseStrasseHausnummer,
        string adressePLZ,
        string adresseOrt,
        string email,
        int ikNrUebergeordneteIK,
        List<Annahmestelle> annahmestellen
        )
        {
            IK_Nr = ikNr;
            Name = name;
            Adresse_StrasseHausnummer = adresseStrasseHausnummer;
            Adresse_PLZ = adressePLZ;
            Adresse_Ort = adresseOrt;
            Email = email;
            IK_Nr_UebergeordneteIK = ikNrUebergeordneteIK;
            Annahmestellen = annahmestellen;
        }
    }

}

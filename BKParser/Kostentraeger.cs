using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKParser
{
    public class Kostentraeger
    {
        public int IK_Nr { get; set; } // IK-Nummer
        public string Name { get; set; }
        public string Adresse_StrasseHausnummer { get; set; } // Adresse Straße/Hausnummer
        public string Adresse_PLZ { get; set; } // Adresse PLZ
        public string Adresse_Ort { get; set; } // Adresse Ort
        public int Id_Bezirk { get; set; }
        public int Id_Bundesland { get; set; }
        public string Email { get; set; }
        public int IK_Nr_UebergeordneteIK { get; set; } // IK-Nr Übergeordnete IK
        public short IK_Nr_Datenannahmestelle { get; set; } // IK-Nr Datenannahmestelle

        public Kostentraeger(
        int ikNr,
        string name,
        string adresseStrasseHausnummer,
        string adressePLZ,
        string adresseOrt,
        int idBezirk,
        int idBundesland,
        string email,
        int ikNrUebergeordneteIK,
        short ikNrDatenannahmestelle)
        {
            IK_Nr = ikNr;
            Name = name;
            Adresse_StrasseHausnummer = adresseStrasseHausnummer;
            Adresse_PLZ = adressePLZ;
            Adresse_Ort = adresseOrt;
            Id_Bezirk = idBezirk;
            Id_Bundesland = idBundesland;
            Email = email;
            IK_Nr_UebergeordneteIK = ikNrUebergeordneteIK;
            IK_Nr_Datenannahmestelle = ikNrDatenannahmestelle;
        }
    }
    
}

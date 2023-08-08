using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKParser.Entities
{
    public class OutputItem
    {
        public  int IK_Nr { get; set; }
        public  string Name { get; set; }
        public  string Adresse_StrasseHausnummer { get; set; }
        public  string Adresse_PLZ { get; set; }
        public  string Adresse_Ort { get; set; }
        public  string Email { get; set; }
        public  int IK_Nr_UebergeordneteIK { get; set; }
        public  string Id_Bezirk { get; set; }
        public  string Id_Bundesland { get; set; }
        public  int IK_Nr_Datenannahmestelle { get; set; }

        public OutputItem(int ikNr,
        string name,
        string adresseStrasseHausnummer,
        string adressePLZ,
        string adresseOrt,
        string email,
        int ikNrUebergeordneteIK, string idBezirk, string idBundesland, int ikNrDatenannahmestelle)
        {
            IK_Nr = ikNr;
            Name = name;
            Adresse_StrasseHausnummer = adresseStrasseHausnummer;
            Adresse_PLZ = adressePLZ;
            Adresse_Ort = adresseOrt;
            Email = email;
            IK_Nr_UebergeordneteIK = ikNrUebergeordneteIK;
            Id_Bezirk = idBezirk;
            Id_Bundesland = idBundesland;
            IK_Nr_Datenannahmestelle = ikNrDatenannahmestelle;
        }
    }
}

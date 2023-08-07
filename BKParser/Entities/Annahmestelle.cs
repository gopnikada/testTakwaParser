﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKParser.Entities
{
    public class Annahmestelle
    {
        public int Id_Bezirk { get; set; }
        public int Id_Bundesland { get; set; }
        public int IK_Nr_Datenannahmestelle { get; set; } // IK-Nr Datenannahmestelle

        public Annahmestelle(int idBezirk,int idBundesland, int ikNrDatenannahmestelle)
        {
            Id_Bezirk = idBezirk;
            Id_Bundesland = idBundesland;
            IK_Nr_Datenannahmestelle = ikNrDatenannahmestelle;
        }
    }
}

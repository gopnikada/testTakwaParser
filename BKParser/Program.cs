using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using BKParser.Entities;
using Microsoft.VisualBasic;

namespace BKParser
{
    internal class Program
    {

        public static int IK_Nr { get; set; }
        public static string Name { get; set; }
        public static string Adresse_StrasseHausnumm { get; set; }
        public static string Adresse_PLZ { get; set; }
        public static string Adresse_Ort { get; set; }
        public static string Email { get; set; }
        public static int IK_Nr_UebergeordneteIK { get; set; }

        public static List<Kostentraeger> KostTraegerList = new List<Kostentraeger>();

        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.ke0";
            string pathToWrite = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.csv";


            ReadFileContent(filePath);
            var aggregated = KostTraegerList.SelectMany(x => x.Annahmestellen.Where(y => true), (x, y) => new { Stelle = x, Kasse = y })
                .Select(x => new OutputItem(x.Stelle.IK_Nr, x.Stelle.Name, x.Stelle.Adresse_StrasseHausnummer,
                x.Stelle.Adresse_PLZ, x.Stelle.Adresse_Ort, x.Stelle.Email, x.Stelle.IK_Nr_UebergeordneteIK, x.Kasse.Id_Bezirk, x.Kasse.Id_Bundesland, x.Kasse.IK_Nr_Datenannahmestelle)).ToList();

            
            
            //WriteToCsv(pathToWrite, aggregated);

            Console.WriteLine(1);
        }

        private static void WriteToCsv(string path, List<OutputItem> aggregated)
        {
            try
            {
                File.Create(path);
               foreach (var row in aggregated)
                {
                    string strToWrite = string.Join(';', row);
                    File.AppendAllText(path, Environment.NewLine);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadFileContent(string filePath)
        {
            var lines = File.ReadLines(filePath, Encoding.Latin1);

            

            ResetInstance();
            var annameStList = new List<Annahmestelle>();
            foreach (string line in lines)
            {


                string prefix = line[0..3];
                switch (prefix)
                {
                    case "IDK":
                        IK_Nr = int.Parse(line[3..13]);
                        break;
                    case "NAM":
                        Name = string.Join(' ', line[7..(line.Length - 1)].Split('+'));
                        break;

                    case "ANS":
                        if (line.StartsWith("ANS+1"))
                        {
                            Adresse_PLZ = line[6..11];
                            var ortStrNum = line[12..(line.Length - 1)].Split('+');


                            switch (ortStrNum.Length)
                            {
                                case 2:
                                    Adresse_Ort = ortStrNum[0];
                                    Adresse_StrasseHausnumm = ortStrNum[1];
                                    break;
                                case 1:
                                    Adresse_Ort = ortStrNum[0];
                                    break;
                                default:
                                    break;
                            }
                        }

                        break;
                    case "VDT":
                        IK_Nr_UebergeordneteIK = int.Parse(line[4..(line.Length - 1)]);
                        break;
                    case "DFU":
                        if (line.StartsWith("DFU+01"))
                        {
                            Email = !char.IsNumber(line[line.Length - 2]) ? line[(IndexOfNth(line, '+', 7) + 1)..(line.Length - 1)] : "";
                        }
                        break;
                    case "VKG":
                        string bundesland = string.Empty;
                        string bezirk = string.Empty;
                        int stelleId = int.Parse(line[7..IndexOfNth(line, '+', 3)]);
                        var bezBundLTar = line[(IndexOfNth(line, '+', 7) + 1)..(line.Length - 1)].Replace("++", "+").Split('+').ToList().Where(x => x.Length > 0).ToList();

                        switch (bezBundLTar.Count)
                        {
                            case 2:
                                bundesland = bezBundLTar[0];
                                break;
                            case 3:
                                bundesland = bezBundLTar[0];
                                bezirk = bezBundLTar[1];
                                break;
                            case 1:
                                break;
                            default:
                                break;

                        }

                        annameStList.Add(new Annahmestelle(bezirk, bundesland, stelleId));
                        break;
                    case "UNT":
                        KostTraegerList.Add(new Kostentraeger(IK_Nr, Name, Adresse_StrasseHausnumm, Adresse_PLZ,
                            Adresse_Ort, Email, IK_Nr_UebergeordneteIK, new List<Annahmestelle>(annameStList)));
                        ResetInstance();
                        annameStList.Clear();
                        break;
                    default:
                        break;
                }

            }
        }

        public static void ResetInstance()
        {
            IK_Nr = 0;
            Name = string.Empty;
            Adresse_StrasseHausnumm = string.Empty;
            Adresse_PLZ = string.Empty;
            Adresse_Ort = string.Empty;
            Email = string.Empty;
            IK_Nr_UebergeordneteIK = 0;
        }
        private static int IndexOfNth(string str, char c, int n)
        {
            int s = -1;

            for (int i = 0; i < n; i++)
            {
                s = str.IndexOf(c, s + 1);

                if (s == -1) break;
            }

            return s;
        }
    }
}
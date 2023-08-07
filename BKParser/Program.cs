using System.Linq.Expressions;
using System.Text;
using BKParser.Entities;

namespace BKParser
{
    internal class Program
    {

        public static int IK_Nr { get; set; }
        public static string  Name { get; set; }
        public static string  Adresse_StrasseHausnumm { get; set; }
        public static string Adresse_PLZ { get; set; }
        public static string  Adresse_Ort { get; set; }
        public static int     Id_Bezirk { get; set; }
        public static int     Id_Bundesland { get; set; }
        public static string  Email { get; set; }
        public static int     IK_Nr_UebergeordneteIK { get; set; }
        public static short   IK_Nr_Datenannahmestelle { get; set; }

        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.ke0";


            var lines = File.ReadLines(filePath, Encoding.Latin1);

            var kostTraegerList = new List<Kostentraeger>();

            ResetInstance();
            ResetAnnameSt();
        
            foreach (string line in lines)
            {
                var annameStList = new List<Annahmestelle>();


                string prefix = line[0..3];
                switch (prefix)
                {
                    case "IDK":
                        IK_Nr = int.Parse(line[3..13]);
                        break;
                    case "NAM":
                        Name = line.Count(c => c == '+') > 2 ? 
                            new string(line[7..IndexOfNth(line, '+', 3)].Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray()):
                            line[7..(line.Length - 1)];
                        break;

                    case "ANS":
                        if (line.StartsWith("ANS+1"))
                        {
                            Adresse_Ort = line[(IndexOfNth(line, '+', 3)+1)..IndexOfNth(line, '+', 4)];
                            Adresse_PLZ = line[6..11];
                            Adresse_StrasseHausnumm = line[(IndexOfNth(line, '+', 4)+1)..(line.Length-1)];
                        }
                        break;
                    case "VDT":
                        IK_Nr_UebergeordneteIK = int.Parse(line[4..(line.Length - 1)]);
                        break;
                    case "VKG":
                        int bezirk = 12;
                        int bundesland = 12;
                        int stelleId = 12;

                        annameStList.Add(new Annahmestelle(bezirk, bundesland, stelleId));
                        break;
                    case "UNT":
                        kostTraegerList.Add(new Kostentraeger(IK_Nr, Name, Adresse_StrasseHausnumm, Adresse_PLZ,
                            Adresse_Ort, Id_Bezirk, Id_Bundesland, Email, IK_Nr_UebergeordneteIK, IK_Nr_Datenannahmestelle));
                        ResetInstance();
                        
                        break;
                    default:
                        break;
                }

            }
        }

        private static void ResetAnnameSt()
        {
            throw new NotImplementedException();
        }

        public static void ResetInstance()
        {
            IK_Nr = 0;
            Name = string.Empty;
            Adresse_StrasseHausnumm = string.Empty;
            Adresse_PLZ = string.Empty;
            Adresse_Ort = string.Empty;
            Id_Bezirk = 0;
            Id_Bundesland = 0;
            Email = string.Empty;
            IK_Nr_UebergeordneteIK = 0;
            IK_Nr_Datenannahmestelle = 0;
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
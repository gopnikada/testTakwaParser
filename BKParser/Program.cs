using System.Linq.Expressions;

namespace BKParser
{
    internal class Program
    {

        public static int IK_Nr { get; set; }
        public static string  Name { get; set; }
        public static string  Adresse_StrasseHausnumm { get; set; }
        public static int     Adresse_PLZ { get; set; }
        public static string  Adresse_Ort { get; set; }
        public static int     Id_Bezirk { get; set; }
        public static int     Id_Bundesland { get; set; }
        public static string  Email { get; set; }
        public static int     IK_Nr_UebergeordneteIK { get; set; }
        public static short   IK_Nr_Datenannahmestelle { get; set; }

        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.ke0";


            var lines = File.ReadLines(filePath);

            var kostTraegerList = new List<Kostentraeger>();

            ResetInstance();
        
            foreach (string line in lines)
            {
                if(line.Count(c => c == '+') > 2 && line.StartsWith("NAM"))
                {
                    var test = new string(line[7..IndexOfNth(line, '+', 3)].Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());


                }

                //string prefix = line[0..3];
                //switch (prefix)
                //{
                //    case "IDK":
                //        IK_Nr = int.Parse(line[3..13]);
                //        break;
                //    case "NAM":
                //        Name = line.Count(c => c == '+') > 2 ? line[7..line.IndexOf('+', 1, 3)] : line[7..(line.Length-1)];
                //        break;
                //    case "ANS":
                //        // code block
                //        break;
                //    case "VKG":
                //        // code block
                //        break;
                //    case "UNT":
                //        kostTraegerList.Add(new Kostentraeger(IK_Nr, Name, Adresse_StrasseHausnumm, Adresse_PLZ,
                //            Adresse_Ort, Id_Bezirk, Id_Bundesland, Email, IK_Nr_UebergeordneteIK, IK_Nr_Datenannahmestelle));
                //        ResetInstance();
                //        // end
                //        break;
                //    default:
                //        // code block
                //        break;
                //}

            }
        }

        public static void ResetInstance()
        {
            IK_Nr = 0;
            Name = string.Empty;
            Adresse_StrasseHausnumm = string.Empty;
            Adresse_PLZ = 0;
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
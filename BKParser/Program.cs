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
        public static string  Email { get; set; }
        public static int     IK_Nr_UebergeordneteIK { get; set; }

        

        static void Main(string[] args)
        {

            string filePath = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.ke0";

            var lines = File.ReadLines(filePath, Encoding.Latin1);

            var kostTraegerList = new List<Kostentraeger>();

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
                        //Name = line.Count(c => c == '+') > 2 ? 
                        //    new string(line[7..IndexOfNth(line, '+', 3)].Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray()):
                        //    line[7..(line.Length - 1)];

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
                            Email = !char.IsNumber(line[line.Length - 2]) ? line[(IndexOfNth(line, '+', 7) + 1)..(line.Length - 1)]:"";
                        }
                        break;
                    case "VKG":
                        string bundesland = string.Empty;
                        string bezirk = string.Empty;
                        int stelleId = int.Parse(line[7..IndexOfNth(line, '+', 3)]);
                        var bezBundLTar = line[(IndexOfNth(line, '+', 7) + 1)..(line.Length - 1)].Replace("++", "+").Split('+').ToList().Where(x=>x.Length>0).ToList();

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
                        kostTraegerList.Add(new Kostentraeger(IK_Nr, Name, Adresse_StrasseHausnumm, Adresse_PLZ,
                            Adresse_Ort, Email, IK_Nr_UebergeordneteIK, new List<Annahmestelle>(annameStList)));
                        ResetInstance();
                        annameStList.Clear();
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(1);
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
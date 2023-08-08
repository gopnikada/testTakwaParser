using BKParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKParser.Utils
{
    public static class Helpers
    {
        public static List<OutputItem> DataTransform(List<Kostentraeger> kostTraegerList)
        {
            var aggregated = kostTraegerList.SelectMany(x => x.Annahmestellen.Where(y => true), (x, y) => new { Stelle = x, Kasse = y })
                .Select(x => new OutputItem(x.Stelle.IK_Nr, x.Stelle.Name, x.Stelle.Adresse_StrasseHausnummer,
                x.Stelle.Adresse_PLZ, x.Stelle.Adresse_Ort, x.Stelle.Email, x.Stelle.IK_Nr_UebergeordneteIK,
                x.Kasse.Id_Bezirk, x.Kasse.Id_Bundesland, x.Kasse.IK_Nr_Datenannahmestelle)).ToList();

            aggregated.ForEach((x) =>
            {

                switch (x.Id_Bundesland)
                {
                    case "01":
                        x.Id_Bundesland = "Schleswig-Holstein";
                        break;
                    case "02":
                        x.Id_Bundesland = "Hamburg";
                        break;
                    case "03":
                        x.Id_Bundesland = "Niedersachsen";
                        break;
                    case "04":
                        x.Id_Bundesland = "Bremen";
                        break;
                    case "05":
                        x.Id_Bundesland = "Nordrhein-Westfalen";
                        break;
                    case "06":
                        x.Id_Bundesland = "Hessen";
                        break;
                    case "07":
                        x.Id_Bundesland = "Rheinland-Pfalz";
                        break;
                    case "08":
                        x.Id_Bundesland = "Baden-Württemberg";
                        break;
                    case "09":
                        x.Id_Bundesland = "Bayern";
                        break;
                    case "10":
                        x.Id_Bundesland = "Saarland";
                        break;
                    case "11":
                        x.Id_Bundesland = "Berlin";
                        break;
                    case "12":
                        x.Id_Bundesland = "Brandenburg";
                        break;
                    case "13":
                        x.Id_Bundesland = "Mecklenburg-Vorpommern";
                        break;
                    case "14":
                        x.Id_Bundesland = "Sachsen";
                        break;
                    case "15":
                        x.Id_Bundesland = "Sachsen-Anhalt";
                        break;
                    case "16":
                        x.Id_Bundesland = "Thüringen";
                        break;
                    case "99":
                        x.Id_Bundesland = "Alle Bundesländer";
                        break;
                    default:
                        break;
                }
            });
            return aggregated;
        }


        public static void WriteToCsv(string path, List<OutputItem> aggregated)
        {

            try
            {

                foreach (var row in aggregated)
                {

                    string contents = row.ToString();
                    File.AppendAllText(path, contents, Encoding.Latin1);
                    File.AppendAllText(path, Environment.NewLine);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int IndexOfNth(string str, char c, int n)
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

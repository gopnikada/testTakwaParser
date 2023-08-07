using System.Linq.Expressions;

namespace BKParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\User\\source\\repos\\BKParser\\BKParser\\aok.ke0";


            var lines = File.ReadLines(filePath);

            var kostTraegerList = new List<Kostentraeger>();

            foreach (string line in lines)
            {
                string prefix = line[0..3];
                switch (prefix)
                {
                    case "IDK":
                        // code block
                        break;
                    case "UNA":
                        // code block
                        break;
                    default:
                        // code block
                        break;
                }

            }
        }
    }
}
using F;
using GP;
using AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace D
{
    internal class Data
    {
        static int count = 1;

        public static string GetFormula(string proteinName)
        {
            foreach (GeneticData item in MainClass.data)
            {
                if (item.name.Equals(proteinName)) return AddFunc.Decoding(item.formula);
            }
            return null;
        }
        public static void ReadGeneticData(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] fragments = line.Split('\t');
                GeneticData protein;
                protein.name = fragments[0];
                protein.organism = fragments[1];
                protein.formula = fragments[2];
                MainClass.data.Add(protein);
                count++;
            }
            reader.Close();
        }

        public static void ReadHandleCommands(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            StreamWriter writer = new StreamWriter("genedata.txt");
            writer.Write("Dwight Barnette\nGenetic Searching\n");
            writer.WriteLine("================================================");
            int counter = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine(); counter++;
                string[] command = line.Split('\t');
                if (command[0].Equals("search"))
                {
                    writer.WriteLine($"{counter.ToString("D3")}   {"search"}   {AddFunc.Decoding(command[1])}");
                    writer.WriteLine($"{"organism"}\t\t\t\t{"protein "}");
                    Modes.Search(command[1], writer);
                }
                if (command[0].Equals("diff"))
                {
                    writer.WriteLine($"{counter.ToString("D3")}   {"diff"}   {command[1]}   {command[2]}");
                    writer.WriteLine("amino-acids difference: ");
                    Modes.Diff(command[1], command[2], writer);
                }
                if (command[0].Equals("mode"))
                {
                    writer.WriteLine($"{counter.ToString("D3")}   {"mode"}   {command[1]}");
                    writer.WriteLine("amino-acid occurs: ");
                    Modes.Mode(command[1], writer);
                }
                writer.WriteLine("================================================");
            }
            reader.Close();
            writer.Close();
        }
    }
}

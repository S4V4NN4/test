using D;
using GP;
using AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F
{
    internal class Modes
    {
        public static void Search(string amino_acid, StreamWriter writer)
        {
            string decoded = AddFunc.Decoding(amino_acid);
            for (int i = 0; i < MainClass.data.Count; i++)
            {
                if (MainClass.data[i].formula.Contains(decoded))
                {
                    writer.WriteLine($"{MainClass.data[i].organism}    {MainClass.data[i].name}");
                    return;
                }
            }
            writer.WriteLine("NOT FOUND");
        }

        public static int Diff(string protein1, string protein2, StreamWriter writer)
        {
            string s1 = Data.GetFormula(protein1);
            string s2 = Data.GetFormula(protein2);

            int counter = Math.Max(s1.Length, s2.Length) - Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
            {
                if (s1[i] != s2[i])
                {
                    counter++;
                }
            }

            writer.WriteLine(counter);
            return counter;
        }

        public static void Mode(string protein, StreamWriter writer)
        {
            string formula = Data.GetFormula(protein);
            int[] c = new int[20];
            foreach (char ch in formula)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (ch == MainClass.letters[i])
                    {
                        c[i]++;
                    }
                }
            }

            int index = 0;
            for (int i = 1; i < 20; i++)
            {
                if (c[index] < c[i])
                {
                    index = i;
                }
            }

            writer.WriteLine($"{Char.ToString(MainClass.letters[index])}\t{c[index]}");
        }
    }
}

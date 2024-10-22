using System;
using System.Collections.Generic;
using System.IO;
using D;

namespace GP
{
    public struct GeneticData
    {
        public string name;
        public string organism;
        public string formula;
    }

    class MainClass
    {
        public static List<GeneticData> data = new List<GeneticData>();
        public static List<char> letters = new List<char>() { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'Y' };


        static void Main(string[] args)
        {
            Data.ReadGeneticData("sequences.1.txt");
            Data.ReadHandleCommands("commands.1.txt");
        }
    }
}
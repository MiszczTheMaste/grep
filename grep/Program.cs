using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grep
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> files = new List<string>();
            List<string> flags = new List<string>();
            string wordToFind = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains(".") && i != args.Length - 1)
                {
                    files.Add(args[i]);
                }
                if(i == args.Length - 1)
                {
                    wordToFind = args[i];
                }
                if (args[i].StartsWith("-"))
                {
                    flags.Add(args[i]);
                }
            }
            
            List<string> linesOfText = new List<string>();
            foreach(string directory in files)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(directory))
                    {
                        string line;
                        int index = 0;
                        if (flags.Contains("-l"))
                        {
                            linesOfText.Add("");
                            linesOfText.Add(directory + ":");
                        }       
                        while ((line = sr.ReadLine()) != null)
                        {
                            index++;
                            if (line.Contains(wordToFind))
                            {
                                if (flags.Contains("-n"))
                                {
                                    linesOfText.Add(index + ": " + line);
                                }
                                else
                                {
                                    linesOfText.Add(line);
                                }      
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (string line in linesOfText)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madlib_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayOn playon = new PlayOn();
            ChooseSonnet choosesonnet = new ChooseSonnet();


            do
            {
                Madlib madlib = new Madlib();
                // madlib.outputSonnet(Properties.Resources.Sonnet18);
                madlib.outputSonnet(choosesonnet.choose());
            } while (playon.check());
        }
    }

    //this determines if the user wants to play on or not
    public class PlayOn {
        public bool check() {
            string inputstring = "";

            while (true) {
                Console.WriteLine("Do you want to play again y/n");
                inputstring = Console.ReadLine();

                if (inputstring.ToLower() == "y" || inputstring.ToLower() == "yes")
                    return true;
                if (inputstring.ToLower() == "n" || inputstring.ToLower() == "no")
                    return false;

                Console.WriteLine("Input unclear");
            }
        }
    };

    //this creates a madlib from the chosen prompt and displays it to the user
    public class Madlib {
        public string sonnetBlank;

        //constructor
        public Madlib() { }

        public int outputSonnet(string s)
        {
            string sonnet = buildSonnet(s);
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("     SONNET    ");
            Console.WriteLine("===============");
            Console.WriteLine("\n" + sonnet + "\n");

            return 0;
        }

        string buildSonnet(string s1) {
            string s2 = "";
            int i = 0;
            int j = 0;
            int k = 0;
            string wordPrompt = "";
            while ((i = s1.IndexOf('<', i)) != -1) //finds next '<' in string
            {
                //add the string chunk to our sonnet
                s2 += s1.Substring(j, i - j);

                //find the next '>' in string
                k = s1.IndexOf('>', i);
                wordPrompt = s1.Substring(i + 1, k - i - 1);

                s2 += getWord(wordPrompt);
                j = k + 1;
                i++;

            }

            return s2;
        }

        string getWord(string s)
        {
            if (s[0] == 'a' || s[0] == 'A')
            {
                Console.WriteLine("Enter an " + s + " : "); }
            else { Console.WriteLine("Enter a " + s + " : "); }

            return Console.ReadLine();
        }

    };

    // in which the user decides which sonnet to defile
    public class ChooseSonnet{


        //user selects which sonnet and the program returns a string for the madlib prompt
        public string choose()
        {
            return Properties.Resources.Sonnet18;
        }

    

    };




}

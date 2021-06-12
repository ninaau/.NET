/*
 * @author Naomi A. Nindorera 040950950
 * LAB 1 .NET
 * INtroduction to C#
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Lab1
{
    class Program
    {
        IList<string> wordsList = new List<string>();
        

        void menu()
        {
            Console.WriteLine("1 - Import Words from File \n" +
                               "2 - Bubble Sort words \n" +
                               "3 - LINQ / Lambda sort words \n" +
                               "4 - Count the Distinct Words \n" +
                               "5 - Take the first 10 words \n" +
                               "6 - Get the number of words that start with 'j' and display the count \n" +
                               "7 - Get and display of words that end with 'd' and display the count \n" +
                               "8 - Get and display of words that are greater than 4 characters long, and display the count \n" +
                               "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count \n" +
                               "x – Exit \n \n" +
                               "Make a selection : "
                               );
        }

void import (string pth)
        {

            try
            {
                using (StreamReader reader = new StreamReader(pth))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        wordsList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

 IList<string> sort (IList<string> list)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string temp;
            for (int a = 0; a < (list.Count-1); a++)
            {
            for (int b = a + 1; b < (list.Count); b++)
                if (string.Compare(list.ElementAt(b), list.ElementAt(a)) < 0) 
                {
                   
                    temp = list[b];
                    list[b]=list[a];
                    list[a]=temp;
                    
                }
            }
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Time elapsed : " + ts.Milliseconds / 10 + "ms");
            return list;
        }

public IList<string> orderByList(IList<string> list)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var orderByList = list.OrderBy(w => w.Length).ToList();
            list = orderByList;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Time elapsed : " + ts.Milliseconds / 10 + "ms");
            return list;
        }


        static void Main(string[] args)
        {
            Program p = new Program();
            p.menu();
            while (true)
            {
                string path ="Words.txt";
                Stopwatch stopWatch = new Stopwatch();
                //TimeSpan ts = stopWatch.Elapsed;
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        p.import(path);
                        Console.WriteLine(" Readind words \n Reading words complete \n Number of words is : "+p.wordsList.Count());
                        break;

                    case "2":
                        p.wordsList = p.sort(p.wordsList);
                        break;

                    case "3":
                        p.wordsList = p.orderByList(p.wordsList);
                        break;

                    case "4":
                        var distinct = from w in p.wordsList.Distinct()
                                            select w;
                        int count = 0;
                        foreach (String i in distinct)
                        {
                         count++;
                        }
                        Console.WriteLine("The number of Distinct Words are : " + count);
                        break;

                    case "5":
                        var first10 = (from w in p.wordsList
                                       select w).Take(10).ToList();

                        foreach (String s in first10)
                        {
                         Console.WriteLine("\n" + s);
                        }
                        break;

                    case "6":
                        
                        var startsJ = (from w in p.wordsList
                                       where w.StartsWith("j")
                                       select w).ToList();

                        foreach (String s in startsJ)
                        {
                         Console.WriteLine("\n" + s);
                        }
                        break;

                    case "7":

                        var endsD = (from w in p.wordsList
                                     where w.EndsWith("d")
                                     select w).ToList();

                        int one = 0;
                        foreach (String s in endsD)
                        {
                         Console.WriteLine("\n" + s);
                         one++;
                        }
                        Console.WriteLine("The Number of words that start with 'd' : " + one);
                        break;

                    case "8":
                       
                        var greater4 = (from w in p.wordsList
                                        where w.Length > 4
                                        select w).ToList();

                        int two = 0;
                        foreach (String s in greater4)
                        {
                         Console.WriteLine("\n" + s);
                         two++;
                        }
                        Console.WriteLine("The Number of words that have more than 4 characters are : " + two);
                        break;

                    case "9":
                        
                        var less3 = (from w in p.wordsList
                                        where w.StartsWith("a") && w.Length < 3
                                        select w).ToList();

                        int three = 0;
                        foreach (String s in less3)
                        {
                         Console.WriteLine("\n" + s);
                         three++;
                        }
                        Console.WriteLine("The Number of words that have less than 3 characters are : " + three);
                        break;

                    case "x":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;


                }
            }


        }

       
    }
}

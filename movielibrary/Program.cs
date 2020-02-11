using System;
using System.IO;
using NLog;

namespace movielibrary
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            String file = AppDomain.CurrentDomain.BaseDirectory + "movies.txt";
            String choice;
            int movieID = 20000;

            do
            {
                Console.WriteLine("1.) Read data from file");
                Console.WriteLine("2.) Add data to file");
                Console.WriteLine("3.) Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

               

                if (choice == "1")
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            Console.WriteLine("Movie ID: {0}, Title: {1}," +
                                "Genre:{2}",
                                arr[0], arr[1], arr[2]);


                        }
                        sr.Close();
                    }

                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                else if (choice == "2")
                {
                    // create file from data

                    // ask a question
                    Console.WriteLine("Enter a movie? (Y/N)");
                    // input the response
                    string resp = Console.ReadLine().ToUpper();
                    // if the response is anything other than "Y", stop asking
                    if (resp != "Y") { break; }
                    //prompt for ticket ID
                     movieID = movieID + 1;
                    Console.WriteLine($"Adding new movie to library under Movie ID {movieID}");
                    // save movie ID
                    Console.WriteLine();

                    // prompt for movie title
                    Console.WriteLine("Enter movie title: ");
                    // save movie title
                    string movieTitle = Console.ReadLine();

                    // prompt for movie genre
                    Console.WriteLine("Enter the genre of the movie: ");
                    // save movie genre
                    string movieGenre = Console.ReadLine();
                    


                    StreamWriter sw = new StreamWriter(file, append: true);

                    sw.WriteLine("{0},{1},{2}",
                        movieID, movieTitle, movieGenre);


                    sw.Close();


                }

            } while (choice == "1" || choice == "2");
        }


    }
}








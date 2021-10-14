using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;



namespace Rhinoceros
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            var database = dbClient.GetDatabase("rhinoceros");
            var collection = database.GetCollection<BsonDocument>("departments");

            using (TextFieldParser csvReader = new TextFieldParser("/Users/yaaqoub/Projets/C#/Rhinoceros/Rhinoceros/monfichier.csv"))
            {
                csvReader.CommentTokens = new string[] { "#" };
                csvReader.SetDelimiters(new string[] { ";" });
                csvReader.HasFieldsEnclosedInQuotes = true;

                csvReader.ReadLine();

                while(!csvReader.EndOfData)
                {
                    string[] fields = csvReader.ReadFields();
                    string departementCode = fields[0];
                    string departementName = fields[1];
                    string departementNbPopulation = fields[2];

                    var document = new BsonDocument
                    {
                        {"Code",departementCode.ToString() },
                        {"Name",departementName.ToString() },
                        {"Population", Int32.Parse(departementNbPopulation)}
                    };

                    collection.InsertOne(document);
                }

            }

        }


        public static System.Collections.ArrayList lecture()
        {

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();


            var arlist1 = new System.Collections.ArrayList();
            var maListe = new System.Collections.ArrayList();

            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                String[,,] tableau;

                var reader = new StreamReader("/Users/yaaqoub/Projets/C#/Rhinoceros/Rhinoceros/monfichier.csv");




                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listC.Add(values[2]);
                }


                for (int i = 1; i < listA.Count; i++)
                {
                    var arlist = new System.Collections.ArrayList();

                    arlist.Add(listA[i]);
                    arlist.Add(listB[i]);
                    arlist.Add(listC[i]);

                    maListe.Add(arlist);
                                     
                }


                Console.WriteLine(maListe.Count);

                for (int i = 0; i < maListe.Count; i++)
                {
                    Console.WriteLine(maListe[i].ToBson());
                
                }

                Console.WriteLine("Ma liste");


                Console.WriteLine("--------1----------");


                foreach (var db in listA)
                {
                    Console.WriteLine(db);
                }

                Console.WriteLine("--------2---------");


                foreach (var db in listB)
                {
                    Console.WriteLine(db);
                }

                Console.WriteLine("--------3---------");

                foreach (var db in listC)
                {
                    Console.WriteLine(db);
                }

                Console.WriteLine("-------FIN----------");


                return maListe;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");

            }

            return maListe ;
        }


        public static void ecrire(System.Collections.ArrayList list)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            var database = dbClient.GetDatabase("rhinoceros");
            var collection = database.GetCollection<BsonDocument>("departments");

            for (int i = 0; i < list.Count; i++)
            {
                collection.InsertOne(list[i].ToBsonDocument());
            }

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

        }

    }
}

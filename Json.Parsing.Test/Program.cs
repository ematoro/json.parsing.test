using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Json.Parsing.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading data from json file...");
            var myJsonString = File.ReadAllText("myfile.json");
            Console.WriteLine("The data read is:");
            Console.WriteLine(myJsonString);
            Console.WriteLine();
            //Analizando el contenido del json
            objectParse(myJsonString);

            //Salir del programa
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        /*
         * Un método para analizar el contenido: Using JObject
         */
        private static void objectParse(string myJsonString)
        {
            var myJObject = JObject.Parse(myJsonString);
            if (myJObject.SelectToken("MyStringProperty") != null)
            {
                var value = myJObject.SelectToken("MyStringProperty").Value<string>();
                Console.WriteLine("Parser e.g. 1: " + value);
            }
            else
            {
                Console.WriteLine("Wrong parsing, the token was not found.");
            }
            //Otros ejemplos usando el query language JSON
            var mySubDocumentValue = myJObject.SelectToken("$.MySubDocument.SubDocumentProperty").Value<string>();
            Console.WriteLine("Parser e.g. 2: " + mySubDocumentValue);
            var myList = myJObject.SelectTokens("$.MyListProperty").Values<int>().ToList();
            Console.WriteLine("Parser e.g. 3: " + myList[1].ToString());
        }
    }
}

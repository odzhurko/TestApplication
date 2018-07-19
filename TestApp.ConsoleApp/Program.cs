using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TestApp.Library;
using TestApp.Library.Services.Interfaces;
using TestApp.Library.ViewModels;

namespace TestApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLibraryServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var migrationService = serviceProvider.GetService<IMigrationService>();
            var fabricService = serviceProvider.GetService<IFabricService>();
            List<GenIdentifierModel> items = new List<GenIdentifierModel>();
 
            using (StreamReader r = new StreamReader("Config/ToGenerate.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<GenIdentifierModel>>(json);
            }            

            //Fill database with default values
            fabricService.FillDefaultData();

            //generate new identifiers
            var result = migrationService.GenerateIdentifiers(items);

            Console.WriteLine("New identifiers:");
            foreach (var item in result)
            {
                Console.WriteLine($"Generated identifier {item.GeneratedIdentifier}");
            }            

            //write results to file
            using (StreamWriter file = File.CreateText(@"Config/AfterGenerate.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, result);
            }

            Console.WriteLine("All identifiers:");
            foreach (var item in fabricService.RetrieveIdentifiers(1,1000))
            {
                Console.WriteLine($"ID: {item.IdentifierId} Number: {item.IdentifierCode} ");
            }

            Console.ReadKey();
        }

    }
}

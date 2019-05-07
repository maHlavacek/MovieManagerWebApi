﻿using ConsoleTableExt;
using MovieManager.Core.DataTransferObjects;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;

namespace MovieManager.ConsoleClient
{
    class Program
    {
        private const string ServerNameWithPort = "localhost:44307";

        static void Main(string[] args)
        {
            //RetrieveCategories();
            RetrieveMoviesForCategoryId(3);
        }

        private static void RetrieveMoviesForCategoryId(int id)
        {
            var client = new RestClient($"https://{ServerNameWithPort}");
            var request = new RestRequest($"api/categories/{id}/movies", DataFormat.Json);

            var response = client.Get(request);

            JArray movies = JArray.Parse(response.Content);

            ConsoleTableBuilder
                .From(
                    movies
                        .Select(m => m.ToObject<MovieDTO>())
                        .OrderBy(m => m.Title)
                        .ToList())
                .ExportAndWriteLine();

        }

        public static void RetrieveCategories()
        {
            var client = new RestClient($"https://{ServerNameWithPort}");
            var request = new RestRequest("api/categories", DataFormat.Json);

            var response = client.Get(request);


            JArray categories = JArray.Parse(response.Content);

            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }

            Console.ReadKey();
        }
    }
}

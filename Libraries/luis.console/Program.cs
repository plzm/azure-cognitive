﻿using System;
using System.IO;
using System.Threading.Tasks;
using pelazem.azure.cognitive.luis;

namespace luis.console
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcessTexts().Wait();

			Console.WriteLine("Done. Press any key to exit.");
			Console.ReadKey();
		}

		static async Task ProcessTexts()
		{
			string spellCheckKey = File.ReadAllText(@"security\bingSpellcheck.apiKey.private");
			string apiUrl = File.ReadAllText(@"security\luis.apiUrl.private");
			string apiKey = File.ReadAllText(@"security\luis.apiKey.private");
			string appId = File.ReadAllText(@"security\luis.appId.private");

			LuisService svc = new LuisService(apiUrl, apiKey, appId, spellCheckKey);

			string query1 = "I want to drink latte";
			LuisServiceResult result1 = await svc.Query(query1);
			Console.WriteLine(result1.ToJson());
			Console.WriteLine();

			string query2 = "I LOVE coffee! I can't wait to drink more!!";
			LuisServiceResult result2 = await svc.Query(query2);
			Console.WriteLine(result2.ToJson());
			Console.WriteLine();

			string query3 = "I am SO HUNGRY - need food!";
			LuisServiceResult result3 = await svc.Query(query3);
			Console.WriteLine(result3.ToJson());
			Console.WriteLine();

		}
	}
}

// - # - # - # - # - # - # - # - # -# - # - # - # - # - # - # - # - # - #
//
// WARNING: Steam market API only allows 19 requests per minute
// You will get a Too Many Requests error if you exceed this!
// ERROR: Internal Server Error means that the item does not exist, check
// that the appid is the right game for that item, and the item is spelled correctly
//
// - # - # - # - # - # - # - # - # -# - # - # - # - # - # - # - # - # - #

using System;
using Newtonsoft.Json;
using System.Net;

namespace MarketScraper
{
	public static class Utils
	{
		public static string StatTrak = "StatTrak%E2%84%A2 ";
	}

	public enum AppIds
	{
		CSGO = 730,
		TF2 = 440,
		DOTA2 = 570,
		PUBG = 578080,
		H1Z1 = 433850,
		Unturned = 304930,
		Rust = 252490
	}

	public enum Currency
	{
		USD = 1, // United States Dollars
		UKP = 2, // United Kingdom Pounds
		EUR = 3, // European Euros
		CHF = 4, // Swiss Franc
		RUB = 5, // Russian Roubles
		POL = 6, // Polish złoty 
		BZL = 7, // Brazilian real
		JAP = 8, // Japanese Yen
		SWD = 9, // Swedish Krona
		IND = 10, // Indonesian Rupiah
		MAL = 11 // Malaysian Ringgit
	}

	public class MarketItem
	{
		public bool success;
		public string lowest_price;
		public string median_price;
		public string volume;
		public string name; // the only manually populated value

		public override string ToString()
		{
			string Name = name + ": ";
			if (median_price.Length > 0)
				return Name + "\n" + median_price;
			else if (lowest_price.Length > 0)
				return Name + "\n" + lowest_price;
			else
				return Name + "\nNo valid price found!";
		}
	}

	public static class SteamMarket
	{
		public static MarketItem GetMarketItem(AppIds AppId, string Name, Currency Currency = Currency.USD)
		{
			try
			{
				MarketItem Item;
				Item = JsonConvert.DeserializeObject<MarketItem>(new WebClient().DownloadString("http://steamcommunity.com/market/priceoverview/?appid=" + (int)AppId + "&currency=" + Currency + "&market_hash_name=" + Name.Replace(" ", "+")));
				Item.name = Name.Replace("StatTrak%E2%84%A2 ", "StatTrak ");
				return Item;
			}
			catch (WebException ex)
			{
				Console.WriteLine("ERROR: " + ex.Message);
				return null;
			}
		}
	}
}

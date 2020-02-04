using System;
using MarketScraper;

class MainClass
{
	public static void Main (string[] args)
	{
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.CSGO, Utils.StatTrak + "AWP | PAW (Factory New)"));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.TF2, "Mann Co. Supply Crate Key", Currency.UKP));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.DOTA2, "Sylvan Vedette"));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.PUBG, "RAIDER CRATE"));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.H1Z1, "Anarchy Leather Pants"));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.Unturned, "Pilot Aviators"));
		Console.WriteLine(SteamMarket.GetMarketItem(AppIds.Rust, "High Quality Bag"));
	}
}

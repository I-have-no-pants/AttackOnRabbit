using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

/*
  Adsys v 0.1 by Jesper Tingvall tingvall.pw
  Feel free to spread and include in your game as long as you give credit to Jesper Tingvall and link to tingvall.pw.
  Do not sell asset but feel free to sell games including it.
  For XML example check tingvall.pw/ad/ads.xml and tingvall.pw/ad/games.xml.
  
  Send bug reports, feature requests and love letters to jesper@tingvall.pw
*/

public class CheckForUpdate : MonoBehaviour {
	
	public string url = "http://tingvall.pw/ad/games.xml";

	public string myGameName;
	public int myVersionVersion;

	static public Game matchedGame;
	static private Game[] games;
	
	private static bool loaded = false;

	private List<GameListCallback> waitingAds = new List<GameListCallback>();
	
	public void RegisterUpdateChecker(GameListCallback ad) {
		if (loaded) 
			ad.ListLoaded();
		else
			waitingAds.Add(ad);
	}

	// Callback when the list of ads is loaded
	public interface GameListCallback {
		void ListLoaded();
	}

	public class Game {
		public string name;
		public int version;
		public string url;
		public string text;


		public Game(XmlNode game)  {

			foreach (XmlNode child in game.ChildNodes) {

				if (child.Name == "name") {
					name = child.InnerText;
				} else if (child.Name == "url") {
					url = child.InnerText;
				} else if (child.Name == "version") {
					version = int.Parse(child.InnerText);
				} else if (child.Name == "text") {
					text = child.InnerText;
				}
				
				Debug.Log(name);
			}


		}
	}

	// Builds advertisements
	IEnumerator  Start () {
		if (loaded)
			yield break;
		
		WWW web1 = new WWW(url);
		yield return web1;
		
		if (!string.IsNullOrEmpty(web1.error)) {
			Debug.Log(web1.error);
		} else {
			XmlDocument gameList = new XmlDocument();
			gameList.LoadXml(web1.text);
			games = ParseGames(gameList);

			foreach (Game g in games) {
				if (g.name.CompareTo(myGameName)==0){
					matchedGame = g;
					break;
				}
			}

			loaded = true;
			
			// Notify listeners
			foreach(var ad in waitingAds)
				ad.ListLoaded();
		}
	}

	// Find game in games
	public Game[] ParseGames(XmlDocument gameList) {
		
		XmlNodeList games = gameList.GetElementsByTagName("game");
		
		Game[] myGames = new Game[games.Count];
		int i = 0;
		foreach (XmlNode game in games) {
			Debug.Log(game);
			myGames[i++] = new Game(game);
		}
		return myGames;
	}
}

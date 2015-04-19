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

public class AdvertiseScript : MonoBehaviour {
	public string url = "http://tingvall.pw/ad/ads.xml";
	public int AdWidth;
	public int AdHeight;

	private static bool loaded = false;

	public static Ad[] ads;

	private List<AdListCallback> waitingAds = new List<AdListCallback>();

	public void RegisterAd(AdListCallback ad) {
		if (loaded) 
			ad.ListLoaded();
		else
			waitingAds.Add(ad);
	}

	// Callback when the list of ads is loaded
	public interface AdListCallback {
		void ListLoaded();
	}

	// Callback when an ad is loaded
	public interface AdCallback {
		void Loaded();
	}

	//TODO:
	// * Not getting ad ingame from the same game
	// * Randomize ad order
	private static int currentAd=0;
	public Ad getAd() {
		if (!loaded || ads == null || ads.Length < 1)
			return null;
		int prev = currentAd;
		currentAd = (currentAd+1) % (ads.Length);
		Debug.Log(prev);
		return ads[prev];
	}

	public class Ad {
		public bool loaded;
		public Sprite imageSprite;
		public string imageUrl;
		public string name = "Name missing";
		public string url = "http://tingvall.pw/";
		public string text = "Text missing";

		private int AdWidth;
		private int AdHeight;

		public Ad(XmlNode ad, int AdWidth, int AdHeight)  {
			this.AdWidth = AdWidth;
			this.AdHeight = AdHeight;

			foreach (XmlNode child in ad.ChildNodes) {

				if (child.Name == "image") {
					imageUrl = child.InnerText;
				} else if (child.Name == "name") {
					name = child.InnerText;
				} else if (child.Name == "url") {
					url = child.InnerText;
				} else if (child.Name == "text") {
					text = child.InnerText;
				}

			}
		}

		public IEnumerator LoadAd(AdCallback callback) {
			if (loaded) {
				callback.Loaded();
				yield break;
			}
			WWW web = new WWW(imageUrl);
			yield return web;
			Rect r = new Rect(0,0,AdWidth,AdHeight);
			Sprite sprite = Sprite.Create(web.texture, r, new Vector2(0,0));
			imageSprite = sprite;
			loaded = true;
			callback.Loaded();
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
			XmlDocument advertisement = new XmlDocument();
			advertisement.LoadXml(web1.text);
			ads = ParseAds(advertisement);

			loaded = true;

			// Notify listeners
			foreach(var ad in waitingAds)
				ad.ListLoaded();
		}
	}

	public Ad[] ParseAds(XmlDocument advertisement) {

		XmlNodeList ads = advertisement.GetElementsByTagName("ad");

		Ad[] myAds = new Ad[ads.Count];
		int i = 0;
		foreach (XmlNode ad in ads) {
			myAds[i++] = new Ad(ad, AdWidth, AdHeight);
		}
		return myAds;
	}

}

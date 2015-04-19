using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
  Adsys v 0.1 by Jesper Tingvall tingvall.pw
  Feel free to spread and include in your game as long as you give credit to Jesper Tingvall and link to tingvall.pw.
  Do not sell asset but feel free to sell games including it.
  For XML example check tingvall.pw/ad/ads.xml and tingvall.pw/ad/games.xml.
  
  Send bug reports, feature requests and love letters to jesper@tingvall.pw
*/

public class AdvertiseImage :  MonoBehaviour, AdvertiseScript.AdCallback, AdvertiseScript.AdListCallback{

	public AdvertiseScript ads;

	private AdvertiseScript.Ad myAd;

	public Image adSpace;
	public Text adText;
	public Text adTitle;

	void Start() {
		ads.RegisterAd(this);
	}

	// Ads are loaded. Quick display the first one!
	public void ListLoaded() {
		Debug.Log("Loading AdsLoaded . . .");
		myAd = ads.getAd();
		if (myAd != null)
			StartCoroutine(myAd.LoadAd(this));
	}

	public void Open() {
		Application.OpenURL(myAd.url);
	}

	public void Loaded() {
		Debug.Log("A!");
		adSpace.sprite = myAd.imageSprite;
		adText.text = myAd.text;
		adTitle.text = myAd.name;
	}
}

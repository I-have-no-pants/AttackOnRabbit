using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
  Adsys v 0.1 by Jesper Tingvall tingvall.pw
  Feel free to spread and include in your game as long as you give credit to Jesper Tingvall and link to tingvall.pw.
  Do not sell asset but feel free to sell games including it.
  For XML example check tingvall.pw/ad/ads.xml and tingvall.pw/ad/games.xml.
  
  Send bug reports, feature requests and love letters to jesper@tingvall.pw
*/

public class UpdateButton : MonoBehaviour, CheckForUpdate.GameListCallback{

	public CheckForUpdate updateManager;
	public Button myUpdateButton;
	public Text myUpdateButtonText;

	private CheckForUpdate.Game game;

	// Use this for initialization
	void Start () {
		updateManager.RegisterUpdateChecker(this);
	}

	public void ClickUpdate() {
		Application.OpenURL(game.url);
	}
	
	public void ListLoaded() {
		Debug.Log("Loading AdsLoaded . . .");
		game = CheckForUpdate.matchedGame;
		if (game != null) {
			if (game.version > updateManager.myVersionVersion) {
				myUpdateButtonText.text = game.text;
				myUpdateButton.gameObject.SetActive(true);
			}
		}
	}
}

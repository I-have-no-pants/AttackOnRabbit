using UnityEngine;
using System.Collections;

public class HUDAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	private bool Dead = false;

	public void Crash() {
		if (Dead)
			return;
		Dead = true;
		GetComponent<Animator> ().SetTrigger ("Crash");
		GetComponent<AudioSource> ().Play ();

	}
	
	public void Death() {
		FindObjectOfType<GameManagerScript>().RestartGame();
	}
}

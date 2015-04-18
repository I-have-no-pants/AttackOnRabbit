using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space"))
			RestartGame();
		else if (Input.GetKeyDown("escape")) {
			if (!paused) {
				Time.timeScale = 0;
				paused = true;
			}
			else {
				Time.timeScale = 1;
				paused = false;
			}
		}
	}

	public void RestartGame() {
		Application.LoadLevel(0);
	}
}

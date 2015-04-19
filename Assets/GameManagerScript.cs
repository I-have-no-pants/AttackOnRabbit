using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

	public bool paused = false;
	public float timer;
	private int memeMaxInterval = 60;
	private int memeMinInterval = 30;
	private List<string> memes = new List<string>();
	private StaticGuiAnimations sga;

	// Use this for initialization
	void Start () {
		sga = FindObjectOfType<StaticGuiAnimations>();
		timer = Random.Range(memeMinInterval,memeMaxInterval);
		memes.Add("Do a barrel roll");
		memes.Add("2 fast 4 me");
		memes.Add("Danger Zone");
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
		timer -= Time.deltaTime;
		if (timer <= 0)
			sendMeme();
	}

	void sendMeme() {
		timer = Random.Range(memeMinInterval,memeMaxInterval);
		sga.ShowMessage(memes[Random.Range(0,memes.Count-1)]);
	}

	public void RestartGame() {
		Application.LoadLevel(0);
	}
}

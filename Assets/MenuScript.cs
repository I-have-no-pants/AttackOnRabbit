using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public Text score;
	public Text highscore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		    GetComponent<Animator>().SetTrigger("Start");

		highscore.text = "Best\n" + ScoreScript.highScore;
		score.text = "Score\n" + ScoreScript.previousHighScore;
	}

	public void NextLevel() {
		Application.LoadLevel (1);
	}


}

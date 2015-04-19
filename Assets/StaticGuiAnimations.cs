using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticGuiAnimations : MonoBehaviour {

	public Text Score;
	public Text Killstreak;
	public Text Message;
	private ScoreScript sc;

	// Use this for initialization
	void Start () {
		sc = FindObjectOfType<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () {
		Score.text = "Score\n" + sc.Score;
		Killstreak.text = "Killstreak\n" + sc.killStreak;
	}

	public void EndGame() {

	}

	public void ShowMessage(string m) {
		Message.text = m;
		GetComponent<Animator> ().SetTrigger ("Message");
		GetComponent<AudioSource> ().Play ();
	}
}

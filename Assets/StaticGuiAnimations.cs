using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticGuiAnimations : MonoBehaviour {

	public Text Score;
	public Text Killstreak;
	public Text Message;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Score.text = "Score\n" + 0;
		Killstreak.text = "Killstreak\n" + 0;
	}

	public void EndGame() {

	}

	public void ShowMessage(string m) {
		Message.text = m;
		GetComponent<Animator> ().SetTrigger ("Message");
	}
}

using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public int Score;
	public int Combo;

	public float ComboTime;
	private float ComboTimer;

	public void BunnyKill(int i) {
		Score += i * Combo;
		Combo++;
		ComboTimer = ComboTime;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ComboTimer > 0)
			ComboTimer -= Time.deltaTime;
		else
			Combo = 0;

	}
}

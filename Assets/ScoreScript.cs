﻿using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	private StaticGuiAnimations sga;
	private int score = 0;
	public static int highScore = 0;
	public static int previousHighScore = 0;
	private bool showHighScore = true;
	public int killStreak = 0;
	public float killStreakTime = 10;
	private float killStreakTimer;
	private string killSteakMessage;
	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			if (score > highScore) {
				highScore = score;
				if (showHighScore) {
					sga.ShowMessage("New Highscore");
					showHighScore = false;
				}
			}
			if (score > previousHighScore)
				previousHighScore = score;
			killStreak += 1;
			killStreakTimer = killStreakTime;
			if (killStreak == 2)
				sga.ShowMessage("Double Kill");
			else if (killStreak == 3)
				sga.ShowMessage("Multi Kill");
			else if (killStreak == 4)
				sga.ShowMessage("Mega Kill");
			else if (killStreak == 5)
				sga.ShowMessage("Ultra Kill");
			else if (killStreak == 6)
				sga.ShowMessage("Monster Kill");
			else if (killStreak == 7)
				sga.ShowMessage("Ludicrous Kill");
			else if (killStreak == 8)
				sga.ShowMessage("HOLY S**T");
			else if (killStreak == 10)
				sga.ShowMessage("Rampage");
			else if (killStreak == 15)
				sga.ShowMessage("Dominating");
			else if (killStreak == 20)
				sga.ShowMessage("Unstoppable");
			else if (killStreak == 25)
				sga.ShowMessage("GODLIKE");
			else if (killStreak == 30)
				sga.ShowMessage("WICKED SICK");
		}
	}

	// Use this for initialization
	void Start () {
		killStreakTimer = killStreakTime;
		sga = FindObjectOfType<StaticGuiAnimations>();
		previousHighScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		killStreakTimer -= Time.deltaTime;
		if (killStreakTimer <= 0)
			killStreak = 0;
	}
}

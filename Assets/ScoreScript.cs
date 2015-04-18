using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public GameObject gui;
	private int score = 0;
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
			killStreak += 1;
			killStreakTimer = killStreakTime;
			StaticGuiAnimations sga = gui.GetComponent<StaticGuiAnimations>();
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
	}
	
	// Update is called once per frame
	void Update () {
		killStreakTimer -= Time.deltaTime;
		if (killStreakTimer <= 0)
			killStreak = 0;
	}
}

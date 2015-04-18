using UnityEngine;
using System.Collections;

public class BunnyDeathScript : MonoBehaviour {


	public GameObject ExplosionPref;

	public float DeathTime;
	private bool dead = false;

	// Use this for initialization
	void Start () {
	
	}

	public void OnDeath() {
		if (!dead) {
			dead = true;
			Instantiate (ExplosionPref, transform.position, transform.rotation);
			FindObjectOfType<RabbitSpawner>().RabbitsCount--;
			FindObjectOfType<ScoreScript>().Score++;
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

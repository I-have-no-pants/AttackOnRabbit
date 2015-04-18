using UnityEngine;
using System.Collections;

public class BunnyDeathScript : MonoBehaviour {


	public GameObject ExplosionPref;

	public float DeathTime;

	// Use this for initialization
	void Start () {
	
	}

	public void OnDeath() {
		Destroy (gameObject, DeathTime);
		Instantiate (ExplosionPref, transform.position, transform.rotation); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

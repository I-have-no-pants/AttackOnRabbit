using UnityEngine;
using System.Collections;

public class PlayerCollideScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
		BunnyDeathScript bds = collision.collider.gameObject.GetComponentInParent<BunnyDeathScript>();
		if (bds != null) { //Collision with a bunny
			bds.OnDeath();
			Debug.Log("Collision with bunny");
		} else { // Collision with bad stuff
			FindObjectOfType<HUDAnimator>().Crash();
			Debug.Log("CRASHING THIS PLANE WITH NO SURVIVORS");
		}
	}
}

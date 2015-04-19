using UnityEngine;
using System.Collections;

public class PlayerCollideScript : MonoBehaviour {

	public AudioSource source;
	public AudioSource dangerzone;
	private bool playOnce = false;
	private StaticGuiAnimations sga;

	// Use this for initialization
	void Start () {
		sga = FindObjectOfType<StaticGuiAnimations>();
	}
	
	// Update is called once per frame
	void Update () {
		var pos = gameObject.transform.position;
		if (pos.x > 10000 || pos.x < -10000 || pos.z > 10000 || pos.z < -10000)
			FindObjectOfType<HUDAnimator>().FadeOut();
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

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "DangerZone") {
			var rot = gameObject.transform.rotation.eulerAngles;
			Debug.Log(Mathf.Rad2Deg*rot.x+" "+rot.z);
			if ((rot.x < 270 && rot.x > 90) || (rot.z < 270 && rot.z > 90)) {
				if (!playOnce) {
					playOnce = true;
					source.Stop();
					dangerzone.Play();
					sga.ShowMessage("DANGER ZONE!");
				}
			}
		} 
	}
}

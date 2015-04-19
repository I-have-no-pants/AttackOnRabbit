using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		    GetComponent<Animator>().SetTrigger("Start");
	}

	public void NextLevel() {
		Application.LoadLevel (1);
	}


}

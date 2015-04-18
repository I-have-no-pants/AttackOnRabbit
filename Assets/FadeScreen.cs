using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {

	private float alpha = 0;
	private bool startGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
			startGame = true;
		if (startGame) {
			if (alpha > 1)
				Application.LoadLevel("plane");
			alpha += Time.deltaTime/2;
			Color color = gameObject.GetComponent<MeshRenderer>().material.color;
			color.a = alpha;
			gameObject.GetComponent<MeshRenderer>().material.color = color;
		}
	}
}

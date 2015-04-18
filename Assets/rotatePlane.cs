using UnityEngine;
using System.Collections;

public class rotatePlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 20 * Time.deltaTime);
	}
}

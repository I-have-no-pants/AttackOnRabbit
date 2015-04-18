using UnityEngine;
using System.Collections;

public class KeepZ : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var v = transform.rotation.eulerAngles;
		v.z = 0;
		var r = transform.rotation;
		r.eulerAngles = v;
		transform.rotation = r;
	}
}

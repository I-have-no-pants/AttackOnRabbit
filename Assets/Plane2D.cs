using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]
public class Plane2D : MonoBehaviour {
	public Vector3 speed;
	public float speedMax;

	private Rigidbody m_Rigidbody;
	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}

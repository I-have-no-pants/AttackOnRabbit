using UnityEngine;
using System.Collections;

public class TrackGUI : MonoBehaviour {
	public Transform target;

	public Transform player;

	public float rotateSpeed;
	public float translateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, target.position, translateSpeed * Time.deltaTime);
		transform.LookAt (player.position);
		//Quaternion.LookRotation (transform.position - player.position, player.up);	
	}
}

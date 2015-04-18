using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

	public Transform target;
	public float reload;
	public float timer;
	public float MaxRotation;
	public TurretScript turret;


	public Vector3 limitAngles;

	// Use this for initialization
	void Start () {
	
	}

	float ClampAngle(float angle, float min, float max) {
		
		if (angle<90 || angle>270){       // if angle in the critic region...
			if (angle>180) angle -= 360;  // convert all angles to -180..+180
			if (max>180) max -= 360;
			if (min>180) min -= 360;
		}    
		angle = Mathf.Clamp(angle, min, max);
		if (angle<0) angle += 360;  // if angle negative, convert to 0..360
		return angle;
	}

	public Vector3 limitAngle(Vector3 v, Vector3 l) {
		if (l.x != -1)
			v.x = ClampAngle(v.x, -v.x, v.x);
		if (l.y != -1)
			v.y = ClampAngle(v.y, -v.y, v.y);
		if (l.z != -1)
			v.z = ClampAngle(v.z, -v.z, v.z);
		return v;
	}
	
	void FixedUpdate () {

		if (timer > 0)
			timer -= Time.fixedDeltaTime;

		// Rotate
		if (target != null) {
			transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( target.transform.position- transform.position, new Vector3(0,1,0)), MaxRotation * Time.fixedDeltaTime);



		}

		if (Input.GetButton("Fire1") && timer <= 0) {
			turret.Fire();
			timer = reload;
		}
		
		
	}
}

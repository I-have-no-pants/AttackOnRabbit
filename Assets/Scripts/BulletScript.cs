using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject Explosion;

	public Collider turretCollider;
	public int lifeTime = 5;
	private float timer = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.fixedDeltaTime;
		if (timer >= lifeTime)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.collider != turretCollider) {

			if (Explosion != null) {
				Instantiate (Explosion, transform.position, Quaternion.identity);
			}

			Destroy (gameObject);
		}
	}
}

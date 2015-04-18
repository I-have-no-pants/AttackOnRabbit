using UnityEngine;
using System.Collections;

public class RabbitSpawner : MonoBehaviour {

	public GameObject rabbit;
	public CapsuleCollider rabbitCollider;
	public int maxSpawnX;
	public int minSpwanX;
	public int maxSpawnZ;
	public int minSpwanZ;
	public int spawnCount = 1;
	private int rabbitsCount = 0;
	public int RabbitsCount {
		get {
			return rabbitsCount;
		}
		set {
			rabbitsCount = value;
		}
	}
	private bool spawnMoreRabbits = true;
	public GameObject airplane;

	void SpawnRabbit() {
		int x = Random.Range(minSpwanX,maxSpawnX);
		int z = Random.Range(minSpwanZ,maxSpawnZ);

		Ray r = new Ray(new Vector3(x,1000,z),new Vector3(0,-1,0));
		RaycastHit hit;
		if (Physics.Raycast(r, out hit)) {
			Debug.Log(hit.collider.name);
			if (hit.collider.tag == "PartyZone") {
				Vector3 location = new Vector3(x,hit.point.y,z);
				if ((airplane.transform.position-location).magnitude > 50) {
					Instantiate(rabbit, location, Quaternion.Euler(0,Random.Range(0,360),0));
					RabbitsCount++;
				}
			} //else
				//SpawnRabbit();
		}
	}

	void SpawnRabbits() {
		while (RabbitsCount < spawnCount)
			SpawnRabbit();
	}

	// Use this for initialization
	void Start () {
		//SpawnRabbits();
	}
	
	// Update is called once per frame
	void Update () {
		if (RabbitsCount == spawnCount)
			spawnMoreRabbits = false;
		else if (spawnMoreRabbits)
			SpawnRabbit();
		else if (RabbitsCount < spawnCount/2)
			spawnMoreRabbits = true;
	}
}

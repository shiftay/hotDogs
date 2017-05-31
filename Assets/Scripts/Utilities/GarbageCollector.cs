using UnityEngine;


public class GarbageCollector : MonoBehaviour {

	public SpawnManager spawnTrig;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Cars") {
			Destroy(other.gameObject);
			spawnTrig.spawnCar = false;
		}
	}
}

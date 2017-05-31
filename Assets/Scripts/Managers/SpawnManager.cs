using UnityEngine;


public class SpawnManager : MonoBehaviour {

	bool playerSpawned = false;
	public bool spawnCar = false;
	public GameObject playerPrefab;
	public Transform playerSpawn;
	public GameObject[] leftCarPrefabs;
	public GameObject[] rightCarPrefabs;
	public GameObject[] customerPrefabs;
	public Transform[] peopleSpawns;
	public Transform leftcarSpawns;
	public Transform rightcarSpawns;

	int lastSpawnPoint = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!playerSpawned) {
			Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
			playerSpawned = true;
		}

		 if(!spawnCar) {
			 int randNum = Random.Range(1,3);

			 switch(randNum) {
				 case 1:
				 Instantiate(leftCarPrefabs[Random.Range(0,2)], leftcarSpawns.position, Quaternion.identity);
				 break;
				 case 2:
				 Instantiate(rightCarPrefabs[Random.Range(0,2)], rightcarSpawns.position, Quaternion.identity);
				 break;
			 }
			 spawnCar = true;
		 }

	
			 //check time, to decide amount to spawn;
		if(GameManager.Instance.queueCount <= 1 && GameManager.Instance.spawnLimit < GameManager.Instance.spawnTimeLimiter && GameManager.Instance.openForBusiness) {
			SpawnCustomer(1, lastSpawnPoint);
		}
	}


	void SpawnCustomer(int amounttoSpawn, int lastSpawn) {
		 int spawnPoint = Random.Range(0,4);
		 int customerChoice = Random.Range(0,2);
		 if(spawnPoint == lastSpawn) {
			 spawnPoint++;
			 if(spawnPoint > 3) {
				 spawnPoint = 0;
			 }
		 }

		Instantiate(customerPrefabs[customerChoice], peopleSpawns[spawnPoint].position, Quaternion.identity);

		GameManager.Instance.spawnLimit++;
		lastSpawnPoint = spawnPoint;
	}
}

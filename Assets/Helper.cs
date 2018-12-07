using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {
	public Customer test;
	public bool spawnCustomer = false;
	public List<GameObject> unused = new List<GameObject>();
	public List<GameObject> used = new List<GameObject>();
	public GameObject[] poolObjects;
	public static Helper instance;
	bool spawnTimer;
	float sTimer = 0f;


	float checkSpawn = 0f;


	void Start() {

		if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
		
		for(int i = 0; i < poolObjects.Length; i++) {
			unused.Add(poolObjects[i]);
		}
	}

	// Update is called once per frame
	void Update () {


		if(GameManager.Instance.openForBusiness && GameManager.Instance.queueCount < GameManager.Instance.spawnLimit) {
			if(!spawnTimer) {
				checkSpawn += Time.deltaTime;
			}

			if(checkSpawn > Random.Range(1,3)){
				if(Random.Range(0,GameManager.Instance.spawnTimeLimiter+1) == GameManager.Instance.spawnTimeLimiter) {
					if(!spawnTimer) {
						spawnCustomer = true;
						spawnTimer = true;
					}
				}
				checkSpawn = 0;
			}



		}

		if(spawnCustomer) {
			spawnCustomer = false;
			
			if(unused.Count > 0 && !unused[0].GetComponent<Customer>().M().exit) {
				used.Add(unused[0]);
				unused[0].GetComponent<Customer>().SetupCustomer();
				unused.RemoveAt(0);
			}
		}

		if(spawnTimer) {
			sTimer += Time.deltaTime;

			if(sTimer > 2f) {
				sTimer = 0f;
				spawnTimer = false;
			}
		}
	}


	public void updateQueue(GameObject custLeavingQ) {
		unused.Add(custLeavingQ);
		used.Remove(custLeavingQ);

		int leaving = custLeavingQ.GetComponent<Customer>().positionInQueue;


		foreach (GameObject x in used) {
			Customer ct = x.GetComponent<Customer>();
			if(ct.positionInQueue > leaving && !ct.M().moveToPos) {
				ct.positionInQueue--;
				ct.UpdatedQueue();
			}
		}
		

	}
}

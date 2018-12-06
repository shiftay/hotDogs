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
		if(spawnCustomer) {
			spawnCustomer = false;
			
			if(unused.Count > 0) {
				used.Add(unused[0]);
				unused[0].GetComponent<Customer>().SetupCustomer();
				unused.RemoveAt(0);
			}
		}
	}


	public void updateQueue(GameObject custLeavingQ) {
		unused.Add(custLeavingQ);
		used.Remove(custLeavingQ);

		int leaving = custLeavingQ.GetComponent<Customer>().positionInQueue;


		foreach (GameObject x in used) {
			Customer ct = x.GetComponent<Customer>();
			if(ct.positionInQueue > leaving) {
				ct.positionInQueue--;
				ct.UpdatedQueue();
			}
			
		}
		

	}
}

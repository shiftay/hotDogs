using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {
	public Customer test;
	public bool spawnCustomer = false;


	// Update is called once per frame
	void Update () {
		if(spawnCustomer) {
			spawnCustomer = false;
			test.SetupCustomer();
		}
	}
}

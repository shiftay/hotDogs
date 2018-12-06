using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	GameManager gm;
	public int placeinQueue;
	public Vector2 currentPos;
	bool moveToPos = false;
	bool exit = false;
	float speed = 125f;

	/// x = 0 | -3 | -6 | -9
	//	x = 0 | -130 | -260
	//	x = 481 | 325 | 168


	// Use this for initialization
	void Start () {
		currentPos = transform.position;
		gm = GameManager.Instance;		
		placeinQueue = gm.queueCount;
	}

	void Update() {
		if(moveToPos) {
			transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

			
			if(transform.position.x >= 481) {
				moveToPos = false;
			}
		}




		currentPos = transform.position;
	}

	public void setPlace(int qPos) {
		placeinQueue = qPos;
		moveToPos = true;

	}
	


}

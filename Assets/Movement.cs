using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	GameManager gm;
	public int placeinQueue;
	public Vector2 currentPos;
	public bool moveToPos = false;
	public bool exit = false;
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

			switch(placeinQueue) {
				case 0:
					if(transform.position.x >= 481) {
						turnOff();
					}
					break;
				case 1:
					if(transform.position.x >= 325) {
						turnOff();
					}
					break;
				case 2:
					if(transform.position.x >= 168) {
						turnOff();
					}
					break;
				case 3:
					if(transform.position.x >= 0) {
						turnOff();
					}
					break;
			}

		}


		if(exit) {
			transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

			if(transform.position.x >= 1025) {
				exit = false;
				transform.position = new Vector2(-100, transform.position.y);
			}
		}



		currentPos = transform.position;
	}

	void turnOff() {
		moveToPos = false;
		GetComponent<Button>().interactable = true;
	}

	public void setPlace(int qPos) {
		placeinQueue = qPos;
		moveToPos = true;

	}
	


}

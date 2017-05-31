using UnityEngine;


public class Customer : SteeringBehaviour {
	public bool served = false;
	public int hotDogChoice;
	public float patienceTimer;
	float waitingTimer;
	bool isStarted = false;
	bool waiting = false;
	Transform areaToMoveTo;
	public bool close = false;
	public float magnitudeThing;
	public GameObject exclamation;
	public GameObject question;
	public Transform exit;

	void Start () {
	//	CreateOrder.Instance.potentialHotDogs
		hotDogChoice = Random.Range(0,CreateOrder.Instance.hotDogAmount);
		patienceTimer = Random.Range(8f, 13.5f); // determines timer
		areaToMoveTo = GameObject.Find("PlayerSpawn").transform;
		exit = GameObject.Find("Exit"+Random.Range(1,4).ToString()).transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(!waiting) {
			Seek(areaToMoveTo.position,1.25f);
			// RaycastHit2D other = Physics2D.Linecast((Vector2)transform.position, (Vector2)transform.position + Steering,9);
			// if(other.collider != this && other.collider.tag != "Player") {
			// 	Evade((Vector2)transform.position + Steering, other.collider.transform.position);
			// }
			ApplySteering();
		} 

		if(GameManager.Instance.CurrentCustomer == this.gameObject) {
			exclamation.SetActive(true);
		}

			//if waiting timer too long leave
		if(waiting && !served) {
			objectToMove.velocity = Vector3.zero;
			isStarted = true;
			if(GameManager.Instance.CurrentCustomer != this.gameObject && waitingTimer >= (patienceTimer * Random.Range(1f, 1.25f))) {
				served = true;
				question.SetActive(true);
				GameManager.Instance.RemoveFromQueue(gameObject);
				isStarted = false;
			}
		}

		if(isStarted) {
			waitingTimer += Time.deltaTime;
		}

		if(served) {
			exclamation.SetActive(false);
			Seek(exit.position);
			RaycastHit2D other = Physics2D.Linecast(transform.position, Steering * 1, 9);
			if(other.collider != null) {
				Evade((Vector2)transform.position + Steering, other.collider.transform.position);
			}
			ApplySteering();
		} 
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "playerSpot") {
			waiting = true;
			GameManager.Instance.AddToQueue(gameObject);
		}


		if(other.gameObject.tag == "Exit") {
			Destroy(gameObject);
			GameManager.Instance.spawnLimit--;
		}
	}

}

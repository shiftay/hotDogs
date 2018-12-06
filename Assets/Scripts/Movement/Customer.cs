using UnityEngine;


public class Customer : SteeringBehaviour {
	public bool served = false;
	public int hotDogChoice;
	public float patienceTimer;
	float waitingTimer;
	bool isStarted = false;
	bool waiting = false;
	// public GameObject question;
	// public Transform exit;
	public int positionInQueue = -1;
	Movement m;

	void Start () {
	//	CreateOrder.Instance.potentialHotDogs
		m = GetComponent<Movement>();
		positionInQueue = -1;
	}


	public void SetupCustomer() {
		hotDogChoice = Random.Range(0,CreateOrder.Instance.hotDogAmount);
		GameManager.Instance.AddToQueue(this.gameObject);
		positionInQueue = GameManager.Instance.queueCount;
		patienceTimer = Random.Range(8f, 13.5f); // determines timer
		m.setPlace(positionInQueue);
	}

	
	// Update is called once per frame
	void Update () {
		if(!waiting) {

		} 

		//if waiting timer too long leave
		if(waiting && !served) {

			isStarted = true;
			if(GameManager.Instance.CurrentCustomer != this.gameObject && waitingTimer >= (patienceTimer * Random.Range(1f, 1.25f))) {
				served = true;
				GameManager.Instance.RemoveFromQueue(gameObject);
				isStarted = false;
			}
		}

		if(isStarted) {
			waitingTimer += Time.deltaTime;
		}

		if(served) {
			// exclamation.SetActive(false);
		}
	}

	public void UpdatedQueue() {

	}




}

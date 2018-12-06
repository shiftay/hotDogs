using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	public bool endOfDay = false;
	public bool nextCustomer = false;
	public bool checkHotDog = false;
	public bool helpingCustomer = false;
	public int timeMin;
	public int timeHrs;
	public GameObject CurrentCustomer { get { return currentCustomer;}}
	GameObject currentCustomer = null;

	public int queueCount;
	public int spawnLimit = 0;
	public int spawnTimeLimiter;
	public bool openForBusiness = false;
	HotDog[] currentDayHotDogs;
	List<GameObject> currentQueue = new List<GameObject>();
	public GameObject[] cookingUI;
	public int finishedOrder;
// --------- STATS ---------
	DailyStats stats;
	public float money; // total
	public float moneyDay;
	public int perfectOrders;
	public int goodOrders;
	public int badOrders;
	public int totalOrders;
	public int day;
// --------- STATS ---------
	Timer testTimer;
	public bool playerinSpot = false;
//	Toppings[] currentUnlocked;
	public GameObject[] actualToppings;
	private progressionManager progress;
	public progressionManager getProgess() { return progress; }
	InputControl holder;
	string gameMode = "endless";
	public string Mode() { return gameMode; }
	HotDog currentHD = new HotDog();
	public HotDog getCurrentHotDog()  { return currentHD; }
	bool pm = false;
	public static GameManager Instance { get { return instance;}}
	private static GameManager instance = null;

	// Use this for initialization
	void Awake () {
		  if (instance == null)
               instance = this;
          else if (instance != this)
                Destroy(gameObject);

		//   DontDestroyOnLoad(gameObject);

		progress = GameObject.Find("StatsManager").GetComponent<progressionManager>();
		stats = GameObject.Find("StatsManager").GetComponent<DailyStats>();
		testTimer = GetComponent<Timer>();
		NewDay();
		pm = false;
		//  nextCustomer = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(!endOfDay && !openForBusiness) {
			openForBusiness = true;
			//play a quick animation
		}


	

		queueCount = currentQueue.Count;

//-------CHECK HOT DOG---------
		if(checkHotDog) {
			// turn off cookingUI
			cookingElements(false);
			turnToppingsOff();
			// stop patience timer
			CreateOrder.Instance.PauseTime();
			// check HotDog vs customers order
			int currentStats = 0;

			// TODO: switch currentHD with the one stored within gamemanager.
			if(currentHD == CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice]) {
				currentStats++;
			} else {
				currentStats--;
			}

			if (CreateOrder.Instance.PatienceTimer < currentCustomer.GetComponent<Customer>().patienceTimer && currentStats > 0) {
				currentStats++;
			} else {
				currentStats--;
			}

			// if +2 == stats.perfect++   (diceRoll for tip)
			// if 0 == stats.good++
			// if -2 == stats.bad++
			// add amount to money
			switch(currentStats) {
				case 2:
				finishedOrder = 1;
				stats.perfectOrders++;
				stats.moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price * 1.15f;
				// perfect
				// tip
				break;
				case 0:
				finishedOrder = 2;
				stats.goodOrders++;
				stats.moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price;
				// good
				break;
				case -2:
				// bad
				finishedOrder = 3;
				stats.badOrders++;
				stats.moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price * 0.75f;
				break;
			}

			
			stats.totalOrders++;
			helpingCustomer = false;
			currentCustomer.GetComponent<Customer>().served = true;
			currentHD.Reset();
			CreateOrder.Instance.ResetTime();
			nextCustomer = false;
			currentCustomer = null;
			checkHotDog = false;
		}
//-------CHECK HOT DOG---------

		if(timeHrs >= 8 && pm) {
			endOfDay = true;
			openForBusiness = false;
		}

		if(endOfDay && !helpingCustomer) {
			if(SceneManager.GetActiveScene().name != "EndOfDay") {
				SceneManager.LoadScene("EndOfDay");
			}
		}
//--------Timer------------
		if(openForBusiness) {
			testTimer.Start();
			if(timeHrs >= 9 && timeHrs < 11) {
				spawnTimeLimiter = 2;
			} else if (timeHrs >= 11 && !pm) {
				spawnTimeLimiter = 5;
			} else if (timeHrs <= 1 && pm) {
				spawnTimeLimiter = 4;
			} else if (timeHrs > 1 && timeHrs < 5 && pm) {
				spawnTimeLimiter = 2;
			} else if (timeHrs >= 5 && timeHrs <= 7 && pm){
				spawnTimeLimiter = 4;
			} else {
				spawnTimeLimiter = 1;
			}
			timeMin = (int)Mathf.Floor(testTimer.Clock);
			if(timeMin > 59) {
				timeMin = 0;
				testTimer.SoftReset();
				timeHrs++;
				if(timeHrs > 12){
					timeHrs = 1;
					pm = true;
				}
			}
		}
//--------Timer------------
	}

	public void NewDay() {
		timeHrs = 9;
		timeMin = 0;
		moneyDay = 0f;
		perfectOrders = 0;
		goodOrders = 0;
		badOrders = 0;
		totalOrders = 0;
		day++;
		spawnLimit = 0;
		currentCustomer = null;
		currentQueue.Clear();
		playerinSpot = false;
		pm = false;
		endOfDay = false;
		openForBusiness = false;
		checkHotDog = false;
		finishedOrder = 0;
		testTimer.Reset();
	}

	public void AddToQueue(GameObject name) {
		currentQueue.Add(name);
	}

	public void RemoveFromQueue(GameObject name) {
		int holder = currentQueue.IndexOf(name);
		currentQueue.RemoveAt(holder);
	}
	void UpdateQueue(int qPos) {
		currentCustomer = currentQueue[qPos];
		currentQueue.RemoveAt(qPos);

		helpingCustomer = true;
		cookingElements(true);
		updateToppings();
			// check the active customers "patience" level
			// start a timer for patience
		CreateOrder.Instance.StartTime();

	}


	void cookingElements(bool toggle) {
		for(int i = 0; i < cookingUI.Length; i++) {
			cookingUI[i].SetActive(toggle);
		}
	}





	void updateToppings() {
		if(!actualToppings[0].activeInHierarchy && currentHD.ketchup == 1)
			actualToppings[0].SetActive(true);
		if(!actualToppings[1].activeInHierarchy && currentHD.ketchup == 2)
			actualToppings[1].SetActive(true);
		if(!actualToppings[2].activeInHierarchy && currentHD.ketchup == 3)
			actualToppings[2].SetActive(true);

		if(!actualToppings[3].activeInHierarchy && currentHD.mustard == 1)
			actualToppings[3].SetActive(true);
		if(!actualToppings[4].activeInHierarchy && currentHD.mustard == 2)
			actualToppings[4].SetActive(true);
		if(!actualToppings[5].activeInHierarchy && currentHD.mustard == 3)
			actualToppings[5].SetActive(true);

		if(!actualToppings[6].activeInHierarchy && currentHD.relish == 1)
			actualToppings[6].SetActive(true);
		if(!actualToppings[7].activeInHierarchy && currentHD.relish == 2)
			actualToppings[7].SetActive(true);

		if(!actualToppings[15].activeInHierarchy && currentHD.onions == 1)
			actualToppings[15].SetActive(true);
		if(!actualToppings[16].activeInHierarchy && currentHD.onions == 2)
			actualToppings[16].SetActive(true);

								//21 22
		if(!actualToppings[21].activeInHierarchy && currentHD.hotPeppers == 1)
			actualToppings[21].SetActive(true);
		if(!actualToppings[22].activeInHierarchy && currentHD.hotPeppers == 2)
			actualToppings[22].SetActive(true);

		if(!actualToppings[8].activeInHierarchy && currentHD.sauerkraut == 1)
			actualToppings[8].SetActive(true);
		if(!actualToppings[9].activeInHierarchy && currentHD.sauerkraut == 2)
			actualToppings[9].SetActive(true);

		if(!actualToppings[17].activeInHierarchy && currentHD.cheese == 1)
			actualToppings[17].SetActive(true);
		if(!actualToppings[18].activeInHierarchy && currentHD.cheese == 2)
			actualToppings[18].SetActive(true);

		if(!actualToppings[19].activeInHierarchy && currentHD.baconBits == 1)
			actualToppings[19].SetActive(true);
		if(!actualToppings[20].activeInHierarchy && currentHD.baconBits == 2)
			actualToppings[20].SetActive(true);

		if(!actualToppings[13].activeInHierarchy && currentHD.sourCream == 1)
			actualToppings[13].SetActive(true);
		if(!actualToppings[14].activeInHierarchy && currentHD.sourCream == 2)
			actualToppings[14].SetActive(true);

		if(!actualToppings[10].activeInHierarchy && currentHD.sriracha == 1)
			actualToppings[10].SetActive(true);
		if(!actualToppings[11].activeInHierarchy && currentHD.sriracha == 2)
			actualToppings[11].SetActive(true);
		if(!actualToppings[12].activeInHierarchy && currentHD.sriracha == 2)
			actualToppings[12].SetActive(true);

		if(!actualToppings[25].activeInHierarchy && currentHD.horseRadish == 1)
			actualToppings[25].SetActive(true);
		if(!actualToppings[26].activeInHierarchy && currentHD.horseRadish == 2)
			actualToppings[26].SetActive(true);

		if(!actualToppings[23].activeInHierarchy && currentHD.chili == 1)
			actualToppings[23].SetActive(true);
		if(!actualToppings[24].activeInHierarchy && currentHD.chili == 2)
			actualToppings[24].SetActive(true);
	}

	void turnToppingsOff() {
		for(int i = 0; i < actualToppings.Length; i++) {
			actualToppings[i].SetActive(false);
		}
	}

	public void customerPressed(Customer cust) {
		if(!helpingCustomer && currentCustomer == null) {
			UpdateQueue(cust.positionInQueue);
		}
	}

	public void hotdogServed() {
		checkHotDog = true;
	}

}

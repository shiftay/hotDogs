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

	public int finishedOrder;
// --------- STATS ---------
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
	InputControl holder;

	HotDog currentHotDog;
	public HotDog getCurrentHotDog()  { return currentHotDog; }
	bool pm = false;
	public static GameManager Instance { get { return instance;}}
	private static GameManager instance = null;

	// Use this for initialization
	void Awake () {
		  if (instance == null)
               instance = this;
          else if (instance != this)
                Destroy(gameObject);

		  DontDestroyOnLoad(gameObject);
		  testTimer = GetComponent<Timer>();
		  NewDay();
		  pm = false;
		//  nextCustomer = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerinSpot && !endOfDay && !openForBusiness) {
			openForBusiness = true;
			//play a quick animation
		}


		queueCount = currentQueue.Count;

		if(helpingCustomer) {

			if(holder == null ) {
				if(GameObject.Find("inputHolder").activeInHierarchy) {
					holder = GameObject.Find("inputHolder").GetComponent<InputControl>();
				}
			}

			// check the active customers "patience" level
			// start a timer for patience
			CreateOrder.Instance.StartTime();

			// add stats.customerserved++;
		}

		if(queueCount > 0 && !helpingCustomer && currentCustomer == null) {
			UpdateQueue();
			nextCustomer = true;
		}

//-------CHECK HOT DOG---------
		if(checkHotDog) {
			// stop patience timer
			CreateOrder.Instance.PauseTime();
			// check HotDog vs customers order
			int currentStats = 0;

			// TODO: switch currentHD with the one stored within gamemanager.
			if(holder.CurrentHD == CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice]) {
				currentStats++;
			} else {
				currentStats--;
			}

			if (CreateOrder.Instance.PatienceTimer < currentCustomer.GetComponent<Customer>().patienceTimer && currentStats > 0) {
				currentStats++;
			} else {
				currentStats--;
			}

			switch(currentStats) {
				case 2:
				finishedOrder = 1;
				perfectOrders++;
				money += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price * 1.15f;
				moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price * 1.15f;
				// perfect
				// tip
				break;
				case 0:
				finishedOrder = 2;
				goodOrders++;
				money += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price;
				moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price;
				// good
				break;
				case -2:
				// bad
				finishedOrder = 3;
				badOrders++;
				money += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price  * 0.75f;
				moneyDay += CreateOrder.Instance.potentialHotDogs[currentCustomer.GetComponent<Customer>().hotDogChoice].price * 0.75f;
				break;
			}
			// if +2 == stats.perfect++   (diceRoll for tip)
			// if 0 == stats.good++
			// if -2 == stats.bad++
			// add amount to money
			
			totalOrders++;
			helpingCustomer = false;
			currentCustomer.GetComponent<Customer>().served = true;
			holder.CurrentHD.Reset();
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
	void UpdateQueue() {
		currentCustomer = currentQueue[0];
		currentQueue.RemoveAt(0);
	}
}

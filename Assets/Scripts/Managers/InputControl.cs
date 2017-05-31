using UnityEngine;


public class InputControl : MonoBehaviour {
	
	AudioSource aSource;
	public AudioClip ketchupSFX;
	public AudioClip relishSFX;
	public AudioClip sprinkleSFX;
	public AudioClip sizzleSFX;
	public GameObject[] toppingElements;
	public GameObject[] pages;
	public GameObject[] actualToppings;
	GameManager gm;
	public bool isCooking = false;
	public HotDog CurrentHD { get {return currentHD;}}
	HotDog currentHD = new HotDog();


	// Use this for initialization
	void Start () {
		gm = GameManager.Instance;
		aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isCooking && Input.GetButtonDown("Jump") && !gm.endOfDay && gm.nextCustomer && !gm.checkHotDog) {
			//turn on elements
			//loadup order
			// toggle iscooking
			isCooking = true;
			gm.helpingCustomer = true;
			for(int i =0; i < toppingElements.Length; i++){
				toppingElements[i].SetActive(true);
			}
		}

		if(isCooking) {

			if(Input.GetKeyDown(KeyCode.N)) {
				// next page
				if(pages[0].activeInHierarchy) {
					pages[0].SetActive(false);
					pages[1].SetActive(true);
				} else if(pages[1].activeInHierarchy) {
					pages[0].SetActive(true);
					pages[1].SetActive(false);
				}

			}
			if(Input.GetKeyDown(KeyCode.B)) {
				if(pages[1].activeInHierarchy) {
					pages[0].SetActive(true);
					pages[1].SetActive(false);
				} else if(pages[0].activeInHierarchy) {
					pages[0].SetActive(false);
					pages[1].SetActive(true);
				}
			}
//-------------------- TOPPINGS --------------------
	// --------- PAGE 1 ---------
			if(Input.GetKeyDown(KeyCode.Q)) {
				if(pages[0].activeInHierarchy) {
					
					if(!actualToppings[0].activeInHierarchy && currentHD.ketchup == 0)
						actualToppings[0].SetActive(true);
					if(!actualToppings[1].activeInHierarchy && currentHD.ketchup == 1)
						actualToppings[1].SetActive(true);
					if(!actualToppings[2].activeInHierarchy && currentHD.ketchup == 2)
						actualToppings[2].SetActive(true);
					// 0 1 2
					aSource.clip = ketchupSFX;
					aSource.Play();
					currentHD.ketchup++;
				}
			}
			if(Input.GetKeyDown(KeyCode.W)) {
				if(pages[0].activeInHierarchy) {
					// 345
					if(!actualToppings[3].activeInHierarchy && currentHD.mustard == 0)
						actualToppings[3].SetActive(true);
					if(!actualToppings[4].activeInHierarchy && currentHD.mustard == 1)
						actualToppings[4].SetActive(true);
					if(!actualToppings[5].activeInHierarchy && currentHD.mustard == 2)
						actualToppings[5].SetActive(true);
					aSource.clip = ketchupSFX;
					aSource.Play();
					currentHD.mustard++;
				}
			}
			if(Input.GetKeyDown(KeyCode.E)) {
				if(pages[0].activeInHierarchy) {
					//67
					if(!actualToppings[6].activeInHierarchy && currentHD.relish == 0)
						actualToppings[6].SetActive(true);
					if(!actualToppings[7].activeInHierarchy && currentHD.relish == 1)
						actualToppings[7].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.relish++;
				}
			}
			if(Input.GetKeyDown(KeyCode.R)) {
				if(pages[0].activeInHierarchy) {
					//15 16 
					if(!actualToppings[15].activeInHierarchy && currentHD.onions == 0)
						actualToppings[15].SetActive(true);
					if(!actualToppings[16].activeInHierarchy && currentHD.onions == 1)
						actualToppings[16].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.onions++;
				}
			}
			if(Input.GetKeyDown(KeyCode.A)) {
				if(pages[0].activeInHierarchy) {
					//21 22
					if(!actualToppings[21].activeInHierarchy && currentHD.hotPeppers == 0)
						actualToppings[21].SetActive(true);
					if(!actualToppings[22].activeInHierarchy && currentHD.hotPeppers == 1)
						actualToppings[22].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.hotPeppers++;
				}
			}
			if(Input.GetKeyDown(KeyCode.S)) {
				if(pages[0].activeInHierarchy) {
					// 8 9
					if(!actualToppings[8].activeInHierarchy && currentHD.sauerkraut == 0)
						actualToppings[8].SetActive(true);
					if(!actualToppings[9].activeInHierarchy && currentHD.sauerkraut == 1)
						actualToppings[9].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.sauerkraut++;
				}
			}
	// --------- PAGE 1 ---------
	// --------- PAGE 2 ---------
			if(Input.GetKeyDown(KeyCode.D)) {
				if(pages[1].activeInHierarchy) {
					// 17 18
					if(!actualToppings[17].activeInHierarchy && currentHD.cheese == 0)
						actualToppings[17].SetActive(true);
					if(!actualToppings[18].activeInHierarchy && currentHD.cheese == 1)
						actualToppings[18].SetActive(true);
					aSource.clip = sprinkleSFX;
					aSource.Play();
					currentHD.cheese++;
				}
			}
			if(Input.GetKeyDown(KeyCode.F)) {
				if(pages[1].activeInHierarchy) {
					// 19 20
					if(!actualToppings[19].activeInHierarchy && currentHD.baconBits == 0)
						actualToppings[19].SetActive(true);
					if(!actualToppings[20].activeInHierarchy && currentHD.baconBits == 1)
						actualToppings[20].SetActive(true);
					aSource.clip = sprinkleSFX;
					aSource.Play();
					currentHD.baconBits++;
				}
			}
			if(Input.GetKeyDown(KeyCode.Z)) {
				if(pages[1].activeInHierarchy) {
					//13 14
					if(!actualToppings[13].activeInHierarchy && currentHD.sourCream == 0)
						actualToppings[13].SetActive(true);
					if(!actualToppings[14].activeInHierarchy && currentHD.sourCream == 1)
						actualToppings[14].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.sourCream++;
				}
			}
			if(Input.GetKeyDown(KeyCode.X)) {
				if(pages[1].activeInHierarchy) {
					// 10 11 12
					if(!actualToppings[10].activeInHierarchy && currentHD.sriracha == 0)
						actualToppings[10].SetActive(true);
					if(!actualToppings[11].activeInHierarchy && currentHD.sriracha == 1)
						actualToppings[11].SetActive(true);
					if(!actualToppings[12].activeInHierarchy && currentHD.sriracha == 2)
						actualToppings[12].SetActive(true);
					aSource.clip = ketchupSFX;
					aSource.Play();
					currentHD.sriracha++;
				}
			}
			if(Input.GetKeyDown(KeyCode.C)) {
				if(pages[1].activeInHierarchy) {
					// 25 26
					if(!actualToppings[25].activeInHierarchy && currentHD.horseRadish == 0)
						actualToppings[25].SetActive(true);
					if(!actualToppings[26].activeInHierarchy && currentHD.horseRadish == 1)
						actualToppings[26].SetActive(true);
					aSource.clip = relishSFX;
					aSource.Play();
					currentHD.horseRadish++;
				}
			}
			if(Input.GetKeyDown(KeyCode.V)) {
				if(pages[1].activeInHierarchy) {
					// 23 24
					if(!actualToppings[23].activeInHierarchy && currentHD.chili == 0)
						actualToppings[23].SetActive(true);
					if(!actualToppings[24].activeInHierarchy && currentHD.chili == 1)
						actualToppings[24].SetActive(true);
					aSource.clip = sizzleSFX;
					aSource.Play();
					currentHD.chili++;
				}
			}
	// --------- PAGE 2 ---------
//-------------------- TOPPINGS --------------------

			if(Input.GetKeyDown(KeyCode.Return)) {
				//submit order
				gm.checkHotDog = true;
				isCooking = false;
				for(int i =0; i < toppingElements.Length; i++){
					toppingElements[i].SetActive(false);
				}
				for(int i =0; i < actualToppings.Length; i++){
					actualToppings[i].SetActive(false);
				}
			}
		}



	}
}

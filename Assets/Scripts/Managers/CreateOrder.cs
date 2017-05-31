using UnityEngine;

using System.Collections.Generic;

public class CreateOrder : MonoBehaviour {

	public bool isStarted = false;
	public bool isStopped = false;
	float patienceTimer;
	public int hotDogAmount;
	public float PatienceTimer { get { return patienceTimer;}}
	private static CreateOrder instance = null;
	public static CreateOrder Instance {get { return instance; }}
	public List<HotDog> potentialHotDogs = new List<HotDog>();
	public Dictionary<string, string> hotDogRecipes = new Dictionary<string, string>();
	
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	
		DontDestroyOnLoad(gameObject);
		// price metric:
		// free : ketchup - mustard - relish - Sriracha
		// 0.25 : onions - hotpeppers
		// 0.50 : sauerkraut - horseradish - bacon Bits
		// 1.00 : chili - sour cream - cheese
		potentialHotDogs.Add(new HotDog("The Bland", 0,0,0,0,0,0,0,0,0,0,0,0,3.75f));
		potentialHotDogs.Add(new HotDog("Spicy Red",2,0,2,0,0,0,2,0,0,0,0,0,4.25f));
		potentialHotDogs.Add(new HotDog("The Everything", 1,1,1,1,1,1,1,1,1,1,1,1, 8.50f));
		potentialHotDogs.Add(new HotDog("Cheesier Chili Dog",0,0,0,0,0,0,0,2,1,1,0,0, 7.25f));
		potentialHotDogs.Add(new HotDog("The Ballpark Dog",1,1,0,1,0,1,0,0,0,0,0,0,4.25f));
		potentialHotDogs.Add(new HotDog("Sweet n' Sauer", 1,0,0,1,1,0,0,0,0,0,0,0,4.25f));
		potentialHotDogs.Add(new HotDog("Ye Olde Favourite", 1,1,0,0,0,0,0,0,0,0,0,0,3.75f));
		potentialHotDogs.Add(new HotDog("Creamy Kraut Surprise", 0,0,0,0,1,1,0,0,1,0,1,0,6.00f));
		potentialHotDogs.Add(new HotDog("The First Date",0,2,0,0,0,2,1,0,1,0,0,0,5f));
		potentialHotDogs.Add(new HotDog("The Runs",0,0,2,0,0,0,2,2,0,1,1,1,8.75f));
		potentialHotDogs.Add(new HotDog("Bacon Double Cheese Dog", 1,0,0,0,0,1,0,2,1,0,0,0,6.50f));
		potentialHotDogs.Add(new HotDog("The Vegetarian", 0,0,0,1,1,1,1,0,0,0,0,0,4.75f));
		potentialHotDogs.Add(new HotDog("The Chili-Willy", 0,0,0,0,0,0,0,2,0,1,1,0,7.75f));
		potentialHotDogs.Add(new HotDog("Bloody Radish", 0,0,2,0,0,0,0,0,0,0,0,2,4.75f));
		potentialHotDogs.Add(new HotDog("The Green Giant", 0,0,0,2,0,1,0,0,0,0,0,1,3.75f));

		hotDogRecipes.Add("The Bland", "Nothing... Just give them\nthe hotdog.");
		hotDogRecipes.Add("Spicy Red", "Ketchup (x2) - Sriracha (x2)\nHot Peppers(x2)");
		hotDogRecipes.Add("The Everything", "One of Everything...");
		hotDogRecipes.Add("Cheesier Chili Dog", "Cheese(x2) - Chili\nBacon Bits");
		hotDogRecipes.Add("The Ballpark Dog", "Ketchup - Mustard\nRelish - Onions");
		hotDogRecipes.Add("Sweet n' Sauer", "Ketchup - Relish\nSauerkraut");
		hotDogRecipes.Add("Ye Olde Favourite", "Ketchup - Mustard");
		hotDogRecipes.Add("Creamy Kraut Surprise", "Sauerkraut - Onions\nSour Cream - Bacon Bits");
		hotDogRecipes.Add("The First Date", "Onions(x2) - Mustard(x2)\nHotPeppers - Bacon Bits");
		hotDogRecipes.Add("The Runs", "Sriracha(x2) - Chili - Cheese(x2)\nSour Cream - Hot Peppers(x2) - Horseradish");
		hotDogRecipes.Add("Bacon Double Cheese Dog", "Ketchup - Onions\nCheese(x2) - Bacon Bits");
		hotDogRecipes.Add("The Vegetarian", "Relish - Onions\nHot Peppers - Sauerkraut");
		hotDogRecipes.Add("The Chili-Willy", "Chili - Sour Cream\nCheese(x2)");
		hotDogRecipes.Add("Bloody Radish", "Sriracha(x2) - Horseradish(x2)");
		hotDogRecipes.Add("The Green Giant", "Relish(x2) - Onions\nHorseradish");

		hotDogAmount = potentialHotDogs.Count;
	}
	
	// Update is called once per frame
	void Update () {
	//	potentialHotDogs.Count; how to get count.
		if(isStarted && !isStopped) {
			patienceTimer += Time.deltaTime;
		}
	}

	public void StartTime() {
		isStarted = true;
		isStopped = false;
	}
	public void PauseTime() {
		isStopped = true;
	}
	public void ResetTime() {
		isStarted = false;
		isStopped = true;
		patienceTimer = 0;
	}
}

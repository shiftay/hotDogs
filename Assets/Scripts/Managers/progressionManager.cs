using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionManager : MonoBehaviour {
	// Used to hold all progression information, stats, etc..
	public static progressionManager Instance { get { return instance;}}
	private static progressionManager instance = null;
	public DailyStats dailyStats;
	public OverallStats	overallStats;
	public float current_money;
	Dictionary<string, bool> passives = new Dictionary<string, bool>();
	Dictionary<string, bool> toppings = new Dictionary<string, bool>();
	Dictionary<string, bool> activeToppings = new Dictionary<string, bool>();
	Dictionary<string, bool> activePassives = new Dictionary<string, bool>();

	string[] potentialToppings = { "Ketchup", "Mustard", "Relish", "Sriracha", "Sauerkraut", "Onions", "Hot Peppers", "Cheese", "Bacon Bits", "Chili", "Sour Cream", "Horseradish" };

	public string[] getPotentialToppings() { return potentialToppings; }
	public void setPassive(string str, bool val) {
		if(passives.ContainsKey(str)) {
			passives.Remove(str);
			passives.Add(str, val);
		}
	}
	void Start () {
		if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		// Load from XML any information.
		// passives.Add(string, bool)
		// toppings.Add(string, bool)
	}
	
}

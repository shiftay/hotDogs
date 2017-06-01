using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionManager : MonoBehaviour {
	// Used to hold all progression information, stats, etc..
	float current_money;
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
		// Load from XML any information.
		// passives.Add(string, bool)
		// toppings.Add(string, bool)
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionManager : MonoBehaviour {
	// Used to hold all progression information, stats, etc..
	public struct activeToppings {
		public bool ketchup, mustard, sriracha;
		public bool relish, sauerkraut, onions;
		public bool hotPeppers, cheese, baconBits;
		public bool chili, sourCream, horseRadish;
	}
	public struct activePassives {
		public bool drinks, napkins;
	}


	activePassives current_passives;
	activeToppings current_toppings;
	float current_money;

	public activePassives getPassives() { return current_passives; }
	public activeToppings getToppings() { return current_toppings; }

	public void setPassive(string str, bool value) {
		
	}
	void Start () {
		// Load from XML any information.
	}
	
}

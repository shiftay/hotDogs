using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToppingButtons : MonoBehaviour {
	// simple onclick
	// based off of text on button, add that topping to the hotdog
	public Text topping;

	// duplicate switch cases and set up for hotdog
	public void AddTopping() {
		switch(topping.text) {
			case "Ketchup":
				GameManager.Instance.getCurrentHotDog().ketchup++;
				break;
		}
	}	

}

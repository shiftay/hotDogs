using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToppingButtons : MonoBehaviour {
	// simple onclick
	// based off of text on button, add that topping to the hotdog
	public Text topping;
	public GameObject[] pages;

	// duplicate switch cases and set up for hotdog
	public void AddTopping() {
		switch(topping.text) {
			case "Ketchup":
				GameManager.Instance.getCurrentHotDog().ketchup++;
				break;
		}
	}

	public void changePage() {
		if(pages[0].activeInHierarchy) {
			pages[0].SetActive(false);
			pages[1].SetActive(true);
		} else if(pages[1].activeInHierarchy) {
			pages[0].SetActive(true);
			pages[1].SetActive(false);
		}
	}

}

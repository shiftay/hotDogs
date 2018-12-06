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
			case "Mustard":
				GameManager.Instance.getCurrentHotDog().mustard++;
				break;
			case "Relish":
				GameManager.Instance.getCurrentHotDog().relish++;
				break;
			case "Hot Peppers":
				GameManager.Instance.getCurrentHotDog().hotPeppers++;
				break;
			case "Sriracha":
				GameManager.Instance.getCurrentHotDog().sriracha++;
				break;
			case "Sauerkraut":
				GameManager.Instance.getCurrentHotDog().sauerkraut++;
				break;
			case "Onions":
				GameManager.Instance.getCurrentHotDog().onions++;
				break;
			case "Bacon Bits":
				GameManager.Instance.getCurrentHotDog().baconBits++;
				break;
			case "Cheese":
				GameManager.Instance.getCurrentHotDog().cheese++;
				break;
			case "Chili":
				GameManager.Instance.getCurrentHotDog().chili++;
				break;
			case "Sour Cream":
				GameManager.Instance.getCurrentHotDog().sourCream++;
				break;
			case "Horseradish":
				GameManager.Instance.getCurrentHotDog().horseRadish++;
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

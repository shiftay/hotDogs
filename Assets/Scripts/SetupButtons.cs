using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetupButtons : MonoBehaviour {

	public Button[] page1;
	public Button[] page2;

	public Button next;
	public Button back;
	GameManager gm;

	void Start () {
		gm = GameManager.Instance;
		//TODO: this will get the activeToppings 
		//		iterate through them and label all buttons accordingly.
		//		if 6 or less buttons are setup, disable next / back	
		if (gm.Mode() == "endless") {
			for(int i = 0; i < gm.getProgess().getPotentialToppings().Length; i++) {
				if( i <= 5) {
					page1[i].GetComponentInChildren<Text>().text = gm.getProgess().getPotentialToppings()[i];
				} else {
					//TODO DEBUG OUT OF RANGE
					page2[i-6].GetComponentInChildren<Text>().text = gm.getProgess().getPotentialToppings()[i];
				}
			}
		}



	}

}

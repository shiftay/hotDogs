using UnityEngine;
using UnityEngine.UI;


public class sliderBehaviour : MonoBehaviour {
	Slider patienceSlider;
	public Image Fill;
	public Text customerWarning;
	public GameObject frustratedFace;
	public InputControl inputHolder;
	Color minColor = Color.red;
	Color maxColor = Color.green;
	bool isStarted = false;
	Customer holder = null;
	// Use this for initialization
	void Start () {
		patienceSlider = GetComponent<Slider>();
	}
	
	void OnEnable() {
		isStarted = false;
		holder = GameManager.Instance.CurrentCustomer.GetComponent<Customer>();
	}
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.helpingCustomer) {
			if(!isStarted) {
				patienceSlider.maxValue = holder.patienceTimer;
				patienceSlider.value = patienceSlider.maxValue;
				// start timer in customer.
				// start slider movement here


				isStarted = true;
			}

			if(isStarted) {
				patienceSlider.value -= Time.deltaTime;
				Fill.color = Color.Lerp(minColor, maxColor, patienceSlider.value / patienceSlider.maxValue);
				customerWarning.color = Color.Lerp(minColor, maxColor, patienceSlider.value / patienceSlider.maxValue);
			}
			// set slider maxValue to currentCustomer's patience
			// count down using patienceTimer attached to customer, accessible through gamemanager
			// if it gets to 0 load a picture animated with a upset face.

		}
	}
}

using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {
	public Text timeText;
	public Text tweetText;
	public Text moneyText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = GameManager.Instance.timeHrs.ToString() + ":" + GameManager.Instance.timeMin.ToString("D2");
		moneyText.text = "$ " + GameManager.Instance.money.ToString("F2");
	}
}

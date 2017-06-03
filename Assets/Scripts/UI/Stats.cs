using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Stats : MonoBehaviour {

	public Text comboText;
	public Text totalText;
	public Text dailyText;
	public Text dayText;


	int customersServed;
	int perfects;
	int goods;
	int bads;
	float cashforDay;

	// Use this for initialization
	void Start () {
		bads = progressionManager.Instance.dailyStats.badOrders;
		goods = progressionManager.Instance.dailyStats.goodOrders;
		perfects = progressionManager.Instance.dailyStats.perfectOrders;
		cashforDay = progressionManager.Instance.dailyStats.moneyDay;
		customersServed = progressionManager.Instance.dailyStats.totalOrders;
	}
	
	// Update is called once per frame
	void Update () {
		totalText.text = "Total: $ " + progressionManager.Instance.current_money.ToString("F2");
		dailyText.text = "Daily: $ " + cashforDay.ToString("F2");
		// dayText.text = "Day " + GameManager.Instance.day.ToString();
		comboText.text = "Total Orders: " + customersServed + "\nPerfect Orders: " + perfects +
						 "\nGood Orders: " + goods + "\nBad Orders: " + bads;
	}



	public void NextDay() {
		GameManager.Instance.NewDay();
		SceneManager.LoadScene("Main");
	}

	public void EndGame() {
		GameManager.Instance.NewDay();
		GameManager.Instance.money = 0f;
		GameManager.Instance.day = 1;
		SceneManager.LoadScene("MainMenu");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyStats : MonoBehaviour {

	public float moneyDay = 0;
	public int perfectOrders;
	public int goodOrders;
	public int badOrders;
	public int totalOrders;
	OverallStats totals;
	progressionManager pm;

	void Start() {
		pm = progressionManager.Instance;
		// totals = progressionManager.Instance.overallStats;
	}

	void transferToOverall() {
		totals.totalAvgOrders += goodOrders;
		totals.totalBadOrders += badOrders;
		totals.totalPrfctOrders += perfectOrders;
		totals.totalOrders += totalOrders;

		if(moneyDay > totals.bestDay_money) {
			totals.bestDay_money = moneyDay;
		}

		pm.current_money += moneyDay;
	}
}

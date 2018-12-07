using UnityEngine;


public class Open : MonoBehaviour {

	public float openTimer;
	bool isStarted = false;
	public GameObject sign;
	
	// Update is called once per frame
	void Update () {
		// if(GameManager.Instance.openForBusiness && openTimer < 2f) {
		// 	sign.SetActive(true);
		// 	isStarted = true;
		// } else {
		// 	sign.SetActive(false);
		// }

		// if(isStarted) {
		// 	openTimer += Time.deltaTime;
		// }

	}
}

using UnityEngine;

public class CompletionSmileys : MonoBehaviour {

	public GameObject[] smileys;
	float timer = 0f;
	bool isStarted;
	bool isStopped;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(GameManager.Instance.finishedOrder) {
			case 1:
			// super happy
			smileys[1].SetActive(true);
			StartTime();
			break;
			case 2:
			// happy
			smileys[2].SetActive(true);
			StartTime();
			break;
			case 3:
			// unhappy
			smileys[0].SetActive(true);
			StartTime();
			break;
		}


		if(isStarted) {
			timer += Time.deltaTime;
		}

		if(timer > 1.75f) {
			ResetTime();
			GameManager.Instance.finishedOrder = 0;
			for(int i = 0; i < smileys.Length; i++)
				smileys[i].SetActive(false);
		}
	}



	public void StartTime() {
		isStarted = true;
		isStopped = false;
	}
	public void PauseTime() {
		isStopped = true;
	}
	public void ResetTime() {
		isStarted = false;
		isStopped = true;
		timer = 0;
	}
}

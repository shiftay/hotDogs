using UnityEngine;


public class Timer : MonoBehaviour {
	
	float clock;
	public float Clock { get { return clock;} }
	bool isStarted = false;
	bool isStopped = true;
	// Update is called once per frame
	void FixedUpdate () {
		if(isStarted) {
			clock += Time.deltaTime * 2;
		}

		if(!isStarted && !isStopped){
			Reset();
		}
	}

	public void Pause() {
		isStarted = false;
		isStopped = true;
	}
	public void Start() {
		isStarted = true;
		isStopped = false;
	}
	public void Reset() {
		clock = 0;
		isStopped = true;
	}
	public void SoftReset() {
		clock = 0;
	}
}

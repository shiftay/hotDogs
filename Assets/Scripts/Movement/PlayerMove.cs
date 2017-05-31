using UnityEngine;


public class PlayerMove : MonoBehaviour {

	bool inPosition = false;

	// Update is called once per frame
	void Update () {
		if(!inPosition)
			transform.Translate(Vector2.left * 1.5f * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "standing") {
			inPosition = true;
			GameManager.Instance.playerinSpot = true;
		}
	}
}

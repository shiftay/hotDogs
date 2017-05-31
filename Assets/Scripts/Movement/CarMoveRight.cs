using UnityEngine;


public class CarMoveRight : MonoBehaviour {
	float moveSpeed = 4f;
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * moveSpeed * Time.deltaTime );
	}
}

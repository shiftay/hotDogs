using UnityEngine;

public class CarMoveLeft : MonoBehaviour {
	float moveSpeed = 4f;
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * moveSpeed * Time.deltaTime );
	}
}

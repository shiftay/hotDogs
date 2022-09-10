using UnityEngine;
using UnityEngine.SceneManagement;


public class BlockAccess : MonoBehaviour {

	bool illegalCopy = true;
	public string message;
	public string host;
	void Start () {
		if(Application.absoluteURL == host) {
			illegalCopy = false;
		} else if(Application.absoluteURL.Contains(host)) {
			illegalCopy = false;
		}
	}

	private void OnGUI() {
		// if(illegalCopy)
		// 	GUI.Label(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 10, 400, 32), message);
		// else 
			SceneManager.LoadScene("MainMenu");
	}
}

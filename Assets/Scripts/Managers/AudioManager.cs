using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

	private static AudioManager instance = null;
	public static AudioManager Instance { get { return instance; } }
	AudioSource aSource;
	public AudioClip menuMusic;
	public AudioClip bgmMusic;
	public AudioClip endOfDayMusic; // might be the same as menuMusic
	// Use this for initialization
	void Start () {
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);

		aSource = GetComponent<AudioSource>();

		if(!aSource.isPlaying) {
			if(SceneManager.GetActiveScene().name == "Intro")
			{
				aSource.clip = menuMusic; // need main menu music
				aSource.Play();
			} else
			{
				aSource.clip = bgmMusic;		
				aSource.Play();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "Main" && aSource.isPlaying && aSource.clip != bgmMusic) {
			aSource.clip = bgmMusic;
			aSource.Play();	
		}
		if(SceneManager.GetActiveScene().name == "MainMenu" && aSource.isPlaying && aSource.clip != menuMusic ) {
			aSource.clip = menuMusic;	
			aSource.Play();
		}
		if(SceneManager.GetActiveScene().name == "EndOfDay" && aSource.isPlaying && aSource.clip != menuMusic ) {
			aSource.clip = menuMusic;	
			aSource.Play();
		}
	}
}

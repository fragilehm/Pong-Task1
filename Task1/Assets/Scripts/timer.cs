using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
	private float time = 80;
	public Text timerText;
	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		timerText.text = string.Format ("{0:00}:{1:00}", time/60, time % 60);

		if (time < 0) {
			SceneManager.LoadScene ("end");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Image backgroundImg;
	private float transition = 0.0f;
	public Text scoreText;
	public Text highscoreText;
	public Text coinsText;
	public Text highCoinsText;


	private bool isShown = false;

	// Use this for initialization
	void Start () {

		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown)
			return;

		transition += Time.deltaTime;
		backgroundImg.color = Color.Lerp(new Color(0,0,0,0), Color.white, transition);
	}


	public void ToggleEndMenu (float score){


		gameObject.SetActive (true);
		isShown = true;

		// CoinsGame is coins per game
		// Coins is total coins
		// HighCoins is highest coins

		scoreText.text = ((int)score).ToString ();
		highscoreText.text = ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
		highCoinsText.text = (PlayerPrefs.GetInt ("HighCoins")).ToString();
		coinsText.text = (PlayerPrefs.GetInt ("CoinsGame")).ToString ();



	}


	public void Restart (){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		PlayerPrefs.SetInt ("CoinsGame", 0);

	}


	public void ToMenu (){

		SceneManager.LoadScene ("Menu");

	}
}

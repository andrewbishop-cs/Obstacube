using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text highscoreText;
	public Text bankText;


	// Use this for initialization
	void Start () {

		 // TEMP FOR BOTTOM OPTION

		if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
		{
			Debug.Log("First Time Opening - RD set to 7.");

			PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
			PlayerPrefs.SetFloat ("RD", 7);
			PlayerPrefs.SetInt ("Bottom", 1);
			PlayerPrefs.SetInt ("Coins", 0);
			PlayerPrefs.SetInt ("HighCoins", 0);
			Debug.Log("First Time Opening - Bottom set to On");

		}
		else
		{
			Debug.Log("NOT First Time Opening - saved RD is " + PlayerPrefs.GetFloat("RD"));
			Debug.Log("NOT First Time Opening - saved block setting is " + PlayerPrefs.GetInt("Bottom"));

		}

		highscoreText.text = "Highscore | " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
		bankText.text = "Total Coins | " + (PlayerPrefs.GetInt ("Coins")).ToString();

	}


	public void ToGame(){

		SceneManager.LoadScene ("Game");
		PlayerPrefs.SetInt ("CoinsGame", 0);
		Debug.Log ("Going to game");

	}
		

	public void ToSettings(){

		SceneManager.LoadScene ("Settings");
		Debug.Log ("Going to settings");



	}

}
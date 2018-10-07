using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	private float score = 0.0f;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 10;

	public Text scoreText;
	public Text coinsText;
	public DeathMenu deathMenu;

	private bool isDead = false;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if (isDead)
			return;

		if (score >= scoreToNextLevel)
			LevelUp ();


		score += Time.deltaTime * difficultyLevel;

		scoreText.text = ((int)score).ToString();
		coinsText.text = PlayerPrefs.GetInt ("CoinsGame").ToString();

	}

	void LevelUp(){

		if (difficultyLevel == maxDifficultyLevel)
			return;

		scoreToNextLevel *= 2;
		difficultyLevel++;
		Debug.Log ("Level up! Difficulty: " + difficultyLevel);

		GetComponent<PlayerMotor>().SetSpeed (difficultyLevel);

	}


	public void OnDeath(){

		isDead = true;

		if (PlayerPrefs.GetFloat("Highscore") < score)
			PlayerPrefs.SetFloat ("Highscore", score);

		if (PlayerPrefs.GetInt("HighCoins") < PlayerPrefs.GetInt ("CoinsGame"))
			PlayerPrefs.SetInt ("HighCoins", PlayerPrefs.GetInt ("CoinsGame"));

		deathMenu.ToggleEndMenu (score);

	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Slider slideRend;

	void Start (){

		slideRend.value = (PlayerPrefs.GetFloat("RD"));

		if (PlayerPrefs.GetInt ("Bottom") == 1) {
			buttonText.text = "ON";
			counter = 0;
		} else {
			buttonText.text = "OFF";
			counter = 1;
		}



	}

	public void SetVolume (float volume){

		audioMixer.SetFloat ("volume", volume);

	}


	private void SetRD (float amt){

		 

		PlayerPrefs.SetFloat ("RD", amt);

		//slide.value = (PlayerPrefs.GetFloat("RD"));

		Debug.Log (amt);

	}



	public void ToMenu(){

		SceneManager.LoadScene ("Menu");
		Debug.Log ("Going to menu - render distance is " + ((int)PlayerPrefs.GetFloat("RD")));


	}

	public void resetAll(){

		PlayerPrefs.SetFloat ("RD", 7);
		slideRend.value = (PlayerPrefs.GetFloat("RD"));
		PlayerPrefs.SetFloat ("Highscore", 0);
		resetText ();

		PlayerPrefs.SetInt ("Coins", 0); // total
		PlayerPrefs.SetInt ("HighCoins", 0); // high score coins
		PlayerPrefs.SetInt ("Bottom", 1);



	}

	public GameObject resettingText;

	public void resetText (){




		resettingText.SetActive (true);

		resettingText.SetActive (false);

	}

	public Text buttonText;
	public int counter;

	public void ToggleBlocks (){

		counter++;

		if ( counter % 2 == 1) {

			buttonText.text = "OFF";
			PlayerPrefs.SetInt ("Bottom", 0);

			Debug.Log ("Blocks Off");
		} else {
			
			buttonText.text = "ON";
			PlayerPrefs.SetInt ("Bottom", 1);

			Debug.Log ("Blocks On");
		}
			
	}



}
